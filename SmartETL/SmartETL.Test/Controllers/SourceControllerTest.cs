// <copyright file= "SourceControllerTest.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

namespace SmartETL.Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using SmartETL.Controllers;
    using SmartETL.Core.Service;
    using SmartETL.Core.ViewModel;
    using Xunit;

    public class SourceControllerTest
    {
        public readonly Mock<ISourceService> sourceService;
        public readonly Mock<ILogger<SourceController>> loggerService;
        public List<SourceCredentialViewModel> credentials;
        public readonly SourceController sourceController;
        public SourceControllerTest()
        {
            sourceService = new Mock<ISourceService>();
            loggerService = new Mock<ILogger<SourceController>>();
            sourceController = new SourceController(sourceService.Object, loggerService.Object);
            credentials = new List<SourceCredentialViewModel>()
            {
                new SourceCredentialViewModel
                {
                    UserName = "sample",
                    Password = "*****",
                    ProjectName = "test",
                    AccessToken = "12232132321424",
                    TokenGeneratedTime = DateTime.Now,
                    TokenExpirationTime = DateTime.Now
                }
            };
        }

        [Fact]
        public async void GetSourceAPICredentials_HasValue_ReturnSourceCredentialList()
        {
            // Arrange 
            sourceService.Setup(x => x.GetSourceAPICredentials())
                    .Returns(credentials);

            // Act

            var actionResult = await this.sourceController.GetSourceAPICredentials() as ObjectResult;
            var result = actionResult.Value as List<SourceCredentialViewModel>;
            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Single(result);
            Assert.Equal(credentials[0].ProjectName, result[0].ProjectName);
            sourceService.Verify(x => x.GetSourceAPICredentials(), Times.Once);
        }

        [Fact]
        public async void GetSourceAPICredentials_HasNoValue_ReturnNoContent()
        {
            // Arrange 
            sourceService.Setup(x => x.GetSourceAPICredentials())
                    .Returns(new List<SourceCredentialViewModel>());

            // Act

            var actionResult = await this.sourceController.GetSourceAPICredentials();

            //Assert
            Assert.IsType<NoContentResult>(actionResult);
            sourceService.Verify(x => x.GetSourceAPICredentials(), Times.Once);
        }
    }
}
