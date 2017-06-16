#region WritersSigniture
//Writer: Angelo Sanches
//Date Writen: June 16,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: Encapsulate the Code to do with Script and Style Extentions for Controller 
//Link: yet to be made
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
using System.Web.Mvc;

namespace AngelASPExtentions.ASPMVCControllerExtentions
{
    /// <summary>
    /// Some Extentions to quickly add Script and Style bundles to the head of any project
    /// It is to be used with the HTMLHeplerObjectExtentions.AddToRenderStyleBundles extention for the HTMLHelper called from the head of your razor page;
    /// Warning :!!: Most of these are simply here for completeness and should not really be used as the view its self should really handle all render consider using HTMLObjectExtentions ver.
    /// </summary>
    public static class ScriptAndStyleControllerExtentions
    {
        /// <summary>
        ///     You should consider HtmlHelper.AddToRenderStyleBundles extention first as this is bad practice but might be useful
        ///     For Use on controllers side to create a list for Rendering in view using HtmlHelper.RenderBundlesSylesAndScripts extention
        ///     this one in particular is used For style bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.StyleBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Controller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The controller to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find StyleBundles</param>
        /// <returns>Controller for chaining</returns>
        public static Controller AddToRenderStyleBundles(this Controller This, string[] StyleBundles)
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
        ///     You should consider HtmlHelper.AddToRenderStyleBundles extention first as this is bad practice but might be useful
        ///     For Use on controllers side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For style bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.StyleBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Controller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The controller to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find StyleBundles</param>
        /// <returns>Controller for chaining</returns>
        public static Controller CAddToRenderStyleBundles(this Controller This, List<string> StyleBundles)
        {
            if (StyleBundles == null || StyleBundles.Count() < 1)
                return This;
            return AddToRenderStyleBundles(This, StyleBundles.ToArray());
        }

        /// <summary>
        ///     You should consider HtmlHelper.AddToRenderStyleBundles extention first as this is bad practice but might be useful
        ///     For Use on controllers side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For style bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.StyleBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Controller for easy Chaining that is line seperatatable for easy read
        /// Note
        ///     Does nothing if input is null useful for place holding or templating 
        ///     This also means it ill not throw unless it has input
        /// </summary>
        /// <param name="This">The controller to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find StyleBundles</param>
        /// <returns>Controller for chaining</returns>
        public static Controller AddToRenderStyleBundles(this Controller This, string StyleBundles)
        {
            if (StyleBundles == null)
                return This;
            return AddToRenderStyleBundles(This, new string[] { StyleBundles });
        }

        /// <summary>
        ///     You should consider HtmlHelper.AddToRenderScriptBundles extention first as this is bad practice but might be useful
        ///     For Use on controllers side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For script bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.ScriptBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Controller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The controller to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find ScriptBundles</param>
        /// <returns>Controller for chaining</returns>
        public static Controller AddToRenderScriptBundles(this Controller This, string[] ScriptBundles)
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
        ///     You should consider HtmlHelper.AddToRenderScriptBundles extention first as this is bad practice but might be useful
        ///     For Use on controllers side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For script bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.ScriptBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Controller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The controller to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find ScriptBundles</param>
        /// <returns>Controller for chaining</returns>
        public static Controller AddToRenderScriptBundles(this Controller This, List<string> ScriptBundles)
        {
            if (ScriptBundles == null || ScriptBundles.Count() < 1)
                return This;
            return AddToRenderScriptBundles(This, ScriptBundles.ToArray());
        }

        /// <summary>
        ///     You should consider HtmlHelper.AddToRenderScriptBundles extention first as this is bad practice but might be useful
        ///     For Use on controllers side to create a list for Rendering in view using Html.VRenderBundlesSylesAndScripts extention
        ///     this one in particular is used For script bundles
        ///     Is useful for perpage bundles so it can be rendered in the head while not Requiring it for all
        /// throws exeption on 
        ///   ViewBag.ScriptBundles not being NULL and is not a Array as presset by earlier call, because it adds your list to ViewBag.StyleBundles
        /// Returns 
        ///     the Controller for easy Chaining that is line seperatatable for easy read
        /// </summary>
        /// <param name="This">The controller to chain off(us this. in method)</param>
        /// <param name="StyleBundles">A list of virtual paths on which to find ScriptBundles</param>
        /// <returns>Controller for chaining</returns>
        public static Controller AddToRenderScriptBundles(this Controller This, string ScriptBundles = null)
        {
            if (ScriptBundles == null)
                return This;
            return AddToRenderScriptBundles(This, new string[] { ScriptBundles });
        }
    }
}
