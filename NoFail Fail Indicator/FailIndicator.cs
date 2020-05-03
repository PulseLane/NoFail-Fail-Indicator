using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoFail_Fail_Indicator
{
    class FailIndicator : MonoBehaviour
    {
        public static FailIndicator instance { get; private set; }
        protected GameEnergyCounter _gameEnergyCounter;
        protected LevelFailedTextEffect _levelFailedTextEffect;
        protected float _energy;
        protected float _effectTime;
        protected bool _hasFailed = false;

        public void Awake()
        {
            instance = this;
            _gameEnergyCounter = Resources.FindObjectsOfTypeAll<GameEnergyCounter>().FirstOrDefault();
            _levelFailedTextEffect = Resources.FindObjectsOfTypeAll<LevelFailedTextEffect>().FirstOrDefault();
            _energy = _gameEnergyCounter.energy;
            _effectTime = Config.effectTime;
        }

        public bool GetNoFail()
        {
            return _gameEnergyCounter.noFail;
        }

        public void AddEnergy(float value)
        {
            // Can't have either insta-fail or bar energy w/ NoFail
            if (!_hasFailed)
            {
                if (value < 0f)
                {
                    _energy += value;
                    if (_energy <= 1E-05f)
                    {
                        _energy = 0f;
                        _hasFailed = true;
                        base.StartCoroutine(this.ShowLevelFailedCoroutine());
                    }
                }
                else
                {
                    if (_energy >= 1f)
                    {
                        return;
                    }
                    _energy += value;
                    if (_energy >= 1f)
                    {
                        _energy = 1f;
                    }
                }
            }
        }

        private IEnumerator ShowLevelFailedCoroutine()
        {
            _levelFailedTextEffect.ShowEffect();
            yield return new WaitForSeconds(_effectTime);
            _levelFailedTextEffect.gameObject.SetActive(false);
            yield break;
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}
