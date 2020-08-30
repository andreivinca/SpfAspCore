using System;
using System.Collections.Generic;
using System.Text;

namespace SpfAspCore
{
    public class SpfAspCoreConfiguration
    {
        public static SpfAspCoreConfiguration Current { get; set; }

        public bool SpfAspCoreEnabled { get; set; } = true;
    }
}
