// <copyright file= "SourceService.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartETL.Core.Repository;
using SmartETL.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartETL.Core.Service
{
    public class SourceService : ISourceService
    {
        private readonly IJsonFileUtils jsonFileUtil;
        private readonly IConfiguration config;
        private readonly ILogger<SourceService> logger;
        private readonly string fileName;

        /// <summary>
        /// Initialises a new instance of SourceService
        /// </summary>
        /// <param name="sourceRepository"></param>
        public SourceService(IJsonFileUtils jsonFileUtil, 
                            IConfiguration config, ILogger<SourceService> logger)
        {
            this.jsonFileUtil = jsonFileUtil;
            this.logger = logger;
            this.config = config;
            this.fileName = config.GetValue<string>("CustomConfig:APICredentials");
        }

        public IEnumerable<SourceCredentialViewModel> GetSourceAPICredentials()
        {
            return this.Read();
        }

        /// <summary>
        /// Gets all source api credentials that are saved
        /// </summary>
        /// <returns>Collection of SourceCredentialViewModel</returns>
        public IEnumerable<User> GetUsers()
        {
            return this.ReadUsers();
        }

        /// <summary>
        /// Saves the api source credential
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public bool SaveSourceCredential(SourceCredentialViewModel credential)
        {
            return this.write(credential);
        }

        /// <summary>
        /// Method to read the json file using the json utility
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SourceCredentialViewModel> Read()
        {
            return jsonFileUtil.Read<SourceCredentialViewModel>(this.fileName);
        }

        /// <summary>
        /// Method to read the json file using the json utility
        /// </summary>
        /// <returns></returns>
        private IEnumerable<User> ReadUsers()
        {
            return jsonFileUtil.Read<User>("User.json");
        }

        /// <summary>
        /// MEthod to write in json file using json utility
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        private bool write(SourceCredentialViewModel credential)
        {
            try
            {
                IEnumerable<SourceCredentialViewModel> credentials = this.Read();

                if (credentials.Any())
                {
                    if (credential.UniqueId != null)
                    {
                        credentials = credentials.Where(x => x.UniqueId != credential.UniqueId);
                    }
                }
                credentials = credentials.Append(credential);

                this.jsonFileUtil.Write(credentials, fileName);
                return true;
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error while saving source credential - {ex.Message}");
            }

            return false;
        }
    }
}
