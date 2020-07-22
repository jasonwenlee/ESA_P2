using ESA.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESA.Models.Model
{
    public class Step
    {
        #region json
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int JsonId { get; set; }
        [JsonProperty("procedure", NullValueHandling = NullValueHandling.Ignore)]
        public Procedure Procedure { get; set; }
        [JsonProperty("procedureID", NullValueHandling = NullValueHandling.Ignore)]
        public int ProcedureId { get; set; }
        [JsonProperty("stepID", NullValueHandling = NullValueHandling.Ignore)]
        public int StepId { get; set; }
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentHere { get; set; }
        [JsonProperty("diagramURL", NullValueHandling = NullValueHandling.Ignore)]
        public string DiagramURL { get; set; }
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public int Number { get; set; }
        #endregion

        public bool HasDiagram { get; set; }
        public Diagram Diagram { get; set; }
    }
}