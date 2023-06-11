using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Hippodrome
{
    public class HorseResult
    {
        public string name { get;set;}
        public double distanse { get;set;}
        public double leftToFinish { get;set;}
        public double time { get;set;}
        public HorseResult(string name, double distanse, double leftToFinish, double time)
        {
            this.name = name;
            this.distanse = distanse;
            this.leftToFinish = leftToFinish;
            this.time = time;
        }
    }
}

