// <copyright file= "FileService.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

namespace SmartETL.Core.Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using Microsoft.Extensions.Configuration;


    /// <summary>
    /// File service class
    /// </summary>
    public class JsonFileUtils : IJsonFileUtils
    {
        private readonly IConfiguration config;
        private string folderPath;
        private readonly JsonSerializerOptions _options;

        public JsonFileUtils(IConfiguration config)
        {
            this.config = config;
            this.folderPath = config.GetValue<string>("CustomConfig:FolderPath");
        }

        /// <summary>
        /// Saves the file to the specified location
        /// </summary>
        /// <param name="Data">File content</param>
        /// <returns></returns>
        public void Write(object obj, string fileName)
        {
            var jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText($"{this.folderPath}/{fileName}", jsonString);
        }

        public List<T> Read<T>(string fileName)
        {
            string jsonData = string.Empty;
            var result = new List<T>();
            try
            {
                using (StreamReader r = new StreamReader($"{this.folderPath}/{fileName}"))
                {
                    jsonData = r.ReadToEnd();
                };
                result = JsonSerializer.Deserialize<List<T>>(jsonData);
            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
