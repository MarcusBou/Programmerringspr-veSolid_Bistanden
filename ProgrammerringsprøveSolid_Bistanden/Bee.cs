using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerringsprøveSolid_Bistanden
{
    /// <summary>
    /// A Superclass for the bee, since every bee have a honey stomach and every bee KNOW where there beehive is, Biological speaking
    /// </summary>
    public abstract class Bee
    {
        protected bool honeyStomachFull;
        protected IBeehiveManager beehives;//Refers to Beehivemanager, because the manager is taking care of every single bee, instead of it just the beehive which is unlogical
        public bool HoneyStomachFull { get { return honeyStomachFull; } }
        public IBeehiveManager Beehives {  get { return beehives; } }
        
        public Bee(IBeehiveManager beehive)
        {
            this.beehives = beehive;
            this.honeyStomachFull = false;
        }
    }
}
