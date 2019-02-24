using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.ActionBuilder {
    [CreateAssetMenu(menuName = "Tools/Abilities/Ability Graph")]
    public class AbilityGraph : NodeGraph { 
        public Models.Action.ActionRoot GetAction() {
            var actionNode = nodes.Where(x => x.GetType() == typeof(Nodes.ActionNode)).First() as Nodes.ActionNode;

            var effectNodes = actionNode.GetEffectNodes();

            var effects = effectNodes.Select(x => x.GetActionEffect()).ToArray();

            var action = new Models.Action.ActionRoot();
            action.effects = effects;
            action.id = actionNode.graph.GetInstanceID();
            action.name = actionNode.actionName;
            action.description = actionNode.actionDescription;

            return action;
        }
    }
}