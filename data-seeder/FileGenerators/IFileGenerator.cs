﻿namespace FileGenerators
{
    public interface IFileGenerator
    {
        void Generate<T>(List<T> entities);
    }
}
