using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class OWLProperty : IWiseble
    {
        public string NameSpace { get; set; }
        public string Name { get; set; }
        public List<TypeInfoBase> Domain { get; set; }
        public List<TypeInfoBase> Range { get; set; }
        public OWLProperty Parent { get; set; }
        public TokenPair Position { get; set; }
        public bool IsObject { get; set; }

        public TokenPair TokenPair { get; set; }

        public OWLProperty()
        {
            this.Domain = new List<TypeInfoBase>();
            this.Range = new List<TypeInfoBase>();
        }

        public void Wise()
        {
            
        }
    }
}
