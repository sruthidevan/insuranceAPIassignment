﻿using System.Net;
using Newtonsoft.Json;

namespace InsuranceCalculator.Api.Models.Dto.Common
{
    public class StatusResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
    }
}
