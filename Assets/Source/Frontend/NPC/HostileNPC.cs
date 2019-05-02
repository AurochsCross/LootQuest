using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.NPC {
    public class HostileNPC : MonoBehaviour
    {
        #region Properties
        public Models.NPC.Hostile Data;
        public Entity.EntityMaster Master { get; private set; }

        private BehaviourExecutor _behaviourExecutor;

        #endregion

        void Awake() {
            Master = gameObject.GetComponent<Entity.EntityMaster>();
            _behaviourExecutor = gameObject.GetComponent<BehaviourExecutor>();
        }

        void Start() {
            Master.Master.SetBaseAttributes(new LootQuest.Models.Common.Attributes(Data.Strength, Data.Dexterity, Data.Intelligence, Data.MaxHp));
        }

        public void ReadyForBattle() {
            Appear();

            if (_behaviourExecutor != null) {
                _behaviourExecutor.PrepareForExecution();
            }
        }

        private void Appear() {
            gameObject.GetComponent<Animator>()?.SetTrigger("Appear");
        }
    }
}