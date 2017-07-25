#region WritersSigniture
//Writer: Angelo Sanches
//Date Writen: June 16,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: Encapsulate the Code to do with Script and Style Extentions for Controller 
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.NetMVC-razor-Example-TaskPlanner 
//  Writer:Angelo Sanches
//  Link: https://github.com/TheTrueTrooper/ASP.NetMVC-razor-Example-TaskPlanner
//  }
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Optimization;

namespace AngelASPExtentions.ASPMVCRazorHTMLHelperExtentions
{
    public static class ScriptAndStyleHTMLHeplerExtentions
    {
        /// <summary>
        /// This Renders To the HTML after the controller and view render Adds styles and script in the head of the DOM. In Debug it marks end and start.
        /// Make Sure is in the head
        /// </summary>
        /// <param name="This"></param>
        /// <returns>the HTML String</returns>
        public static HtmlString RenderBundles(this HtmlHelper This)
        {
            string Return = "";
            //then add The Script Bundles
            if (This.ViewBag.ScriptBundles != null && This.ViewBag.ScriptBundles is string[])
            {
                foreach (string addScript in ((string[])This.ViewBag.ScriptBundles))
                { Return += Scripts.Render(addScript).ToHtmlString(); }
            }
            // repeat for the Styles
            if (This.ViewBag.StyleBundles != null && This.ViewBag.StyleBundles is string[])
            {
                foreach (string addStyle in ((string[])This.ViewBag.StyleBundles))
                { Return += Styles.Render(addStyle).ToHtmlString(); }
            }

            return new HtmlString(Return);
        }

        /// <summary>
        ///     For Use on view side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For style bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.StyleBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Conroller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The HtmlHelper to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find StyleBundles</param>
        /// <returns>HtmlHelper for chaining</returns>
        public static HtmlHelper AddToRenderStyleBundles(this HtmlHelper This, string[] StyleBundles)
        {
            if (StyleBundles == null || StyleBundles.Count() < 1)
                return This;
            if (This.ViewBag.StyleBundles != null)
            {
                if (This.ViewBag.StyleBundles is string[])
                    This.ViewBag.StyleBundles = ((string[])This.ViewBag.StyleBundles).Union(StyleBundles);
                else
                    throw new Exception("ViewBag.StyleBundles is NOT Null. Space should be null to allow usage or posible conflict could happen");
            }
            else
                This.ViewBag.StyleBundles = StyleBundles;
            return This;
        }

        /// <summary>
        ///     For Use on view side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For style bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.StyleBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Conroller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The HtmlHelper to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find StyleBundles</param>
        /// <returns>HtmlHelper for chaining</returns>
        public static HtmlHelper AddToRenderStyleBundles(this HtmlHelper This, List<string> StyleBundles)
        {
            if (StyleBundles == null || StyleBundles.Count() < 1)
                return This;
            return AddToRenderStyleBundles(This, StyleBundles.ToArray());
        }

        /// <summary>
        ///     For Use on view side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For style bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.StyleBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Conroller for easy Chaining that is line seperatatable for easy read
        /// Note
        ///     Does nothing if input is null useful for place holding or templating 
        ///     This also means it ill not throw unless it has input
        /// </summary>
        /// <param name="This">The HtmlHelper to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find StyleBundles</param>
        /// <returns>HtmlHelper for chaining</returns>
        public static HtmlHelper AddToRenderStyleBundles(this HtmlHelper This, string StyleBundles)
        {
            if (StyleBundles == null)
                return This;
            return AddToRenderStyleBundles(This, new string[] { StyleBundles });
        }

        /// <summary>
        ///     For Use on view side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For script bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.ScriptBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Conroller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The HtmlHelper to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find ScriptBundles</param>
        /// <returns>HtmlHelper for chaining</returns>
        public static HtmlHelper AddToRenderScriptBundles(this HtmlHelper This, string[] ScriptBundles)
        {
            if (ScriptBundles == null || ScriptBundles.Count() < 1)
                return This;
            if (This.ViewBag.ScriptBundles != null)
            {
                if (This.ViewBag.ScriptBundles is string[])
                    This.ViewBag.ScriptBundles = ((string[])This.ViewBag.ScriptBundles).Union(ScriptBundles);
                else
                    throw new Exception("ViewBag.StyleBundles is NOT Null. Space should be null to allow usage or posible conflict could happen");
            }
            else
                This.ViewBag.ScriptBundles = ScriptBundles;
            return This;
        }

        /// <summary>
        ///     For Use on view side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For script bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.ScriptBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Conroller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The HtmlHelper to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find ScriptBundles</param>
        /// <returns>HtmlHelper for chaining</returns>
        public static HtmlHelper AddToRenderScriptBundles(this HtmlHelper This, List<string> ScriptBundles)
        {
            if (ScriptBundles == null || ScriptBundles.Count() < 1)
                return This;
            return AddToRenderScriptBundles(This, ScriptBundles.ToArray());
        }

        /// <summary>
        ///     For Use on views side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For script bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.ScriptBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the HtmlHelper for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The HtmlHelper to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find ScriptBundles</param>
        /// <returns>HtmlHelper for chaining</returns>
        public static HtmlHelper AddToRenderScriptBundles(this HtmlHelper This, string ScriptBundles = null)
        {
            if (ScriptBundles == null)
                return This;
            return AddToRenderScriptBundles(This, new string[] { ScriptBundles });
        }
    }

}
