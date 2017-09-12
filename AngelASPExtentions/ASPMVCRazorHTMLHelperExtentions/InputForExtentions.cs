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
using AngelASPExtentions.ExtraExtentions;
using AngelASPExtentions.ExtraExtentions.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        private static StringBuilder AddEachProperty(this StringBuilder This, List<PropertyInfo> Props, object OBJ)
        {
            if (Props != null)
                foreach (PropertyInfo Prop in Props)
                    This.AppendFormat("{0}=\"{1}\" ", Prop.Name, Prop.GetValue(OBJ, null));
            return This;
        }
        /// <summary>
        /// This method/function is to create an input For a File 
        /// </summary>
        /// <typeparam name="TModel">The Type of Model we are using</typeparam>
        /// <typeparam name="TProperty">The Type of Property of that model we would like to exploit</typeparam>
        /// <param name="This">The calling HTMLHelper</param>
        /// <param name="expression">the Expression to access the property</param>
        /// <param name="MultiFile">Should it allow multiple files</param>
        /// <returns>MvcHtmlString for the input in question</returns>
        public static MvcHtmlString FileSelectFor<TModel, TProperty>(this HtmlHelper<TModel> This, Expression<Func<TModel, TProperty>> expression, bool MultiFile = false, object HTMLAtributes = null)
        {
            return FileSelectFor(This, expression, HTMLAtributes, MultiFile);
        }

        /// <summary>
        /// This method/function is to create an input For a File 
        /// </summary>
        /// <typeparam name="TModel">The Type of Model we are using</typeparam>
        /// <typeparam name="TProperty">The Type of Property of that model we would like to exploit</typeparam>
        /// <param name="This">The calling HTMLHelper</param>
        /// <param name="expression">the Expression to access the property</param>
        /// <param name="MultiFile">Should it allow multiple files</param>
        /// <returns>MvcHtmlString for the input in question</returns>
        public static MvcHtmlString FileSelectFor<TModel, TProperty>(this HtmlHelper<TModel> This, Expression<Func<TModel, TProperty>> expression, object HTMLAtributes = null, bool MultiFile = false)
        {
            //start by checking the object to see if it is flat but skip if it is null
            Type DataType;
            List<PropertyInfo> Props = null;

            if (HTMLAtributes != null)
            {
                DataType = HTMLAtributes.GetType();
                if (!DataType.IsTypeFlat(out Props))
                    throw new Exception("Data type is to complex to decode. It must be a simple class with simple type properties.");
            }

            // start a string for the input of type file
            StringBuilder HTMLString = new StringBuilder("<input type=\"file\" ");

            // add the multi if we want it
            if (MultiFile)
                HTMLString.Append("multiple=\"multiple\" ");

            //if we have properties for the anyom html attri add them 
            HTMLString.AddEachProperty(Props, HTMLAtributes)

            // close when done
            .Append("\">");

            return new MvcHtmlString(HTMLString.ToString());
        }

        /// <summary>
        /// Builds a html base 64 string to embed in the html; Useful for images from databases and the like you'd rather not make to a full jpeg.
        /// </summary>
        /// <typeparam name="TModel">The Type of Model we are using</typeparam>
        /// <typeparam name="TProperty">The Type of Property of that model we would like to exploit</typeparam>
        /// <param name="This">The calling HTMLHelper</param>
        /// <param name="expression">the Expression to access the property</param>
        /// <param name="MultiFile">Should it allow multiple files</param>
        /// <returns>a MvcHtmlString of the image using a base 64 string to encode</returns>
        public static MvcHtmlString Base64StringImageFor<TModel, TProperty>(this HtmlHelper<TModel> This, Expression<Func<TModel, TProperty>> expression, object HTMLAtributes = null)
        {
            //first get its type
            Type DataType;
            List<PropertyInfo> Props  = null;

            //check if flat obj
            if (HTMLAtributes != null)
            {
                DataType = HTMLAtributes.GetType();
                if (!DataType.IsTypeFlat(out Props))
                    throw new Exception("Data type is to complex to decode. It must be a simple class with simple type properties.");
            }
           
            //grab the string if it is a picture or throw.
            string PictureAsString = "";
            if (expression.ReturnType == typeof(byte[]))
                PictureAsString = Convert.ToBase64String(expression.Compile().Invoke(This.ViewData.Model) as byte[]);
            else if (expression.ReturnType == typeof(Bitmap))
                PictureAsString = (expression.Compile().Invoke(This.ViewData.Model) as Bitmap).ToBase64ImageString();
            else
                throw new Exception("Is not a valid Image Format for this");

            //start an image string 
            StringBuilder HTMLString = new StringBuilder("<img src=\"data:image;base64,")
            .Append(PictureAsString)
            .Append("\" ")

            //if we have properties for the anyom html attri add them 
            .AddEachProperty(Props, HTMLAtributes)

            // close when done
            .Append("/>");

            return new MvcHtmlString(HTMLString.ToString());
        }

    }
}
