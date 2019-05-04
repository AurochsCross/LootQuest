using UnityEngine;

namespace Frontend.Effects.Aura {
    public class AuraEffectBase: MonoBehaviour {

        private LootQuest.Logic.Actions.AuraHandler _aura;
        protected Entity.EntityMaster _caster;

        protected bool _isEffectSetup = false;

        public void Setup(LootQuest.Logic.Actions.AuraHandler aura) {
            _aura = aura;
            _caster = aura.Caster.Master.GetRepresentable<Entity.EntityMaster>();
            SubscribeEvents();
            EffectSetup();
        }

        private void SubscribeEvents() {
            _aura.OnCreation += OnCreated;
            _aura.OnCompletion += OnCompleted;
            _aura.OnDestruction += OnDestroyed;
            _aura.OnTrigger += OnTrigger;
            
            _aura.OnCompletion += OnFinished;
            _aura.OnDestruction += OnFinished;
        }

        private void UnsubscribeEvents() {
            _aura.OnCreation -= OnCreated;
            _aura.OnCompletion -= OnCompleted;
            _aura.OnDestruction -= OnDestroyed;
            _aura.OnTrigger -= OnTrigger;
            
            _aura.OnCompletion -= OnFinished;
            _aura.OnDestruction -= OnFinished;
        }

        protected virtual void EffectSetup() {
            if (_isEffectSetup) {
                return;
            }

            _isEffectSetup = true;
        }

        public virtual void OnCreated(object sender, LootQuest.Models.Events.AuraEventArgs args) {

        }

        public virtual void OnCompleted(object sender, LootQuest.Models.Events.AuraEventArgs args) {

        }

        public virtual void OnDestroyed(object sender, LootQuest.Models.Events.AuraEventArgs args) {

        }

        public virtual void OnTrigger(object sender, LootQuest.Models.Events.AuraEventArgs args) {

        }

        private void OnFinished(object sender, LootQuest.Models.Events.AuraEventArgs args) {
            UnsubscribeEvents();
        }
    }
}