using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgrammerringsprøveSolid_Bistanden
{
    class ProductionBee : Bee, IProduce
    {
        public ProductionBee(IBeehiveManager beehive) : base(beehive)
        {

        }

        public void ProduceHoney(object callback)
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(100, 701));
            this.beehives.EnqueueNotWorkingProducer();
        }
    }
}
