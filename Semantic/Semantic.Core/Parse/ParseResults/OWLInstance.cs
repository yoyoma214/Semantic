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

        public TokenPair Position { get; set; }
    }

    public class OWLInstance
    {
        public TypeInfoBase Type { get; set; }

        public List<PropertyValue> PropertyValues { get; set; }

        public TokenPair Position { get; set; }

        public OWLInstance()
        {
            this.PropertyValues = new List<PropertyValue>();
        }
    }
}
