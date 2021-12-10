using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerringsprøveSolid_Bistanden
{
    /// <summary>
    /// An interface, for every certatin part of how the behive should be managed
    /// </summary>
    public interface IBeehiveManager
    {
        /// <summary>
        /// Enqueus a gather with honey stomach filled
        /// </summary>
        public void EnqueueGatherWithNectar(IGather gather);
        /// <summary>
        /// Dequeue from a list to create takeoff
        /// </summary>
        public void DequeueGatherWithoutNectar();
        /// <summary>
        /// Enqueue producer when it is not working
        /// </summary>
        public void EnqueueNotWorkingProducer(IProduce produce);
        /// <summary>
        ///dequeue producer that is taking a gather and wait for both a gather with nectar and a free producer to help
        /// </summary>
        public void DequeueWorkerReadyToWorkWithGather();
    }
}
