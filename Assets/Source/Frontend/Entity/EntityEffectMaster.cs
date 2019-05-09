using UnityEngine;
using System.Linq;

namespace Frontend.Entity {
    public class EntityEffectMaster: MonoBehaviour {
        public void Setup() {
            gameObject.GetComponent<EntityMaster>().Master.BattleCommander.OnEffectExecution += OnActionEffect;
            gameObject.GetComponent<EntityMaster>().Master.BattleCommander.OnAuraPlaced += OnAuraPlaced;
        }

        private void OnActionEffect(object sender, LootQuest.Models.Events.EffectExecutionArgs args) {
            var actionGraph = args.Action.GetRepresentable<Tools.Action.ActionMaster>();
            var effect = actionGraph.GetEffectNodes()[args.EffectIndex];
            
            var effectTemplates = args.IsWindupEffect ? effect.GetWindupEffects() : effect.GetEffects();


            Debug.Log("Templates: ");
            foreach (var temp in effectTemplates) {
                Debug.Log(temp.TriggerName);
            }
            // TODO: Implement new effect system

            effectTemplates.ForEach(x => {
                if (x != null) {
                    var visualEffect = x as Tools.Action.ActionVisualEffect;
                    if (visualEffect.Type == Tools.Action.ActionVisualEffectType.AnimationTrigger || visualEffect.Type == Tools.Action.ActionVisualEffectType.SimpleAnimationTrigger) {
                        args.Source.GetRepresentable<Entity.EntityMaster>().AnimationManager.SetTrigger(visualEffect.TriggerName);
                    }


                    // var effectGO = Instantiate(x) as GameObject;
                    // var battleEffect = effectGO.GetComponent<Battle.Effects.BattleEffect>();

                    // battleEffect.Setup(transform, Frontend.Master.Shared.BattleManager.Participants.Where(y => y != null).First(y => y.Master == args.Subject).transform);
                }
            });
        }

        private void OnAuraPlaced(object sender, LootQuest.Models.Events.EffectExecutionArgs args) {
            if (sender is LootQuest.Logic.Actions.AuraHandler) {
                var auraHandler = sender as LootQuest.Logic.Actions.AuraHandler;
                var effect = auraHandler.Aura.GetRepresentable<Tools.Aura.AuraGraph>().MasterNode.AuraRepresentationEffect;

                if (effect != null) {
                    var effectGO = Instantiate(effect) as GameObject;
                    effectGO.GetComponent<Effects.Aura.AuraEffectBase>().Setup(auraHandler);
                }
            }
        }
    }
}