namespace Models
{
    [Table("tb_role")]
    public class Role : Model
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
