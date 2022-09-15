// <copyright file= "ISourceService.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

using System.Collections.Generic;
using SmartETL.Core.ViewModel;

namespace SmartETL.Core.Service
{
    /// <summary>
    /// Source service
    /// </summary>
    public interface ISourceService
    {
        /// <summary>
        /// Gets all source api credentials that are saved
        /// </summary>
        /// <returns>Collection of SourceCredentialViewModel</returns>
        public IEnumerable<SourceCredentialViewModel> GetSourceAPICredentials();

        /// <summary>
        /// Saves the api source credential
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public bool SaveSourceCredential(SourceCredentialViewModel credential);

        public IEnumerable<User> GetUsers();
    }
}
