using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend {
    public class Master : MonoBehaviour
    {
        public static Master Shared;
        public LootQuest.Logic.Game.Master GameMaster { get; private set; }
        public Entity.EntityMaster PlayerMaster;
        public Exploring.EntityRegistry EntityRegistry; 
        public Battle.BattleManager BattleManager;

        void Awake() {
            Shared = this;
            GameMaster = new LootQuest.Logic.Game.Master();
            EntityRegistry = gameObject.GetComponent<Exploring.EntityRegistry>();
        }

        void Start() {
            GameMaster.SetPlayer(PlayerMaster.Master);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.LoadLevel(0);
            }
            LootQuest.Logic.Utilities.GameLoopUpdate.Shared.Update();
        }
    }
}