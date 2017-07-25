using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngelASPExtentions.AngelCSSToInlineEng.CSSDataTypes;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace AngelASPExtentions.AngelCSSToInlineEng.CSSFileReader
{
    static class CSSFileReader
    {
        static public CSSCollectionData ParseCSSFromFile(string File)
        {
            string FileName = VirtualPathUtility.GetFileName(File);

            string FileContent = "";

            using (StreamReader Text = new StreamReader(VirtualPathUtility.ToAbsolute(File)))
            {
                FileContent = Text.ReadToEnd();
            }

            return ParseCSSFromString(FileName, FileContent);
        }

        static public CSSCollectionData ParseCSSFromString(string CollectionName, string String)
        {
            List<CSSObjectData> ClassObjects = new List<CSSObjectData>();
            List<CSSObjectData> DomIDObjects = new List<CSSObjectData>();
            List<CSSObjectData> HTMLObjects = new List<CSSObjectData>();
            List<CSSObjectData> OtherObjects = new List<CSSObjectData>();

            //look for a pattern of *{*} as a css class may be something like this .CSSTestClass{color: Red}
            Regex RegularEx = new Regex("[\n].[{].[}][\n]");

            MatchCollection Maches = RegularEx.Matches(String);
            foreach(Match M in Maches)
            {
                string CSSObjectString = M.Value;
            }

            return new CSSCollectionData(CollectionName, ClassObjects, DomIDObjects, HTMLObjects, OtherObjects);
        }
    }
}
