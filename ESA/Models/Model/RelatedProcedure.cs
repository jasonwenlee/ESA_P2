using ESA.Converter;
using ESA.MarkupExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace ESA.Models.Model
{
    public class RelatedProcedure
    {
        #region json
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int JsonId { get; set; }
        [JsonProperty("procedures", NullValueHandling = NullValueHandling.Ignore)]
        public Procedure Procedures { get; set; }
        [JsonProperty("relatedprocedures", NullValueHandling = NullValueHandling.Ignore)]
        public Procedure Relatedprocedures { get; set; }
        [JsonProperty("procedure_has_RelatedProcedurecol", NullValueHandling = NullValueHandling.Ignore)]
        public int ProcedureHasRelatedProcedurecol { get; set; }
        [JsonProperty("procedureID", NullValueHandling = NullValueHandling.Ignore)]
        public int ProcedureId { get; set; }
        [JsonProperty("relatedProcedureID", NullValueHandling = NullValueHandling.Ignore)]
        public int RelatedProcedureId { get; set; }
        #endregion
    }
}