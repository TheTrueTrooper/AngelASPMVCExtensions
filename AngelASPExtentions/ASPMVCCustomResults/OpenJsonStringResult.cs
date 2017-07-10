using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AngelASPExtentions.ASPMVCCustomResults
{
    class OpenJsonStringResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Result;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Context"></param>
        public override void ExecuteResult(ControllerContext Context)
        {
            if (Context == null)
                throw new ArgumentNullException("Context");


            Data = Data ?? Context.Controller.ViewData;

            StringBuilder Builder = new StringBuilder();
            StringWriter Writer = new StringWriter(Builder);


            if (Data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                if (MaxJsonLength.HasValue)
                {
                    serializer.MaxJsonLength = MaxJsonLength.Value;
                }
                if (RecursionLimit.HasValue)
                {
                    serializer.RecursionLimit = RecursionLimit.Value;
                }
                serializer.Serialize(Data, Builder);
            }

            Result = Builder.ToString();
        }
    }
}
