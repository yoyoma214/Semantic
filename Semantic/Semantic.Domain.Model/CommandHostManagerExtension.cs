using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;
using CodeHelper.Commands.DataModel;
using CodeHelper.Commands.XmlModel;
using CodeHelper.Commands.ViewModel;
using CodeHelper.Commands.WorkFlow;
using CodeHelper.Commands.TurtleModel;
using CodeHelper.Commands.SparqlModel;
using CodeHelper.Commands.Antlr4Model;

namespace CodeHelper.Domain.Model
{
    public static class CommandHostManagerExtension
    {
        public static void OpenFile( this CommandHostManager mgr, string file)
        {
            var extension = System.IO.Path.GetExtension(file);
            if (extension == Dict.Extenstions.DataModel_Extension)
            {
                var host = CommandHostManager.Instance().Get(CommandHostManager.HostType.DataModel);

                var cmd = host.GetCommand(Dict.Commands.OpenDataModel)
                     as OpenDataModelCommand;

                cmd.File = file;

                cmd.Execute();

                return;
            }
            if (extension == Dict.Extenstions.XmlModel_Extension)
            {
                var host = CommandHostManager.Instance().Get(CommandHostManager.HostType.XmlMode);

                var cmd = host.GetCommand(Dict.Commands.OpenXmlModel)
                     as OpenXmlModelCommand;

                cmd.File = file;

                cmd.Execute();

                return;
            }

            if (extension == Dict.Extenstions.ViewModel_Extension)
            {
                var host = CommandHostManager.Instance().Get(CommandHostManager.HostType.ViewModel);

                var cmd = host.GetCommand(Dict.Commands.OpenViewModel)
                     as OpenViewModelCommand;

                cmd.File = file;

                cmd.Execute();

                return;
            }

            if (extension == Dict.Extenstions.WorkFlow_Extension)
            {
                var host = CommandHostManager.Instance().Get(CommandHostManager.HostType.WorkFlow);

                var cmd = host.GetCommand(Dict.Commands.OpenWorkFlow)
                     as OpenWorkFlowCommand;

                cmd.File = file;

                cmd.Execute();

                return;
            }

            if (extension == Dict.Extenstions.Turtle_Extension)
            {
                var host = CommandHostManager.Instance().Get(CommandHostManager.HostType.OWL);

                var cmd = host.GetCommand(Dict.Commands.OpenTurtleModel)
                     as OpenTurtleModelCommand;

                cmd.File = file;

                cmd.Execute();

                return;
            }

            if (extension == Dict.Extenstions.Sparql_Extension)
            {
                var host = CommandHostManager.Instance().Get(CommandHostManager.HostType.OWL);

                var cmd = host.GetCommand(Dict.Commands.OpenSparqlModel)
                     as OpenSparqlModelCommand;

                cmd.File = file;

                cmd.Execute();

                return;
            }

            if (extension == Dict.Extenstions.Antlr4_Extension)
            {
                var host = CommandHostManager.Instance().Get(CommandHostManager.HostType.OWL);

                var cmd = host.GetCommand(Dict.Commands.OpenAntlr4Model)
                     as OpenAntlr4ModelCommand;

                cmd.File = file;

                cmd.Execute();

                return;
            }

            throw new Exception("在打开不支持的文件");
        }
    }
}
