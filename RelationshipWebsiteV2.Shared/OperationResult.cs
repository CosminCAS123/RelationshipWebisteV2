﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipWebsiteV2.Shared
{
    public class OperationResult
    {

        public bool Success { get; set; }
        public string Message { get; set; }

        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
