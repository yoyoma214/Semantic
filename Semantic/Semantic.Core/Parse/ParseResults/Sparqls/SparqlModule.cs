using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Common;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    public class SparqlModule : ParseModuleBase
    {
        public SparqlModule()
            : base()
        {
            //this.Mapings = new List<MappingInfo>();
            this.UsingNameSpaces = new Dictionary<string, string>();
            //this.Models = new Dictionary<string, ModelInfo>();
        }

        public QueryUnit Root { get; set; }

        public override void Initialize()
        {
            //this.Root.Parse();
            //this.Root.Wise();
            this.Errors.AddRange(Root.Errors);
        }

        public void GenCSharp(IndentStringBuilder builder)
        {
            //this.Root.GenCSharp(builder);
        }

        public void GenVisitCSharp(IndentStringBuilder builder)
        {
            //this.Root.GenVisitCSharp(builder);
        }

        public override Parser.ParseType ParseType
        {
            get
            {
                return Parser.ParseType.SparqlModel;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
