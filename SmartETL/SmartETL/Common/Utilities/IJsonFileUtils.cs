// <copyright file= "IFileService.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

namespace SmartETL.Core.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for JsonFileUtils
    /// </summary>
    public interface IJsonFileUtils
    {
        public void Write(object obj, string fileName);

        public List<T> Read<T>(string fileName);
    }
}
