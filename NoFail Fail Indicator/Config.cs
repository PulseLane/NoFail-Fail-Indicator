using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFail_Fail_Indicator
{
    class Config
    {
        public static BS_Utils.Utilities.Config config = new BS_Utils.Utilities.Config("NoFail_Fail_Indicator");
        public static bool enabled = true;
        public static float effectTime = 2f;

        public static void Read()
        {
            enabled = config.GetBool("NoFail_Fail_Indicator", "enabled", true, true);
            effectTime = config.GetFloat("NoFail_Fail_Indicator", "effectTime", 2f, true);
        }

        public static void Write()
        {
            config.SetBool("NoFail_Fail_Indicator", "enabled", enabled);
            config.SetFloat("NoFail_Fail_Indicator", "effectTime", effectTime);
        }
    }
}
