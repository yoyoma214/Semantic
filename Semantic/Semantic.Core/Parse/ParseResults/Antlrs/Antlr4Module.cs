using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Common;

namespace CodeHelper.Core.Parse.ParseResults.Antlrs
{
    public class Antlr4Module : ParseModuleBase
    {
        public Antlr4Module()
            : base()
        {
            //this.Mapings = new List<MappingInfo>();
            this.UsingNameSpaces = new Dictionary<string, string>();
            //this.Models = new Dictionary<string, ModelInfo>();
        }

        public GrammarSpec Root { get; set; }

        public override void Initialize()
        {
            this.Root.Parse();
            this.Root.Wise();
            this.Errors.AddRange(Root.Errors);
        }

        public void GenJava(IndentStringBuilder builder)
        {
            this.Root.GenJava(builder);
        }

        public void GenVisitJava(IndentStringBuilder builder)
        {
            this.Root.GenVisitJava(builder);
        }

        public override Parser.ParseType ParseType
        {
            get
            {
                return Parser.ParseType.Antlr4Model;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}