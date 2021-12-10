using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerringsprøveSolid_Bistanden
{
    /// <summary>
    /// An interface for GatheringBees SO they know they need to have a produce method
    /// </summary>
    public interface IProduce
    {
        /// <summary>
        /// Honey Producing method
        /// </summary>
        void ProduceHoney(object callback);
    }
}
