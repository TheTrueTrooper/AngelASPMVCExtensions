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
        //"PasswordResetEmailRedirect", "Account", new { Email = Reset.Email, Code = Code }
        public static string MakeFullURLActionLink(this Controller This, string Action, string Controller, object RouteValues = null, bool IsHttps = true)
        {
            return "http" + (IsHttps ? "s" : "") + "://" + This.Request.Url.Host + (This.Request.Url.IsDefaultPort ? "": ":" + This.Request.Url.Port) + This.Url.Action(Action, Controller, RouteValues);
        }
    }
}
