using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Frontend.Battle.UI {
    public class PawnInfo : MonoBehaviour {
        public Text NameLabel;
        public Slider HealthSlider;

        public int Hp {
            get {
                return _hp;
            }
            set {
                _hp = value;
                UpdateHealthbar();
            }
        }

        private string _name;
        private int _maxHp;
        private int _hp;

        public void SetupInfo(string name, int maxHp) {
            NameLabel.text = name;
            _maxHp = maxHp;
            Hp = maxHp;
        }

        private void UpdateHealthbar() {
            HealthSlider.value = 1f / (float)_maxHp * (float)_hp;
        }
    }
}
