using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgrammerringsprøveSolid_Bistanden
{
    /// <summary>
    /// BeehiveManager is for managing pretty much the whole beehive
    /// </summary>
    public class BeehiveManager : IBeehiveManager
    {
        private IBeehive beehive;
        private List<Bee> beelist;
        public IBeehive Beehive {  get { return beehive; } }

        /// <summary>
        /// Creates Behive Manager with 1000 bees
        /// </summary>
        public BeehiveManager()
        {
            for (int i = 0; i < 633; i++)
            {
                beelist.Add(new GatherBee(this));
            }
            for (int i = 0; i < 333; i++)
            {
                beelist.Add(new ProductionBee(this));
            }
            beehive = new Beehive(beelist);
        }

        public void DequeueGatherWithoutNectar()
        {
            while (true)
            {
                while (beehive.GathersReadyForFlight.Count == 0)
                {
                    Monitor.Wait(beehive.GathersReadyForFlight);
                }
                Monitor.Enter(beehive.GathersReadyForFlight);
                try
                {
                    ThreadPool.QueueUserWorkItem(beehive.GathersReadyForFlight.Dequeue().GatherNectar);
                }
                finally
                {

                    Monitor.Exit(beehive.GathersReadyForFlight);
                    Monitor.PulseAll(beehive.GathersReadyForFlight);
                }

            }
        }

        public void DequeueWorkerReadyToWorkWithGather()
        {
            IGather gather;
            IProduce produce;
            while (true)
            {
                while (beehive.GathersForDelivery.Count == 0 && beehive.ProduceresReadyToHelp.Count == 0)
                {
                    Monitor.Wait(beehive.GathersForDelivery);
                }
                Monitor.Enter(beehive.GathersForDelivery); 
                try
                {
                    gather = this.beehive.GathersForDelivery.Dequeue();
                }
                finally
                {
                    Monitor.Exit(beehive.GathersForDelivery);
                }
                Monitor.Enter(beehive.ProduceresReadyToHelp);
                try
                {
                    produce = this.beehive.ProduceresReadyToHelp.Dequeue();
                }
                finally
                {
                    Monitor.Exit(beehive.GathersForDelivery);
                }
                gather.EmptyHoneyStomach();
                ThreadPool.QueueUserWorkItem(produce.ProduceHoney);
                Monitor.Enter(beehive.GathersReadyForFlight);
                try
                {
                    beehive.GathersReadyForFlight.Enqueue(gather);
                }
                finally
                {
                    Monitor.Exit(beehive.GathersReadyForFlight);
                    Monitor.PulseAll(beehive.GathersReadyForFlight);
                }
            }
        }

        public void EnqueueGatherWithNectar(IGather gather)
        {
            this.beehive.ABeeFlewThrough();
            this.beehive.GathersForDelivery.Enqueue(gather);
        }

        public void EnqueueNotWorkingProducer(IProduce produce)
        {
            this.beehive.ProduceresReadyToHelp.Enqueue(produce);
        }
    }
}
