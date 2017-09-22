using System;
using Newtonsoft.Json.Linq;

namespace InComm.Web.AdapterService.CardProcessor.InCommRtg2.Strategies
{
    public class MetaFieldCollection
    {
        private readonly JArray _data;
        public MetaFieldCollection(JArray metaFieldArray)
        {
            _data = metaFieldArray;
        }

        public string GetMetaFieldValue(string name)
        {
            if (_data == null) return null;
            foreach (var item in _data.Children())
            {
                if (string.Equals((item["name"] ?? "").ToString(), name, StringComparison.OrdinalIgnoreCase))
                    return (item["value"] ?? "").ToString();
            }
            return null;

        }
    }
}