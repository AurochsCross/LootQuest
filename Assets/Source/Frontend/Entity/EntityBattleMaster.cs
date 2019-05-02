using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Entity {
    public class EntityBattleMaster : MonoBehaviour
    {
        public bool IsAlive { get; private set; } = true;
        private NPC.BehaviourExecutor _behaviourExecutor;

        void Awake() {
            _behaviourExecutor = gameObject.GetComponent<NPC.BehaviourExecutor>();
        }

        public void ReadyForBattle() {
            gameObject.GetComponent<Animations.AnimationManager>().PlayGetReadyForBattleAnimation();
            gameObject.GetComponent<EntityEffectMaster>().Setup();
            gameObject.GetComponent<EntityMaster>().Master.BattleCommander.OnDamageTaken += OnDamageTaken;
            gameObject.GetComponent<EntityMaster>().Master.BattleCommander.OnDeath += OnDeath;

            if (_behaviourExecutor != null) {
                _behaviourExecutor.PrepareForExecution();
            }
        }

        public void UseAction(LootQuest.Models.Action.ActionRoot action) {
            gameObject.GetComponent<EntityMaster>().Master.BattleCommander.UseAction(action);
            Debug.Log("Action used: " + action.name);
        }

        private void OnDamageTaken(object sender, LootQuest.Models.Events.BattlePawnArgs args) {
            gameObject.GetComponent<Animations.AnimationManager>().PlayTakeDamage();
        }

        private void OnDeath(object sender, LootQuest.Models.Events.BattlePawnArgs args) {
            gameObject.GetComponent<Animations.AnimationManager>().PlayDeathAnimation();
            Master.Shared.GameMaster.ExploreCommander.RemoveEntity(gameObject.GetComponent<Entity.EntityMaster>().Master);
            gameObject.GetComponent<NPC.BehaviourExecutor>()?.StopBehaviour();
            IsAlive = false;
        }

    }
}