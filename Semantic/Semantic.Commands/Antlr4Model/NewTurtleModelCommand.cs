using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.Antlr4Model
{
    public class NewAntlr4ModelCommand: BaseCommand
    {
        public string File { get; set; }

        public override string Name
        {
            get
            {
                return Dict.Commands.NewAntlr4Model;
            }
        }

        //IReceiver Receiver = null;

        public NewAntlr4ModelCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.OpenFile(this.File);
        }
    }
}
