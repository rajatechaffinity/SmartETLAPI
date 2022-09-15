// <copyright file= "SourceCredentialViewModel.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

namespace SmartETL.Core.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Source credential view model
    /// </summary>
    public class SourceCredentialViewModel
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public Guid UniqueId { get; set; }
        /// <summary>
        /// Project name
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Url used to authenticate 
        /// </summary>
        public string AuthenticationURL { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password to be used for authentication
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Access token generated which will be used for the subsequent request in the future
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Access token generated time
        /// </summary>
        public DateTime TokenGeneratedTime { get; set; }

        /// <summary>
        /// Indicates whether the token is active
        /// </summary>
        public bool IsTokenActive
        {
            get { return DateTime.Now < TokenExpirationTime; }
        }

        /// <summary>
        /// Time when the access token will expire
        /// </summary>
        public DateTime TokenExpirationTime { get; set; }
    }
}
