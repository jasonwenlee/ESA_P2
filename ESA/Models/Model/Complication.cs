using ESA.Converter;
using ESA.MarkupExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace ESA.Models.Model
{
    public class Complication
    {
        #region json
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int JsonId { get; set; }
        [JsonProperty("procedure", NullValueHandling = NullValueHandling.Ignore)]
        public Procedure Procedure { get; set; }
        [JsonProperty("procedureID", NullValueHandling = NullValueHandling.Ignore)]
        public int ProcedureId { get; set; }
        [JsonProperty("complicationID", NullValueHandling = NullValueHandling.Ignore)]
        public int ComplicationId { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string ComplicationName { get; set; }
        [JsonProperty("diagramURL", NullValueHandling = NullValueHandling.Ignore)]
        public string DiagramURL { get; set; }
        #endregion
        public int Number { get; set; }
        public bool HasDiagram { get; set; }
        public Diagram Diagram { get; set; }
    }
}