using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    public class Plugin : Qurre.Plugin
    {
        public override string Developer => "Qurre-Team";
        public override string Name => nameof(MVP);
        public override Version NeededQurreVersion => new Version(1, 12, 0);
        public override Version Version => new Version(0, 2);
        public EventHandlers Handlers;
        public static Config CustomConfig { get; private set; }
        public override void Disable()
        {
            Qurre.Events.Round.Waiting += Handlers.OnWaiting;
            Qurre.Events.Round.End += Handlers.OnRoundEnd;
            CustomConfigs.Clear();
        }

        public override void Enable()
        {
            CustomConfig = new Config();
            CustomConfigs.Add(CustomConfig);
            Handlers = new EventHandlers();
            Qurre.Events.Round.Waiting += Handlers.OnWaiting;
            Qurre.Events.Round.End += Handlers.OnRoundEnd;
        }
    }
}
