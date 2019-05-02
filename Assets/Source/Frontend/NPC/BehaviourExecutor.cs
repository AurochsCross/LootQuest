using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Frontend.NPC {
    public class BehaviourExecutor: MonoBehaviour {
        public Tools.HostileBehaviour.HostileBehaviourGraph BehaviourGraph;
        private LootQuest.Logic.Entity.Commanders.EquipmentCommander _equipmentCommander;
        private Frontend.Entity.EntityBattleMaster _battleMaster;

        void Start() {
            _equipmentCommander = gameObject.GetComponent<Entity.EntityMaster>().Master.EquipmentCommander;
            _battleMaster = gameObject.GetComponent<Entity.EntityBattleMaster>();
        }

        public void PrepareForExecution() {
            if (!this.enabled) {
                return;
            }
            
            List<LootQuest.Models.Action.ActionRoot> actions = BehaviourGraph.GetActions();
            var items = CreateEmptyActionItems(actions);

            items.ForEach(x => {
                _equipmentCommander.Equip(x);
            });
            StartCoroutine(ExecuteTimeline());
        }

        private List<LootQuest.Models.Items.ArmorItem> CreateEmptyActionItems(List<LootQuest.Models.Action.ActionRoot> actions) {
            return actions.Select(x => {
                LootQuest.Models.Items.ArmorItem item = new LootQuest.Models.Items.ArmorItem(Random.Range(100000, 999999), x.name + "_item", LootQuest.Models.Items.ArmorType.unlisted);
                item.attributes = new LootQuest.Models.Common.Attributes();
                item.action = x;
                Debug.Log("Type: " + x.effects[0].type);
                return item;
            }).ToList();
        }

        private IEnumerator ExecuteTimeline() {
            XNode.Node currentNode = BehaviourGraph.BehaviourStart;
            bool didReachedEnd = false;
            while (!didReachedEnd) {
                currentNode =  currentNode.GetOutputPort("Next").GetConnection(0).node;
                if (currentNode is Tools.HostileBehaviour.Nodes.Actions.BehaviourWait) {
                    var waitNode = currentNode as Tools.HostileBehaviour.Nodes.Actions.BehaviourWait;
                    Debug.Log("Wait time: " + waitNode.Time);
                    yield return new WaitForSeconds(waitNode.Time);
                    //await System.Threading.Tasks.Task.Delay((int)(waitNode.Time * 1000));
                } else if (currentNode is Tools.HostileBehaviour.Nodes.Actions.BehaviourActionUse) {
                    var actionNode = currentNode as Tools.HostileBehaviour.Nodes.Actions.BehaviourActionUse;
                    _battleMaster.UseAction(actionNode.GetActionNode().GetAction());
                } else {
                    didReachedEnd = true;
                }
            } 
            StartCoroutine(ExecuteTimeline());
        }

        public void StopBehaviour() {
            StopCoroutine(ExecuteTimeline());
            Destroy(this);
        }
    }
}