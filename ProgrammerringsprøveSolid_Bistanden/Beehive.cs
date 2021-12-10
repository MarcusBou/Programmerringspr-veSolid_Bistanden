using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerringsprøveSolid_Bistanden
{
    /// <summary>
    /// A Beehive with alot of queues for controlling the beehive better, and the counter for flowers and honey
    /// </summary>
    public class Beehive: IBeehive
    {
        private long beesFlownThroughWithNectar;
        private long beesNeededToFlyThroughToMakeHoney;
        private long honeyCreated;
        private Queue<IGather> gathersForDelivery = new Queue<IGather>();
        private Queue<IGather> gathersReadyForFlight = new Queue<IGather>();
        private Queue<IProduce> produceresReadyToHelp = new Queue<IProduce>();
        private List<Bee> bees;

        public Queue<IGather> GathersForDelivery { get {  return gathersForDelivery; } }
        public Queue<IGather> GathersReadyForFlight { get { return gathersReadyForFlight; } }
        public Queue<IProduce> ProduceresReadyToHelp { get { return produceresReadyToHelp; } }
        public long BeesFlownThroughWithNectar { get { return beesFlownThroughWithNectar; } }
        public long BeesNeededToFlyThroughToMakeHoney { get { return beesNeededToFlyThroughToMakeHoney; } }
        public long HoneyCreated { get { return honeyCreated; } }

        public Beehive(List<Bee> bee)
        {
            this.beesFlownThroughWithNectar = 0;
            this.beesNeededToFlyThroughToMakeHoney = 0;
            this.honeyCreated = 0;
            this.bees = bee;
        }

        public void ABeeFlewThrough()
        {
            this.beesFlownThroughWithNectar += 1;
            this.beesNeededToFlyThroughToMakeHoney -= 1;
            ProducedHoney();
        }

        public void ProducedHoney()
        {
            if (this.beesNeededToFlyThroughToMakeHoney == 0)
            {
                this.honeyCreated += 1;
            }
        }
    }
}
