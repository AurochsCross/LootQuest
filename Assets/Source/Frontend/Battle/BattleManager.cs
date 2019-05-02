using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Frontend.Battle {
    public class BattleManager : MonoBehaviour {

        public bool IsBattleActive {get; private set; } = false; 
        public Entity.EntityMaster[] Participants { get; private set; }
        public UI.BattleUI BattleUI;

        void Start() {
            gameObject.GetComponent<Master>().GameMaster.OnEncounterStarted += StartBattle;
        }

        public void StartBattle(object sender, LootQuest.Models.Events.EncounterArgs args) {
            IsBattleActive = true;
            Participants = args.EncounterParticipatns.Select(x =>  { 
                Debug.Log("Select: " + x.Name);
                return x.GetRepresentable<Entity.EntityMaster>(); 
            }).ToArray();

            Entity.EntityMaster player = null;
            List<Entity.EntityMaster> npcs = new List<Entity.EntityMaster>();

            foreach (var participant in Participants) {
                if (participant.IsPlayer) {
                    player = participant;
                    participant.GetComponent<Exploring.PlayerMovement>().DisableMovement();
                } else {
                    npcs.Add(participant);
                    Exploring.Camera.PlayerCamera.Shared.ApplyBattleState(participant.transform.position);
                }
                participant.BattleMaster.ReadyForBattle();
                participant.Master.BattleCommander.OnDeath += FinishBattle;
            }

            BattleUI.Setup(player, npcs.First());
            BattleUI.IsVisible = true;
        }

        public void FinishBattle(object sender, object args) {
            StartCoroutine(FinishBattle());
        }

        IEnumerator FinishBattle() {
            
            yield return new WaitForSeconds(2f);
            IsBattleActive = false;

            BattleUI.IsVisible = false;

            Master.Shared.PlayerMaster.GetComponent<Exploring.PlayerMovement>().EnableMovement();
            Exploring.Camera.PlayerCamera.Shared.State = Exploring.Camera.CameraState.Explore;
        }
    }
}