using ESA.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ESA.Models.Model
{
    public class KeyPoint
    {
        #region json
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int JsonId { get; set; }
        [JsonProperty("procedure", NullValueHandling = NullValueHandling.Ignore)]
        public Procedure Procedure { get; set; }
        [JsonProperty("procedureID", NullValueHandling = NullValueHandling.Ignore)]
        public int ProcedureId { get; set; }
        [JsonProperty("keyPointID", NullValueHandling = NullValueHandling.Ignore)]
        public int KeyPointId { get; set; }
        [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
        public string Header { get; set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("diagramURL", NullValueHandling = NullValueHandling.Ignore)]
        public string DiagramURL { get; set; }
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public int Number { get; set; }

        #endregion

        public string Point { get; set; }
        public string PointBold { get; set; }
        public bool HasDiagram { get; set; }
    }
}