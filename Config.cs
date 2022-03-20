using Qurre.API.Addons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    public class Config : IConfig
    {
        public string Name { get; set; } = nameof(MVP);
        public float MonmentToShow { get; set; } = 1.5f;
        public string MVP_Message { get; set; } = "<voffset=15em>{mvpname} is the MVP in this round<voffset>";
        public Dictionary<string, Tuple<string, byte, bool>> RecordDatas { get; set; } = new Dictionary<string, Tuple<string, byte, bool>>()
        {
           { "Example", new Tuple<string, byte, bool>("", 10, true) }
        };
    }
}
