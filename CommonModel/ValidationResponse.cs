using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
    public class ValidationResponse : OperationStatusResult
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidationError> Errors { get; set; }
    }
}
