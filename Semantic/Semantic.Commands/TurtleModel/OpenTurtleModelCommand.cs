using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.TurtleModel
{
    public class OpenTurtleModelCommand: BaseCommand
    {
        public string File { get; set; }

        public override string Name
        {
            get
            {
                return Dict.Commands.OpenTurtleModel;
            }
        }

        IReceiver Receiver = null;

        public OpenTurtleModelCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.OpenFile(this.File);
        }
    }
}
