using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Frontend.Effects.Aura.Debug {
    public class BasicPoisonAuraEffect : AuraEffectBase {

        public GameObject Vial;
        public ParticleSystem BubbleParticles;
        public MeshRenderer SplatRenderer;
        private Material _mainMaterial;

        void Awake() {
            _mainMaterial = SplatRenderer.material;
        }

        protected override void EffectSetup() {
            base.EffectSetup();
            _mainMaterial.SetFloat("_SplatVisibility", 0f);
            transform.position = _caster.transform.position;
            DOTween.To(x => _mainMaterial.SetFloat("_SplatVisibility", x), 0f, 1f, 1f).SetDelay(0.5f);
        }

        public override void OnCreated(object sender, LootQuest.Models.Events.AuraEventArgs args) {

        }

        public override void OnCompleted(object sender, LootQuest.Models.Events.AuraEventArgs args) {
                DOTween.To(x => _mainMaterial.SetFloat("_SplatVisibility", x), 1f, 0f, 1f);
                BubbleParticles.Stop();
        }

        public override void OnDestroyed(object sender, LootQuest.Models.Events.AuraEventArgs args) {
                DOTween.To(x => _mainMaterial.SetFloat("_SplatVisibility", x), 1f, 0f, 1f);
                BubbleParticles.Stop();
        }
    }
}
