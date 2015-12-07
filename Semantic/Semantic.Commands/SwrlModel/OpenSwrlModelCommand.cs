using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.Swrl
{
    public class OpenSwrlModelCommand: BaseCommand
    {
        public string File { get; set; }

        public override string Name
        {
            get
            {
                return Dict.Commands.OpenSwrlModel;
            }
        }

        IReceiver Receiver = null;

        public OpenSwrlModelCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.OpenFile(this.File);
        }
    }
}
