using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura {
    [CreateAssetMenu(menuName = "LootQuest/Graphs/Aura")]
    public class AuraGraph : NodeGraph {
        public AuraMaster MasterNode = null;

        public LootQuest.Models.Action.Aura.AuraRoot ConvertToModel() {
            if (MasterNode == null)
                return null;

            var completionConditions = GetCompletionConditionNodes().Select(x => {
                return new LootQuest.Models.Action.Aura.CompletionCondition(x.Caster, x.Type, x.GetValue());
            }).ToList();

            var destroyConditions = GetDestroyNodes().Select(x => {
                return new LootQuest.Models.Action.Aura.CompletionCondition(x.Caster, x.Type, x.GetValue());
            }).ToList();

            var triggers = GetTriggers().Select(x => {
                return new LootQuest.Models.Action.Aura.Trigger(x.Type, x.GetActionRoot(), x.RepeatTime);
            }).ToList();

            var aura = new LootQuest.Models.Action.Aura.AuraRoot(completionConditions, destroyConditions, triggers);
            if(MasterNode.OverridesDamage) {
                aura.AddDamageOverride(MasterNode.GetInputValue<string>("DamageOverrideFormula", MasterNode.DamageOverrideFormula));
            }

            if(MasterNode.OverridesHealing) {
                aura.AddHealingOverride(MasterNode.GetInputValue<string>("HealingOverrideFormula", MasterNode.HealingOverrideFormula));
            }

            aura.AddRepresentable(this);

            return aura;
        }


        private List<Trigger> GetTriggers() {
            return MasterNode.GetOutputPort("Triggers").GetConnections().Where(x => x.node is Trigger).Select(x => x.node as Trigger).ToList();
        }

        private List<CompletionCondition> GetCompletionConditionNodes() {
            return GetCompletionNodesByPort("CompletionConditions");
        }

        private List<CompletionCondition> GetDestroyNodes() {
            return GetCompletionNodesByPort("DestroyConditions");
        }
 
        private List<CompletionCondition> GetCompletionNodesByPort(string portName) {
            return MasterNode.GetInputPort(portName).GetConnections()
                .Where(x => x.node is CompletionCondition)
                .Select(x => (CompletionCondition)x.node ).ToList();
        }

        [ContextMenu("Test graph")]
        private void TestGraph() {
            ConvertToModel();
        }
    }
}
