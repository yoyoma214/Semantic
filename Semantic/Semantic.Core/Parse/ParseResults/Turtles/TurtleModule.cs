using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.Turtles
{
    public class TurtleModule : ParseModuleBase
    {
        public TurtleModule()
            : base()
        {
            //this.Mapings = new List<MappingInfo>();
            this.UsingNameSpaces = new List<string>();
            //this.Models = new Dictionary<string, ModelInfo>();
        }

        public TurtleDoc Root { get; set; }

        public override void Initialize()
        {
            var context = new TurtleContext();
            this.Root.Parse(context);
            this.Errors.AddRange(Root.Errors);
        }
    }
}
