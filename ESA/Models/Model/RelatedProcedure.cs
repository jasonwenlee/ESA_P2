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
        [JsonProperty("$ref", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int Ref { get; set; }
        #endregion
    }
}