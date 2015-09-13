﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor;

namespace CodeHelper.Core.Parse.ParseResults.Turtles
{
    public class TurtleModule : ParseModuleBase
    {
        public TurtleModule()
            : base()
        {
            //this.Mapings = new List<MappingInfo>();
            this.UsingNameSpaces = new Dictionary<string, string>();
            //this.Models = new Dictionary<string, ModelInfo>();
        }

        public TurtleDoc Root { get; set; }

        public Caret Caret { get; set; }

        public override void Initialize()
        {
            var context = new TurtleContext();
            context.Caret = Caret;
            this.Root.Parse(context);

            this.Subject = context.Subject;
            this.Verb = context.Verb;
            this.Object = context.Object;

            this.Types = context.Types;
            this.Properties = context.Properties;
            this.Instances = context.Instances;

            this.Errors.AddRange(Root.Errors);
            this.NameSpace = context.NameSpace;
            this.UsingNameSpaces = context.Imports;
        }

        public override Parser.ParseType ParseType
        {
            get
            {
                return Parser.ParseType.TurtleModel;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
