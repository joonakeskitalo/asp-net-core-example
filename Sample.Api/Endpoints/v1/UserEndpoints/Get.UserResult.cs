﻿using System;

namespace Sample.Api.Endpoints.v1.UserEndpoints
{
    public class UserResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}