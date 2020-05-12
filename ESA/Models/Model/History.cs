using ESA.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ESA.Models.Model
{
    public class History
    {
        #region json
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int JsonId { get; set; }
        [JsonProperty("procedure", NullValueHandling = NullValueHandling.Ignore)]
        public Procedure Procedure { get; set; }
        [JsonProperty("procedureID", NullValueHandling = NullValueHandling.Ignore)]
        public int ProcedureId { get; set; }
        [JsonProperty("references", NullValueHandling = NullValueHandling.Ignore)]
        public List<Reference> ReferencesList { get; set; }
        [JsonProperty("historyID", NullValueHandling = NullValueHandling.Ignore)]
        public int HistoryId { get; set; }
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public int Number { get; set; }
        #endregion
    }
}