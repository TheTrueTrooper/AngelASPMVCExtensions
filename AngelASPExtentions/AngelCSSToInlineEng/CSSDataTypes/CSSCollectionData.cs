#region WritersSigniture
//Writer: Angelo Sanches
//Date Writen: June 23,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To add a a object to track CSS classes
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AngelASPExtentions.AngelCSSToInlineEng.CSSDataTypes
{
    class CSSCollectionData
    {
        /// <summary>
        /// the name of this collection
        /// </summary>
        string Name;
        List<CSSObjectData> ClassObjects;
        List<CSSObjectData> DomIDObjects;
        List<CSSObjectData> HTMLObjects;
        List<CSSObjectData> OtherObjects;

        /// <summary>
        /// a simple constructor so I can use it for cloning and Concating
        /// </summary>
        protected CSSCollectionData()
        {
            ClassObjects = new List<CSSObjectData>();
            DomIDObjects = new List<CSSObjectData>();
            HTMLObjects = new List<CSSObjectData>();
            OtherObjects = new List<CSSObjectData>();
        }

        internal CSSCollectionData(string NameIn, List<CSSObjectData> ClassObjectsIn, List<CSSObjectData> DomIDObjectsIn, List<CSSObjectData> HTMLObjectsIn, List<CSSObjectData> OtherObjectsIn)
        {
            //throw any and all null argument excepts on null ins
            if (NameIn == null || ClassObjectsIn == null || DomIDObjectsIn == null || HTMLObjectsIn == null || OtherObjectsIn == null)
                throw new ArgumentNullException((NameIn == null ? "NameIn " : "") + (ClassObjectsIn == null ? "ClassObjectsIn " : "") + (HTMLObjectsIn == null ? "HTMLObjectsIn " : "") + (HTMLObjectsIn == null ? "OtherObjectsIn " : "") + "were null");

            Name = NameIn;
            ClassObjects = ClassObjectsIn;
            DomIDObjects = DomIDObjectsIn;
            HTMLObjects = HTMLObjectsIn;
            OtherObjects = OtherObjectsIn;
        }

        /// <summary>
        /// a simple Concat operation, will treat like value types using clone. This is important (but time consuming) so we can keep oringal collections with out modifing. Ex most combos will used once and float away and the orgin is more important.
        /// </summary>
        /// <param name="CSS1">The first collection to add</param>
        /// <param name="CSS2">The second collection to add</param>
        /// <returns>A new collection of clones from both lists</returns>
        public static CSSCollectionData operator +(CSSCollectionData CSS1, CSSCollectionData CSS2)
        {
            CSSCollectionData Return = new CSSCollectionData()
            {
                ClassObjects = CSS1.ClassObjects.Select(x=> (CSSObjectData)x.Clone()).ToList(),
                HTMLObjects = CSS1.HTMLObjects.Select(x => (CSSObjectData)x.Clone()).ToList(),
                DomIDObjects = CSS1.DomIDObjects.Select(x => (CSSObjectData)x.Clone()).ToList(),
                OtherObjects = CSS1.OtherObjects.Select(x => (CSSObjectData)x.Clone()).ToList()
            };
            foreach (CSSObjectData Pair in CSS2.ClassObjects)
            {
                CSS1.ClassObjects.Add((CSSObjectData)Pair.Clone());
            }
            foreach (CSSObjectData Pair in CSS2.HTMLObjects)
            {
                CSS1.ClassObjects.Add((CSSObjectData)Pair.Clone());
            }
            foreach (CSSObjectData Pair in CSS2.DomIDObjects)
            {
                CSS1.ClassObjects.Add((CSSObjectData)Pair.Clone());
            }
            foreach (CSSObjectData Pair in CSS2.OtherObjects)
            {
                CSS1.ClassObjects.Add((CSSObjectData)Pair.Clone());
            }
            return Return;
        }

        List<CSSObjectData> this[CSSBasicType Type]
        {
            get
            {
                switch (Type)
                {
                    case CSSBasicType.Class:
                        return ClassObjects;
                    case CSSBasicType.HTMLSelector:
                        return HTMLObjects;
                    case CSSBasicType.DomID:
                        return DomIDObjects;
                    case CSSBasicType.Other:
                        return OtherObjects;
                    default:
                        throw new Exception("Not a Valid type.");
                }
            }
        }
    }
}
