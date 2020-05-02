using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace NoFail_Fail_Indicator.HarmonyPatches
{
    [HarmonyPatch(typeof(GameEnergyCounter), "AddEnergy")]
    class GameEnergyCounterAddEnergy
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> newInstructions = new List<CodeInstruction>(instructions);

            // Too lazy to do this another way for now
            newInstructions[3] = new CodeInstruction(OpCodes.Nop);

            return newInstructions;
        }
    }
}
