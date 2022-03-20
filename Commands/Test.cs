using CommandSystem;
using Qurre.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Commands
{
    public class Test : ICommand
    {
        public string Command => "Test";

        public string[] Aliases => new string[] { "test" };

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player Sender = Player.Get((CommandSender)sender);
            Sender.ShowHint(Plugin.CustomConfig.MVP_Message.Replace("{mvpname}", EventHandlers.GetMVPPlayer().Nickname), false, float.Parse(arguments.ToArray()[0]));
            response = "done";
            return true;
        }
    }
}
