using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Common;
using CodeHelper.Core.Editor;

namespace CodeHelper.Core.Parse.ParseResults.Swrls
{
    public class SwrlModule : ParseModuleBase
    {
        public SwrlModule()
            : base()
        {
            //this.Mapings = new List<MappingInfo>();
            this.UsingNameSpaces = new Dictionary<string, string>();
            this.Variables = new List<string>();
            //this.Models = new Dictionary<string, ModelInfo>();
        }

        public Axioms Root { get; set; }

        public List<String> Variables { get; set; }

        public MyCaret Caret { get; set; }

        public override void Initialize()
        {
            var context = new SwrlContext();
            context.File = this.File;
            context.FileId = this.FileId;
            this.Root.Parse(context);
            this.Root.Wise(context);
            this.Errors.AddRange(Root.Errors);
            this.Errors.AddRange(context.Errors);

            //if (context.Base != null)
            //    this.Base = context.Base.Value;

            //foreach (var pre in context.Prefixs)
            //    this.UsingNameSpaces.Add(pre.Name, pre.Value);

            //this.Variables.AddRange(context.Variables);

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
                return Parser.ParseType.SwrlModel;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
