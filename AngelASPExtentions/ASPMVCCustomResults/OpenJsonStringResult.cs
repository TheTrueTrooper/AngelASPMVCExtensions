#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 19,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To add a result class to allow for usable string json results to be obtained from the asp framework 
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.NetMVC-razor-Example-TaskPlanner 
//  Writer/Publisher:Angelo Sanches (BitSan)
//  Link: https://github.com/TheTrueTrooper/ASP.NetMVC-razor-Example-TaskPlanner
//
//  Name: ASP.net
//  Writer/Publisher: Microsoft
//  Link: https://www.asp.net/
//  }
#endregion
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
    /// <summary>
    /// a class that can be used to simply Retrevie json data as strings
    /// </summary>
    class OpenJsonStringResult : JsonResult
    {
        /// <summary>
        /// The resulting string
        /// </summary>
        public string Result;

        /// <summary>
        /// forces a render and stores the existing json text as a string
        /// Is only to be used with the contorller templating extention extention 
        /// </summary>
        /// <param name="Context">a Controller Context</param>
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
