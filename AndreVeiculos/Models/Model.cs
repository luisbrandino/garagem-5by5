using System.Reflection;
using System.Text.RegularExpressions;

namespace Models
{
    public interface IAttributeMappingStrategy
    {
        public string Map(string attributeName);
    }

    public class SnakeCaseStrategy : IAttributeMappingStrategy
    {
        public string Map(string attributeName)
        {
            string snakeCase = Regex.Replace(attributeName, @"(\p{Lu})", "_$1").ToLower();

            if (snakeCase.StartsWith("_"))
                snakeCase = snakeCase.Substring(1);

            return snakeCase;
        }
    }

    public class PrimaryKeyAttribute : Attribute { }

    public class AutoIncrementAttribute : Attribute { }

    public class TableAttribute : Attribute
    {
        public string Name { get; set; }

        public TableAttribute(string name)
        {
            Name = name;
        }
    }

    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }

    public abstract class Model
    {
        private static IAttributeMappingStrategy _mappingStrategy = new SnakeCaseStrategy();

        public string Table() => Table(this);
        public static string Table(Model model)
        {
            string? tableName = model.GetType().GetCustomAttribute<TableAttribute>()?.Name;

            if (tableName == null)
                throw new InvalidOperationException($"Classe concreta de '{typeof(Model)}' precisa ter 'TableAttribute'");

            return tableName;
        }

        public void SetAttribute(string attributeName, object value) => GetType().GetProperties().Where(property => _mappingStrategy.Map(property.Name) == _mappingStrategy.Map(attributeName)).FirstOrDefault()?.SetValue(this, value);

        public bool IsAutoIncrement(PropertyInfo? property) => property != null ? Attribute.IsDefined(property, typeof(AutoIncrementAttribute)) : false;
        public bool IsAutoIncrement(string propertyName) => IsAutoIncrement(GetType().GetProperties().Where(property => _mappingStrategy.Map(property.Name) == _mappingStrategy.Map(propertyName)).FirstOrDefault());

        public bool IsPrimaryKeyAutoIncrement() => IsAutoIncrement(GetPrimaryKey(this));

        public static PropertyInfo? GetPrimaryKey(Model model)
        {
            PropertyInfo[] properties = model.GetType().GetProperties();

            foreach (var property in properties)
            {
                var primaryKeyAttribute = property.GetCustomAttribute<PrimaryKeyAttribute>();

                if (primaryKeyAttribute != null)
                    return property;
            }

            return null;
        }

        public string? GetPrimaryKeyName() => GetPrimaryKeyName(this);
        public static string? GetPrimaryKeyName(Model model) => GetPrimaryKey(model)?.Name;

        public object? GetPrimaryKeyValue() => GetPrimaryKeyValue(this);
        public static object? GetPrimaryKeyValue(Model model) => GetPrimaryKey(model)?.GetValue(model);

        public static string GetColumnNameFromProperty(PropertyInfo property) => property.GetCustomAttribute<ColumnAttribute>()?.Name ?? property.Name;

        public List<string> GetColumns() => GetColumns(this);
        public static List<string> GetColumns(Model model) => model.GetType().GetProperties().Select(property => _mappingStrategy.Map(GetColumnNameFromProperty(property))).ToList();

        public Dictionary<string, object> Raw()
        {
            Dictionary<string, object> rawModel = new();

            PropertyInfo[] properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(this);

                if (value is Model)
                    value = ((Model)value).GetPrimaryKeyValue();

                rawModel.Add(_mappingStrategy.Map(GetColumnNameFromProperty(property)), value);
            }

            return rawModel;
        }
    }
}
