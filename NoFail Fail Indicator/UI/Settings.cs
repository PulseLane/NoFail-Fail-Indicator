using BeatSaberMarkupLanguage.Attributes;

namespace NoFail_Fail_Indicator.UI
{
    class Settings : PersistentSingleton<Settings>
    {
        [UIValue("enabled")]
        public bool enabled
        {
            get => Config.enabled;
            set
            {
                Config.enabled = value;
                Config.Write();
            }
        }
        [UIValue("effectTime")]
        public float effectTime
        {
            get => Config.effectTime;
            set
            {
                Config.effectTime = value;
                Config.Write();
            }
        }
    }
}
