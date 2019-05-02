using UnityEngine;
using System.Linq;

namespace Frontend.Entity {
    public class EntityEffectMaster: MonoBehaviour {
        public void Setup() {
            gameObject.GetComponent<EntityMaster>().Master.BattleCommander.OnEffectExecution += OnActionEffect;
        }

        private void OnActionEffect(object sender, LootQuest.Models.Events.EffectExecutionArgs args) {
            var actionGraph = args.Action.GetRepresentable<Tools.ActionBuilder.Nodes.ActionNode>();
            var effect = actionGraph.GetEffectNodes()[args.EffectIndex];
            
            var effectTemplates = args.IsWindupEffect ? effect.WindupEffects : effect.Effects;

            effectTemplates.ForEach(x => {
                if (x != null) {
                    var effectGO = Instantiate(x) as GameObject;
                    var battleEffect = effectGO.GetComponent<Battle.Effects.BattleEffect>();

                    battleEffect.Setup(transform, Frontend.Master.Shared.BattleManager.Participants.Where(y => y != null).First(y => y.Master == args.Subject).transform);
                }
            });
        }
    }
}