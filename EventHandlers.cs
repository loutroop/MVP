using MEC;
using Qurre.API;
using Qurre.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    public class EventHandlers
    {
        public static Dictionary<Player, int> Points = new Dictionary<Player, int>();
        public void OnWaiting()
        {
            Points.Clear();
        }
        public void OnRoundEnd(RoundEndEvent ev)
        {
            foreach (var player in Player.List)
            {
                Timing.CallDelayed(Plugin.CustomConfig.MonmentToShow, () => player.ShowHint(Plugin.CustomConfig.MVP_Message.Replace("{mvpname}", GetMVPPlayer().Nickname), false, 2));
                if (Plugin.CustomConfig.RecordDatas.ContainsKey(GetMVPPlayer().UserId)) new Audio(Plugin.CustomConfig.RecordDatas[GetMVPPlayer().UserId].Item1, Plugin.CustomConfig.RecordDatas[GetMVPPlayer().UserId].Item2, Plugin.CustomConfig.RecordDatas[GetMVPPlayer().UserId].Item3);
            }
        }
       public static Player GetMVPPlayer()
        {
            return Points.Max().Key;
        }
        public void Join(JoinEvent ev)
        {
            Points.Add(ev.Player, 0);
        }
        public void Dies(DiesEvent ev)
        {
            if (ev.Target.Team == Team.SCP && ev.Target.Role != RoleType.Scp0492) Points[ev.Killer] += 5;
            else Points[ev.Killer] += 1;
        }
        
    }
}
