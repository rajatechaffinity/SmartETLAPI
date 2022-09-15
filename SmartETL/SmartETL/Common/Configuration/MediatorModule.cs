// <copyright file= "MediatorModule.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

using Autofac;
using MediatR;
using SmartETL.Core.Repository;
using SmartETL.Core.Service;

namespace SmartETL.Configuration
{
    /// <summary>
    /// Mediator module
    /// </summary>
    public class MediatorModule : Module
    {
        /// <summary>
        /// Loads the meadiator
        /// </summary>
        /// <param name="builder">Container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType(typeof(Mediator)).As(typeof(IMediator));

            builder.RegisterType(typeof(SourceService)).As(typeof(ISourceService));
            builder.RegisterType(typeof(SourceRepository)).As(typeof(ISourceRepositiory));
            builder.RegisterType(typeof(JsonFileUtils)).As(typeof(IJsonFileUtils));
        }
    }
}
