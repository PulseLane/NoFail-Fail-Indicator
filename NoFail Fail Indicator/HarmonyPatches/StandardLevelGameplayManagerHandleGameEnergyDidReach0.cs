using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace NoFail_Fail_Indicator.HarmonyPatches
{
    [HarmonyPatch(typeof(StandardLevelGameplayManager), "HandleGameEnergyDidReach0")]
    class StandardLevelGameplayManagerHandleGameEnergyDidReach0
    {
        static bool Prefix(StandardLevelGameplayManager __instance)
        {

            if (Indicator.instance.getNoFail())
            {
                Indicator.instance.showLevelFailed();
                return false;
            }

            return true;
        }
    }
}
