using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerringsprøveSolid_Bistanden
{
    public interface IBeehive
    {
        public Queue<IGather> GathersForDelivery { get; }
        public Queue<IGather> GathersReadyForFlight { get; }
        public Queue<IProduce> ProduceresReadyToHelp { get; }
        public long BeesFlownThroughWithNectar { get; }
        public long BeesNeededToFlyThroughToMakeHoney { get; }
        public long HoneyCreated { get; }

        /// <summary>
        /// for Counting bees
        /// </summary>
        public void ABeeFlewThrough();

        /// <summary>
        /// for Counting Honey
        /// </summary>
        public void ProducedHoney();
    }
}
