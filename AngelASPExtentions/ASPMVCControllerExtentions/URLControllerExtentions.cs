#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: July 17,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To add a full url Methods and other url methods as needed to the controller class  
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AngelASPExtentions.ASPMVCControllerExtentions
{
    public static class URLControllerExtentions
    {
        /// <summary>
        /// Gets a string with the domain and port to use
        /// </summary>
        /// <param name="This">The controller to call this from</param>
        /// <param name="IsHttps">Should this be presented as a https address rather than http for security</param>
        /// <returns></returns>
        public static string GetHostWithPortURL(this Controller This, bool IsHttps = true)
        {
            //build a sting with http(s if sucure)
            //then add the Host name with the port if not defualt port
            return "http" + (IsHttps ? "s" : "") + "://" + This.Request.Url.Host + (This.Request.Url.IsDefaultPort ? "" : ":" + This.Request.Url.Port);
        }

        /// <summary>
        ///     This will create a Full URL Link to an action in a controller with the server, perameters(as Gets), and port included. 
        /// throws exeption on 
        ///     null Action or controller
        /// Notes:
        ///     Optionaly it will generate as a Https or Http.
        /// Returns:
        ///     Full URL Link to an action in a controller with the server, perameters(as Gets), and port included.
        /// </summary>
        /// <param name="This">The controller to call this from/extend from</param>
        /// <param name="Action">The action to go to</param>
        /// <param name="Controller">The controller that has the action in question</param>
        /// <param name="RouteValues">The model or object containing the route values ex : new { Email = Reset.Email, Code = Code }</param>
        /// <param name="IsHttps">Should this be presented as a https address rather than http for security</param>
        /// <returns>A string with the full http address including the values for get vars set from model</returns>
        public static string MakeFullURLActionLink(this Controller This, string Action, string Controller, object RouteValues = null, bool IsHttps = true)
        {
            //throw exption on null non-nullable inputs
            if (Controller == null || Action == null)
                throw new Exception((Controller == null ? "Controller " : "") + (Action == null ? "Action " : "") + "were/was null and cannot be.");
            //Get the Host with the the port as a url and add the action to the end as a using the standard url action finding method
            return GetHostWithPortURL(This, IsHttps) + This.Url.Action(Action, Controller, RouteValues);
        }

        /// <summary>
        ///     This will create a Full URL Link to an action in a controller with the server, perameters(as Gets), and port included. 
        /// throws exeption on 
        ///     null Action or controller
        /// Notes:
        ///     -Optionaly it will generate as a Https or Http.
        ///     -Controller is assumed to be the calling controller in this case
        /// Returns:
        ///     Full URL Link to an action in a controller with the server, perameters(as Gets), and port included.
        /// </summary>
        /// <param name="This">The controller to call this from/extend from</param>
        /// <param name="Action">The action to go to</param>
        /// <param name="RouteValues">The model or object containing the route values ex : new { Email = Reset.Email, Code = Code }</param>
        /// <param name="IsHttps">Should this be presented as a https address rather than http for security</param>
        /// <returns>A string with the full http address including the values for get vars set from model</returns>
        public static string MakeFullURLActionLink(this Controller This, string Action, object RouteValues = null, bool IsHttps = true)
        {
            //throw exption on null non-nullable inputs
            if (Action == null)
                throw new Exception("Action was null and cannot be.");
            //leverage above load with the controllers name
            return MakeFullURLActionLink(This, Action, This.RouteData.Values["controller"].ToString(), RouteValues, IsHttps);
        }
    }
}
