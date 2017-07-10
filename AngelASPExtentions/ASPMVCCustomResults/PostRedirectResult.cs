using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using AngelASPExtentions.ASPMVCControllerExtentions;

namespace AngelASPExtentions.ASPMVCCustomResults
{
    class PostRedirectResult : ActionResult
    {

        string Action;
        string Controller;
        object Data;
        bool IsHttps;

        public PostRedirectResult(string ActionIn, string ContollerIn, object DataIn, bool IsHttpsIn = true)
        {
            Action = ActionIn;
            Controller = ContollerIn;
            Data = DataIn;
            IsHttps = IsHttpsIn;
        }

        public override void ExecuteResult(ControllerContext Context)
        {
            Type DataType;
            IList<PropertyInfo> props = null;

            string PostBackUrl = (Context.Controller as Controller).MakeFullURLActionLink(Action, Controller, null, IsHttps);

            if (Data != null)
            {
                DataType = Data.GetType();
                props = new List<PropertyInfo>(DataType.GetProperties());
            }

            StringBuilder Builder = new StringBuilder();
            Builder.Append("<!DOCTYPE html>");
            Builder.Append("<html>");
            Builder.Append("<head>");
            Builder.Append("<body onload='document.forms[\"form\"].submit()'>");
            Builder.AppendFormat("<form name='form' action='{0}' method='post'>", PostBackUrl);
            if (props != null)
                foreach(PropertyInfo Prop in props)
                    Builder.AppendFormat("<input type='hidden' name='{0}' value='{1}'>", Prop.Name, Prop.GetValue(Data, null));
            Builder.Append("</head>");
            Builder.Append("</html>");
            Context.HttpContext.Response.Write(Builder);
            Context.HttpContext.Response.End();

        }
    }
}
