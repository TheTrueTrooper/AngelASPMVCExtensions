using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace AngelASPExtentions.ASPMVCRazorHTMLHelperExtentions
{
    public static class ErrorMessageHelperExtentions
    {
        public static HtmlString InsertErrorMessageBox(this HtmlHelper This, string ErrorMessage = null)
        {
            if (ErrorMessage != null)
            {
                StringBuilder HTMLString = new StringBuilder("<script>\n");
                HTMLString.Append("alert(\""+ ErrorMessage + "\");\n");
                HTMLString.Append("</script>\n");
                return new HtmlString(HTMLString.ToString());
            }
            return new HtmlString("");
        }
    }
}
