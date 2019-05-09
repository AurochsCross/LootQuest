using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Action {
    [CreateAssetMenu(menuName = "LootQuest/Graphs/Action")]
    public class ActionGraph : NodeGraph { 
        public int Id { get { return GetInstanceID(); } }
        public Sprite Icon;

        public ActionMaster MainActionNode {
            get {
                return nodes.Where(x => x.GetType() == typeof(ActionMaster)).First() as ActionMaster;
            }
        }

        public ActionEffect[] EffectNodes { 
            get { 
                var actionNode = nodes.Where(x => x.GetType() == typeof(ActionMaster)).First() as ActionMaster;

                return actionNode.GetEffectNodes(); 
            }
        }
        public LootQuest.Models.Action.ActionRoot GetAction() {
            var actionNode = nodes.Where(x => x.GetType() == typeof(ActionMaster)).First() as ActionMaster;

            var effectNodes = actionNode.GetEffectNodes();

            var effects = effectNodes.Select(x => x.GetActionEffect()).ToArray();

            var action = new LootQuest.Models.Action.ActionRoot();
            action.effects = effects;
            action.id = actionNode.graph.GetInstanceID();
            action.name = actionNode.actionName;
            action.description = actionNode.actionDescription;
            action.AddRepresentable(actionNode);

            return action;
        }
    }
}