using ESA.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ESA.Models.Model
{
    public class Variation
    {
        #region json
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int JsonId { get; set; }
        [JsonProperty("procedure", NullValueHandling = NullValueHandling.Ignore)]
        public Procedure Procedure { get; set; }
        [JsonProperty("procedureID", NullValueHandling = NullValueHandling.Ignore)]
        public long ProcedureId { get; set; }
        [JsonProperty("variationID", NullValueHandling = NullValueHandling.Ignore)]
        public long VariationId { get; set; }
        [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
        public string Header { get; set; }
        [JsonProperty("subHeader", NullValueHandling = NullValueHandling.Ignore)]
        public string SubHeader { get; set; }
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public int Number { get; set; }
        #endregion
        public FormattedString Content { get; set; }
        public List<RelatedProcedure> RelatedProcedures { get; set; } = null;
    }
}