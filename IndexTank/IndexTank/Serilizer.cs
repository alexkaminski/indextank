using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Extensions;
using System.Web.Script.Serialization;

namespace IndexTank
{
    public class Serilizer 
    {
        public static string SerializePostValue(PostValues obj)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            StringBuilder serialized = new StringBuilder();
            ser.Serialize(obj, serialized);
            return serialized.ToString();
        }

        public static string SerializePostValues(List<PostValues> obj)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            StringBuilder serialized = new StringBuilder();
            ser.Serialize(obj, serialized);
            return serialized.ToString();
        }
    }
}
