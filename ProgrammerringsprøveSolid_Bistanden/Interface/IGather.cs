using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerringsprøveSolid_Bistanden
{
    /// <summary>
    /// An interface for GatheringBees SO they know they need to gather Nectar
    /// </summary>
    public interface IGather
    {
        /// <summary>
        /// Method For Gathering Nectar
        /// </summary>
        public void GatherNectar(object callback);
        public void EmptyHoneyStomach();
    }
}
