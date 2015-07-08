using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.TurtleModel
{
    public class NewTurtleModelCommand: BaseCommand
    {
        public string File { get; set; }

        public override string Name
        {
            get
            {
                return Dict.Commands.NewTurtleModel;
            }
        }

        //IReceiver Receiver = null;

        public NewTurtleModelCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.OpenFile(this.File);
        }
    }
}
