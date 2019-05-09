using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.HostileBehaviour {
    [CreateAssetMenu(menuName = "LootQuest/Graphs/Hostile Behaviour")]
    public class HostileBehaviourGraph : NodeGraph { 
        
        public Nodes.BehaviourStart BehaviourStart {
            get {
                var node = nodes.FirstOrDefault(x => x is Nodes.BehaviourStart) as Nodes.BehaviourStart;
                return node;
            }
        }
        public Nodes.BehaviourEnd BehaviourEnd {
            get {
                return nodes.FirstOrDefault(x => x is Nodes.BehaviourEnd) as Nodes.BehaviourEnd;
            }
        }

        public List<LootQuest.Models.Action.ActionRoot> GetActions() {
            Node currentNode = BehaviourStart.GetOutputPort("Next").GetConnection(0).node;
            //List<LootQuest.Models.Action.ActionRoot> actions = new List<LootQuest.Models.Action.ActionRoot>();
            
            var actionNodes = nodes.Where(x => x is Common.BehaviourActionUse).Select(x => ((Common.BehaviourActionUse)x).GetActionNode().GetAction()).ToList();
            return actionNodes;
        }
        
    }
}