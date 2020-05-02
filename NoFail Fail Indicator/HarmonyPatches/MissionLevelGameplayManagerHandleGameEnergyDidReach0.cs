using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace NoFail_Fail_Indicator.HarmonyPatches
{
    // Are there even any campaigns that put a level in NF?
    [HarmonyPatch(typeof(MissionLevelGameplayManager), "HandleGameEnergyDidReach0")]
    class MissionLevelGameplayManagerHandleGameEnergyDidReach0
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
