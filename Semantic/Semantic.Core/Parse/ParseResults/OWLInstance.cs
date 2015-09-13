using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class PropertyValue
    {
        public OWLProperty Property { get; set; }

        public Object Value { get; set; }

        public TokenPair TokenPair { get; set; }
    }

    public class OWLInstance
    {
        public string Name { get; set; }

        public string NameSpace { get; set; }

        public string FullName { get; set; }

        public TypeInfoBase Type { get; set; }

        public List<PropertyValue> PropertyValues { get; set; }

        public TokenPair TokenPair { get; set; }

        public OWLInstance()
        {
            this.PropertyValues = new List<PropertyValue>();
        }
    }
}
