using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Frontend.Effects.Aura.Debug {
    public class BasicAuraEffect : AuraEffectBase {

        private Material _mainMaterial;

        void Awake() {
            _mainMaterial = gameObject.GetComponent<MeshRenderer>().material;
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
            }
            if (Input.GetKeyDown(KeyCode.T)) {
                DOTween.To(x => _mainMaterial.SetFloat("_Fill", x), 1f, 0f, 1f);
            }

            if (Input.GetKeyDown(KeyCode.U)) {
                DOTween.To(x => _mainMaterial.SetFloat("_HitAmount", x), 0f, 1f, 0.3f);
            }
        }

        protected override void EffectSetup() {
            base.EffectSetup();
            transform.position = _caster.transform.position;
            DOTween.To(x => _mainMaterial.SetFloat("_Fill", x), 0f, 1f, 1f);
        }

        public override void OnCreated(object sender, LootQuest.Models.Events.AuraEventArgs args) {

        }

        public override void OnCompleted(object sender, LootQuest.Models.Events.AuraEventArgs args) {
                DOTween.To(x => _mainMaterial.SetFloat("_Fill", x), 1f, 0f, 1f);

        }

        public override void OnDestroyed(object sender, LootQuest.Models.Events.AuraEventArgs args) {
                DOTween.To(x => _mainMaterial.SetFloat("_Fill", x), 1f, 0f, 1f);

        }

        public override void OnTrigger(object sender, LootQuest.Models.Events.AuraEventArgs args) {
                DOTween.To(x => _mainMaterial.SetFloat("_HitAmount", x), 0f, 1f, 0.3f);
        }
    }
}
