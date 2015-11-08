using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Types.Base
{
    class BaseXsdType : IXsdType, ITypeInfo
    {
        public const string UniType_Number = "number";
        public const string UniType_String = "string";
        public const string UniType_Boolean = "boolean";
        public const string UniType_Binary = "binary";
        public const string UniType_Iri = "iri";
        public const string UniType_Time = "time";
        public const string UniType_XmlLiteral = "xmlLiteral";

        public virtual string Name
        {
            get;
            set;
        }

        public virtual bool Wise(string verb)
        {
            return true;
        }

        public virtual string NameSpace
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string UniversalDataType
        {
            protected set;
            get;
        }

        public bool IsNumber()
        {
            return this.UniversalDataType == UniType_Number;
        }

        public bool IsString()
        {
            return this.UniversalDataType == UniType_String;
        }

        public bool IsBoolean()
        {
            return this.UniversalDataType == UniType_Boolean;
        }

        public bool IsBinary()
        {
            return this.UniversalDataType == UniType_Binary;
        }

        public bool IsIri()
        {
            return this.UniversalDataType == UniType_Iri;
        }

        public bool IsTime()
        {
            return this.UniversalDataType == UniType_Time;
        }

        public bool IsXmlLiteral()
        {
            return this.UniversalDataType == UniType_XmlLiteral;
        }


        public string FullName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Guid? FileId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<IRestrictPropertyInfo> PropertyInfos
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public bool IsPrimitive
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TokenPair TokenPair
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IRestrictPropertyInfo FindProperty(string name)
        {
            throw new NotImplementedException();
        }

        public ITypeInfo Super
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Wise()
        {
            throw new NotImplementedException();
        }

        public int Line
        {
            get { throw new NotImplementedException(); }
        }

        public int CharPositionInLine
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int EndCharPositionInLine
        {
            get { throw new NotImplementedException(); }
        }

        public int Length
        {
            get { throw new NotImplementedException(); }
        }

    }
}
