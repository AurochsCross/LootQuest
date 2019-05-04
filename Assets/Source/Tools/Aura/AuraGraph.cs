using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura {
    [CreateAssetMenu(menuName = "Tools/Abiities/Aura Graph")]
    public class AuraGraph : NodeGraph {
        public Nodes.AuraMasterNode MasterNode = null;

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
                return new LootQuest.Models.Action.Aura.Trigger(x.Type, x.GetActionRoot());
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


        private List<Nodes.Trigger> GetTriggers() {
            return MasterNode.GetOutputPort("Triggers").GetConnections().Where(x => x.node is Nodes.Trigger).Select(x => x.node as Nodes.Trigger).ToList();
        }

        private List<Nodes.CompletionConditions.CompletionCondition> GetCompletionConditionNodes() {
            return GetCompletionNodesByPort("CompletionConditions");
        }

        private List<Nodes.CompletionConditions.CompletionCondition> GetDestroyNodes() {
            return GetCompletionNodesByPort("DestroyConditions");
        }
 
        private List<Nodes.CompletionConditions.CompletionCondition> GetCompletionNodesByPort(string portName) {
            return MasterNode.GetInputPort(portName).GetConnections()
                .Where(x => x.node is Nodes.CompletionConditions.CompletionCondition)
                .Select(x => (Nodes.CompletionConditions.CompletionCondition)x.node ).ToList();
        }

        [ContextMenu("Test graph")]
        private void TestGraph() {
            ConvertToModel();
        }
    }
}
