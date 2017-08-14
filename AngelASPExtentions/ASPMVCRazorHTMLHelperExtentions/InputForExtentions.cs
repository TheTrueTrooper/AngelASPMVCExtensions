#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 23,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To add a Validation for files that are uploaded to the server (size of files)
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.net
//  Writer/Publisher: Microsoft
//  Link: https://www.asp.net/
//  },
//  {
//  Name: stackoverflow.com question 40199870 Answer 1
//  Writer/Publisher: Stephen Muecke answered Oct 23 '16 at 5:58
//  Link: https://stackoverflow.com/questions/40199870/how-to-validate-file-type-of-httppostedfilebase-attribute-in-asp-net-mvc-4?answertab=votes#tab-top
//  },
//  {
//  Name: Reading files in JavaScript using the File APIs
//  Writer/Publisher: Eric Bidelman on June 18th, 2010
//  Link: https://www.html5rocks.com/en/tutorials/file/dndfiles/
//  }
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AngelASPExtentions.ASPMVCRazorHTMLHelperExtentions
{
    /// <summary>
    /// A class to extend the HTMLHelper and give it some new quicker set up in 
    /// </summary>
    public static class InputForExtentions
    {

        /// <summary>
        /// This method/function is to create an input For a File 
        /// </summary>
        /// <typeparam name="TModel">The Type of Model we are using</typeparam>
        /// <typeparam name="TProperty">The Type of Property of that model we would like to exploit</typeparam>
        /// <param name="This">The calling HTMLHelper</param>
        /// <param name="expression">the Expression to access the property</param>
        /// <param name="MultiFile">Should it allow multiple files</param>
        /// <returns>MvcHtmlString for the input in question</returns>
        public static MvcHtmlString FileSelectFor<TModel, TProperty>(this HtmlHelper<TModel> This, Expression<Func<TModel, TProperty>> expression, bool MultiFile)
        {
            if (MultiFile)
                return This.TextBoxFor(expression, new { type = "file", multiple = "multiple" });
            else
                return This.TextBoxFor(expression, new { type = "file" });
        }

    }
}
