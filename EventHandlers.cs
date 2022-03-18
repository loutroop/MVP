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
        public static Dictionary<Player, int> KillCounts = new Dictionary<Player, int>();
        public void OnWaiting()
        {
            KillCounts.Clear();
        }
        public void OnRoundEnd(RoundEndEvent ev)
        {
            AddValues();
            foreach (var player in Player.List)
            {
                Timing.CallDelayed(Plugin.CustomConfig.MonmentToShow, () => player.ShowHint(Plugin.CustomConfig.MVP_Message.Replace("{mvpname}", GetMVPPlayer().Nickname), 2));
                foreach (var data in Plugin.CustomConfig.RecordDatas)
                {
                    if (data.ContainsKey(GetMVPPlayer().UserId)) new Audio(data[GetMVPPlayer().UserId].Item1, data[GetMVPPlayer().UserId].Item2, data[GetMVPPlayer().UserId].Item3);
                }
            }
        }
       public Player GetMVPPlayer()
        {
            return KillCounts.Max().Key;
        }
        private static IEnumerator<float> AddValues()
        {
            yield return Timing.WaitForSeconds(0.5f);
            foreach (var player in Player.List)
            {
                KillCounts.Add(player, player.KillsCount);
            }
        } 
    }
}
