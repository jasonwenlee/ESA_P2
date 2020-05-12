using ESA.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ESA.Models.Model
{
    public class Reference
    {
        #region json
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int JsonId { get; set; }
        [JsonProperty("procedure", NullValueHandling = NullValueHandling.Ignore)]
        public Procedure Procedure { get; set; }
        [JsonProperty("histories", NullValueHandling = NullValueHandling.Ignore)]
        public List<History> Histories { get; set; }
        [JsonProperty("procedureID", NullValueHandling = NullValueHandling.Ignore)]
        public int ProcedureId { get; set; }
        [JsonProperty("referenceID", NullValueHandling = NullValueHandling.Ignore)]
        public int ReferenceId { get; set; }
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public int Number { get; set; }
        #endregion
        public string Body { get; set; }
    }
}