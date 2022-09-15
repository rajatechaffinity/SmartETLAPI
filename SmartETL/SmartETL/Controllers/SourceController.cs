// <copyright file= "SourceController.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

namespace SmartETL.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SmartETL.Core.Common;
    using SmartETL.Core.Service;
    using SmartETL.Core.ViewModel;

    /// <summary>
    /// Source API controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {

        private readonly ISourceService sourceService;

        private readonly ILogger<SourceController> logger;

        /// <summary>
        /// Initializes a new instance of SourceController
        /// </summary>
        /// <param name="sourceService">Source service</param>
        /// <param name="logger">Logger</param>
        public SourceController(ISourceService sourceService, ILogger<SourceController> logger)
        {
            this.sourceService = sourceService;
            this.logger = logger;
        }

        /// <summary>
        /// Gets all source api credentials that are saved
        /// </summary>
        [HttpGet]
        [Route("/Credentials")]
        [ProducesResponseType(typeof(IEnumerable<SourceCredentialViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetSourceAPICredentials()
        {
            IEnumerable<SourceCredentialViewModel> credentials = this.sourceService.GetSourceAPICredentials();
            return credentials.Any() ? (IActionResult)this.Ok(credentials) : (IActionResult)this.NoContent();
        }

        /// <summary>
        /// Gets all source api credentials that are saved
        /// </summary>
        [HttpGet]
        [Route("/Users")]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> users = this.sourceService.GetUsers();
            return users.Any() ? (IActionResult)this.Ok(users) : (IActionResult)this.NoContent();
        }

        /// <summary>
        /// Save Source API credential
        /// </summary>
        /// <param name="credential">Credential details</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Credential")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SaveSourceCredential(SourceCredentialViewModel credential)
        {
            if (credential != null)
            {
                var result = this.sourceService.SaveSourceCredential(credential);
                this.logger.LogInformation(Constant.Success);
                return (IActionResult)this.Ok(Constant.Success);
            }

            this.logger.LogError(Constant.Error);
            return (IActionResult)this.BadRequest(Constant.Error);
        }

    }
}
