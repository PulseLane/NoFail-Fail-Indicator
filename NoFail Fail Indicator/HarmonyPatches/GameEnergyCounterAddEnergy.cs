using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace NoFail_Fail_Indicator.HarmonyPatches
{
    [HarmonyPatch(typeof(GameEnergyCounter), "AddEnergy")]
    class GameEnergyCounterAddEnergy
    {
        static void Prefix(float value)
        {

            if (Config.enabled && FailIndicator.instance.GetNoFail())
            {
                FailIndicator.instance.AddEnergy(value);
            }
        }
    }
}
