using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AngelASPExtentions.ASPMVCRazorHTMLHelperExtentions
{
    public static class URLHTMLHeplerExtentions
    {
        /// <summary>
        /// Gets the Front half of a URL as in the host and port
        /// </summary>
        /// <param name="This">The HtmlHelper to call this from/extend from</param>
        /// <param name="IsHttps">Should this be presented as a https address rather than http for security</param>
        /// <returns>String Url with host and port</returns>
        public static string GetHostWithPortURL(this HtmlHelper This, bool IsHttps = true)
        {
            //build a sting with http(s if sucure)
            //then add the Host name with the port if not defualt port
            return "http" + (IsHttps ? "s" : "") + "://" + (This.ViewContext.Controller as Controller).Request.Url.Host + ((This.ViewContext.Controller as Controller).Request.Url.IsDefaultPort ? "" : ":" + (This.ViewContext.Controller as Controller).Request.Url.Port);
        }

        /// <summary>
        ///     This will create a Full URL Link to an action in a view with the server, perameters(as Gets), and port included. 
        /// throws exeption on 
        ///     null Action or controller
        /// Notes:
        ///     Optionaly it will generate as a Https or Http.
        /// Returns:
        ///     Full URL Link to an action in a controller with the server, perameters(as Gets), and port included.
        /// </summary>
        /// <param name="This">The HtmlHelper to call this from/extend from</param>
        /// <param name="Action">The action to go to</param>
        /// <param name="Controller">The controller that has the action in question</param>
        /// <param name="RouteValues">The model or object containing the route values ex : new { Email = Reset.Email, Code = Code }</param>
        /// <param name="IsHttps">Should this be presented as a https address rather than http for security</param>
        /// <returns>A string with the full http address including the values for get vars set from model</returns>
        public static string MakeFullURLActionLink(this HtmlHelper This, string Action, string Controller, object RouteValues = null, bool IsHttps = true)
        {
            //throw exption on null non-nullable inputs
            if (Controller == null || Action == null)
                throw new Exception((Controller == null ? "Controller " : "") + (Action == null ? "Action " : "") + "were/was null and cannot be.");
            //Get the Host with the the port as a url and add the action to the end as a using the standard url action finding method
            return GetHostWithPortURL(This, IsHttps) + (This.ViewContext.Controller as Controller).Url.Action(Action, Controller, RouteValues);
        }

        /// <summary>
        ///     This will create a Full URL Link to an action in a view with the server, perameters(as Gets), and port included. 
        /// throws exeption on 
        ///     null Action or controller
        /// Notes:
        ///     -Optionaly it will generate as a Https or Http.
        ///     -Controller is assumed to be the calling view's controller in this case
        /// Returns:
        ///     Full URL Link to an action in a controller with the server, perameters(as Gets), and port included.
        /// </summary>
        /// <param name="This">The HtmlHelper to call this from/extend from</param>
        /// <param name="Action">The action to go to</param>
        /// <param name="RouteValues">The model or object containing the route values ex : new { Email = Reset.Email, Code = Code }</param>
        /// <param name="IsHttps">Should this be presented as a https address rather than http for security</param>
        /// <returns>A string with the full http address including the values for get vars set from model</returns>
        public static string MakeFullURLActionLink(this HtmlHelper This, string Action, object RouteValues = null, bool IsHttps = true)
        {
            //throw exption on null non-nullable inputs
            if (Action == null)
                throw new Exception("Action was null and cannot be.");
            //leverage above load with the controllers name
            return MakeFullURLActionLink(This, Action, (This.ViewContext.Controller as Controller).ControllerContext.RouteData.Values["controller"].ToString(), RouteValues, IsHttps);
        }
    }
}
