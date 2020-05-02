using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Utilities;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace NoFail_Fail_Indicator
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Harmony harmony;

        [Init]
        public void Init(IPALogger logger)
        {
            Logger.log = logger;
        }

        [OnEnable]
        public void OnEnable()
        {
            harmony = new Harmony("com.PulseLane.BeatSaber.NoFail_Fail_Indicator");
            try
            {
                harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
                Logger.Log(":)");
            } catch (Exception ex)
            {
                Logger.Log($"Failed to apply harmony patches! {ex}");
            }

            BS_Utils.Utilities.BSEvents.gameSceneLoaded += OnGameSceneLoaded;
        }

        [OnDisable]
        public void OnDisable()
        {
            harmony.UnpatchAll("com.PulseLane.BeatSaber.NoFail_Fail_Indicator");
        }


        private void OnGameSceneLoaded()
        {
            new GameObject("NoFail_Fail_Indicator").AddComponent<Indicator>();
        }
    }
}
