using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.AngelCSSToInlineEng
{
    class CSSCollectionData
    {
        Dictionary<string, CSSObjectData> ClassObjects = new Dictionary<string, CSSObjectData>();
        Dictionary<string, CSSObjectData> DomIDObjects = new Dictionary<string, CSSObjectData>();
        Dictionary<string, CSSObjectData> HTMLObjects = new Dictionary<string, CSSObjectData>();
        Dictionary<string, CSSObjectData> OtherObjects = new Dictionary<string, CSSObjectData>();

        CSSCollectionData()
        { }

        CSSCollectionData(StreamReader File)
        {
            string ToBeProcess = File.ReadToEnd();

            string[] Parts = ToBeProcess.Split(new char[] { '}' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static CSSCollectionData operator +(CSSCollectionData CSS1, CSSCollectionData CSS2)
        {
            CSSCollectionData Return = new CSSCollectionData()
            {
                ClassObjects = CSS1.ClassObjects.ToDictionary(x=>x.Key, x=>(CSSObjectData)x.Value.Clone()),
                HTMLObjects = CSS1.HTMLObjects.ToDictionary(x => x.Key, x => (CSSObjectData)x.Value.Clone()),
                DomIDObjects = CSS1.DomIDObjects.ToDictionary(x => x.Key, x => (CSSObjectData)x.Value.Clone()),
                OtherObjects = CSS1.OtherObjects.ToDictionary(x => x.Key, x => (CSSObjectData)x.Value.Clone())
            };
            foreach (KeyValuePair<string, CSSObjectData> Pair in CSS2.ClassObjects)
            {
                if (Return.ClassObjects.ContainsKey(Pair.Key))
                    Return.ClassObjects[Pair.Key] = Pair.Value;
                else
                    Return.ClassObjects.Add(Pair.Key, Pair.Value);
            }
            foreach (KeyValuePair<string, CSSObjectData> Pair in CSS2.HTMLObjects)
            {
                if (Return.HTMLObjects.ContainsKey(Pair.Key))
                    Return.HTMLObjects[Pair.Key] = Pair.Value;
                else
                    Return.HTMLObjects.Add(Pair.Key, Pair.Value);
            }
            foreach (KeyValuePair<string, CSSObjectData> Pair in CSS2.DomIDObjects)
            {
                if (Return.DomIDObjects.ContainsKey(Pair.Key))
                    Return.DomIDObjects[Pair.Key] = Pair.Value;
                else
                    Return.DomIDObjects.Add(Pair.Key, Pair.Value);
            }
            foreach (KeyValuePair<string, CSSObjectData> Pair in CSS2.OtherObjects)
            {
                if (Return.OtherObjects.ContainsKey(Pair.Key))
                    Return.OtherObjects[Pair.Key] = Pair.Value;
                else
                    Return.OtherObjects.Add(Pair.Key, Pair.Value);
            }
            return Return;
        }

        CSSObjectData this[CSSBasicType Type, string Name]
        {
            get
            {
                switch (Type)
                {
                    case CSSBasicType.Class:
                        if (ClassObjects.ContainsKey(Name))
                            return ClassObjects[Name];
                        break;
                    case CSSBasicType.HTMLSelector:
                        if (HTMLObjects.ContainsKey(Name))
                            return HTMLObjects[Name];
                        break;
                    case CSSBasicType.DomID:
                        if (DomIDObjects.ContainsKey(Name))
                            return DomIDObjects[Name];
                        break;
                    case CSSBasicType.Other:
                        if (OtherObjects.ContainsKey(Name))
                            return OtherObjects[Name];
                        break;
                    default:
                        throw new Exception("Not a Valid type.");
                }
                return null;
            }
            set
            {
                switch (Type)
                {
                    case CSSBasicType.Class:
                        if (ClassObjects.ContainsKey(Name))
                            ClassObjects[Name] = value;
                        else
                            ClassObjects.Add(Name, value);
                        break;
                    case CSSBasicType.DomID:
                        if (DomIDObjects.ContainsKey(Name))
                            DomIDObjects[Name] = value;
                        else
                            DomIDObjects.Add(Name, value);
                        break;
                    case CSSBasicType.HTMLSelector:
                        if (HTMLObjects.ContainsKey(Name))
                            HTMLObjects[Name] = value;
                        else
                            HTMLObjects.Add(Name, value);
                        break;
                    case CSSBasicType.Other:
                        if (OtherObjects.ContainsKey(Name))
                            OtherObjects[Name] = value;
                        else
                            OtherObjects.Add(Name, value);
                        break;
                    default:
                        throw new Exception("Not a Valid type.");
                }
            }
        }
    }
}
