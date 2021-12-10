using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgrammerringsprøveSolid_Bistanden
{
    class GatherBee : Bee, IGather
    {
        public GatherBee(IBeehiveManager beehive) : base(beehive)
        {
        }

        public void GatherNectar(object callback)
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(100,501));
            this.honeyStomachFull = true;
            this.beehives.EnqueueGatherWithNectar(this);
        }

        public void EmptyHoneyStomach()
        {
            honeyStomachFull = false;
        }
    }
}
