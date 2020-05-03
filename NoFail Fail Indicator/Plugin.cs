using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Utilities;
using NoFail_Fail_Indicator.UI;
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
            Config.Read();
            harmony = new Harmony("com.PulseLane.BeatSaber.NoFail_Fail_Indicator");
            try
            {
                harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
            } catch (Exception ex)
            {
                Logger.log.Error($"Failed to apply harmony patches! {ex}");
            }

            BS_Utils.Utilities.BSEvents.gameSceneLoaded += OnGameSceneLoaded;
            BSMLSettings.instance.AddSettingsMenu("NoFail Fail Indicator", "NoFail_Fail_Indicator.UI.settings.bsml", Settings.instance);
        }

        [OnDisable]
        public void OnDisable()
        {
            harmony.UnpatchAll("com.PulseLane.BeatSaber.NoFail_Fail_Indicator");
            BS_Utils.Utilities.BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
            BSMLSettings.instance.RemoveSettingsMenu(Settings.instance);
        }


        private void OnGameSceneLoaded()
        {
            if (Config.enabled)
                new GameObject("NoFail_Fail_Indicator").AddComponent<FailIndicator>();
        }
    }
}
