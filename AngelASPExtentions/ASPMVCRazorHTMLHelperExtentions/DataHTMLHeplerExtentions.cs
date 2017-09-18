#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: Sep 14, 2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: Add a Get model as jason so I can make data sent out with a templated page.
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.NetMVC-razor-Example-TaskPlanner 
//  Writer:Angelo Sanches (BitSan)
//  Link: https://github.com/TheTrueTrooper/ASP.NetMVC-razor-Example-TaskPlanner
//  }
#endregion
using AngelASPExtentions.ASPMVCCustomResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AngelASPExtentions.ASPMVCRazorHTMLHelperExtentions
{
    public static class DataHTMLHeplerExtentions
    {
        /// <summary>
        /// Gets a String rep. of a view Back after serializing for json.
        /// </summary>
        /// <param name="This">The HtmlHeper extending off of</param>
        /// <param name="Model">The data to pass</param>
        /// <returns>The Json rep. as a string</returns>
        public static string GetModelsJson(this HtmlHelper This, object Model = null)
        {
            OpenJsonStringResult Result = new OpenJsonStringResult() { Data = Model ?? This.ViewData.Model };

            ControllerContext Context = new ControllerContext(This.ViewContext.HttpContext, This.ViewContext.RouteData, This.ViewContext.Controller);

            Result.ExecuteResult(Context);

            return Result.Result;
        }
    }
}
