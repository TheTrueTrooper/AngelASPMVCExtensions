#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: July 18,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To add a result class to allow for redirecting to post functions from a get function if needed
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using AngelASPExtentions.ASPMVCControllerExtentions;
using AngelASPExtentions.ExtraExtentions;

namespace AngelASPExtentions.ASPMVCCustomResults
{
    /// <summary>
    /// A class used to Redirect to post backs as a result. 
    /// Is useful if you have to use a get url request as an entry but would like to abstract to Post callback.
    /// Ex: say an email only allows for a get request, but in the final data you would like a postback with the data abstracted for the user....
    /// Note: works on your browers to redirect
    /// </summary>
    public class PostRedirectResult : ActionResult
    {
        /// <summary>
        /// the action we are going to go to
        /// </summary>
        string Action;
        /// <summary>
        /// the action's Controller we are going to go to
        /// </summary>
        string Controller;
        /// <summary>
        /// an object to serialize to html vars. use only flat Types so Simple primitive types and the like in the propertys
        /// </summary>
        object Data;

        /// <summary>
        /// A constructor to work from
        /// Throws Exeption on
        ///     If the type Data is to complicated on ExecuteResult
        /// Notes:
        ///     For data use only flat Types so Simple primitive types and the like in the propertys
        /// </summary>
        /// <param name="ActionIn">the action we are going to go to</param>
        /// <param name="ContollerIn">the action's Controller we are going to go to</param>
        /// <param name="DataIn">an object to serialize to html vars: For data use only flat Types so Simple primitive types and the like in the propertys</param>
        public PostRedirectResult(string ActionIn, string ContollerIn, object DataIn)
        {
            Action = ActionIn;
            Controller = ContollerIn;
            Data = DataIn;
        }

        /// <summary>
        ///     The overloaded meat and potatos that is sent to the browser 
        /// Throws Exeption on
        ///     If the type Data is to complicated
        /// Notes:
        ///     For data use only flat Types so Simple primitive types and the like in the propertys
        /// </summary>
        /// <param name="Context">The controllers context</param>
        public override void ExecuteResult(ControllerContext Context)
        {
            // to begin serialization we need all the properties so thes are the vars for that a Type to work from and a list of properties to use
            Type DataType;
            IList<PropertyInfo> props = null;

            //first get the url to post back to (Non-cross site)
            string PostBackUrl = (Context.Controller as Controller).Url.Action(Action, Controller);

            //if the data to use is present use it and build a property list
            if (Data != null)
            {
                //first get its type
                DataType = Data.GetType();
                //then make a list of properties from it
                props = new List<PropertyInfo>(DataType.GetProperties());

                //check to see if any type is too complicated
                if (props.All(x => !x.PropertyType.IsSimpleType()))
                    throw new Exception("Type is too complex. To ensure perdicable results please ensure all properties types are simple ");
            }

            //start a string to send out
            StringBuilder Builder = new StringBuilder();
            //int the string start page with html
            Builder.Append("<!DOCTYPE html>");
            Builder.Append("<html>");
            Builder.Append("<head>");
            //on the page start a form that on load we submit
            Builder.Append("<body onload='document.forms[\"form\"].submit()'>");
            Builder.AppendFormat("<form name='form' action='{0}' method='post'>", PostBackUrl);
            // foreach property add a hidden postback and submit 
            if (props != null)
                foreach(PropertyInfo Prop in props)
                    Builder.AppendFormat("<input type='hidden' name='{0}' value='{1}'>", Prop.Name, Prop.GetValue(Data, null));
            Builder.Append("</head>");
            Builder.Append("</html>");
            //write it all out to the Response
            Context.HttpContext.Response.Write(Builder);
            Context.HttpContext.Response.End();

        }
    }
}
