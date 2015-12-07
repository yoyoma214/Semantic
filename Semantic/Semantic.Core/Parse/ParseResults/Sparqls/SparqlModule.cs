using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Common;
using CodeHelper.Core.Editor;

namespace CodeHelper.Core.Parse.ParseResults.Sparqls
{
    public class SparqlModule : ParseModuleBase
    {
        public SparqlModule()
            : base()
        {
            //this.Mapings = new List<MappingInfo>();
            this.UsingNameSpaces = new Dictionary<string, string>();
            this.Variables = new List<string>();
            //this.Models = new Dictionary<string, ModelInfo>();
        }

        public QueryUnit Root { get; set; }

        public List<String> Variables { get; set; }

        public MyCaret Caret { get; set; }

        public override void Initialize()
        {
            var context = new SparqlContext();
            context.File = this.File;
            context.FileId = this.FileId;
            context.Caret = this.Caret;
            this.Root.Parse(context);

            this.PrevSubject = context.PrevSubject;
            this.PrevVerbObjects = context.PrevVerbObjects;

            this.Subject = context.Subject;
            this.Verb = context.Verb;
            this.Object = context.Object;

            this.Root.Wise(context);
            this.Errors.AddRange(Root.Errors);
            this.Errors.AddRange(context.Errors);
            this.Fake = context.MatchByFake;

            if ( context.Base != null )
                this.Base = context.Base.Value;

            foreach (var pre in context.Prefixs)
                this.UsingNameSpaces.Add(pre.Name, pre.Value);

            this.Variables.AddRange(context.Variables);

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
