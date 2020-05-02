using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoFail_Fail_Indicator
{
    class Indicator : MonoBehaviour
    {
        public static Indicator instance { get; private set; }
        protected GameEnergyCounter _gameEnergyCounter;
        protected LevelFailedTextEffect _levelFailedTextEffect;

        public void Awake()
        {
            instance = this;
            _gameEnergyCounter = Resources.FindObjectsOfTypeAll<GameEnergyCounter>().FirstOrDefault();
            _levelFailedTextEffect = Resources.FindObjectsOfTypeAll<LevelFailedTextEffect>().FirstOrDefault();
        }

        public bool getNoFail()
        {
            return _gameEnergyCounter.noFail;
        }

        public void showLevelFailed()
        {
            // TODO: Hide this effect after some time
            _levelFailedTextEffect.ShowEffect();
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}
