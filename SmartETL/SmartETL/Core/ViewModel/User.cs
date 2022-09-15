// <copyright file= "User.cs" company= "Techaffinity"> 
// Copyright (C) Techaffinity. All rights reserved. 
// </copyright>

namespace SmartETL.Core.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class User
    {
        public string UserName { get; set; }

        public int Age { get; set; }

        public string IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}
