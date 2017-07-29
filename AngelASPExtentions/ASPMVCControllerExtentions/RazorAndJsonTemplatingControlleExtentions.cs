#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 16,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: Encapsulate the Code to do with Script and Style Extentions for Controller 
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
using AngelASPExtentions.ASPMVCCustomResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AngelASPExtentions.ASPMVCControllerExtentions
{
    /// <summary>
    /// Provides a Controller extention to Template off razor view and get it back as a string
    /// </summary>
    public static class RazorAndJsonTemplatingControlleExtentions
    {
        /// <summary>
        /// Gets a String rep. of a view Back after Templateing. This is usefull if you would like to Template an email or something?
        /// </summary>
        /// <param name="This">The Contorller extending off of</param>
        /// <param name="ViewName">The name of the view to use</param>
        /// <returns>The HTML Templated rep. as a string</returns>
        public static string GetRazorTemplateAsString(this Controller This, string ViewName, object Model = null)
        {
            object TempRecallData = Model ?? This.ViewData.Model;

            OpenStringResult Result = new OpenStringResult(ViewName);

            This.ViewData.Model = Model;

            ControllerContext Context = new ControllerContext(This.HttpContext, This.RouteData, This);

            Result.ExecuteResult(Context);

            This.ViewData.Model = TempRecallData;

            return Result.Result;
        }

        /// <summary>
        /// Gets a String rep. of a view Back after serializing for json.
        /// </summary>
        /// <param name="This">The Contorller extending off of</param>
        /// <param name="Model">The data to pass</param>
        /// <returns>The Json rep. as a string</returns>
        public static string GetJsonAsString(this Controller This, object Model = null)
        {
            OpenJsonStringResult Result = new OpenJsonStringResult() { Data = Model ?? This.ViewData.Model };

            ControllerContext Context = new ControllerContext(This.HttpContext, This.RouteData, This);

            Result.ExecuteResult(Context);

            return Result.Result;
        }
    }


}
