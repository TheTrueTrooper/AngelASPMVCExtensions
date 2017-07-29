#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 16,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: Encapsulate the Code to do with Script and Style Extentions for Controller 
//Link: yet to be made
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

namespace AngelASPExtentions.ASPMVCCustomResults
{
    /// <summary>
    /// This class allows you to execute result from a controller a view page result and get back a result in a retrievable string.
    /// Warning :!!: this class is not really meant to be used alone consider using the RazorTemplatingControlleExtentions.GetRazorTemplateAsString extention in your controller. I have left it open to maybe extend tho.
    /// </summary>
    public class OpenStringResult : ViewResult
    {
        public string Result { private set; get; }

        /// <summary>
        /// Creates a OpenStringResult From a ViewName
        /// </summary>
        /// <param name="ViewNameIn"></param>
        public OpenStringResult(string ViewNameIn) : base()
        {
            ViewName = ViewNameIn;
        }

        /// <summary>
        /// forces a render and stores the existing HTML text as a string
        /// Is only to be used with the contorller templating extention extention 
        /// </summary>
        /// <param name="Context">a Controller Context</param>
        public override void ExecuteResult(ControllerContext Context)
        {
            if (Context == null)
                throw new ArgumentNullException("Context");

            if (String.IsNullOrEmpty(ViewName))
                throw new Exception("ViewName Can't be null");

            View = FindView(Context).View;
            ViewData = Context.Controller.ViewData;

            StringBuilder Builder = new StringBuilder();
            StringWriter Writer = new StringWriter(Builder);

            ViewContext ViewContext = new ViewContext(Context, View, ViewData, TempData, Writer);

            View.Render(ViewContext, Writer);

            Result = Builder.ToString();
        }
    }
}
