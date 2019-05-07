using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Frontend.Battle {
    public class BattleManager : MonoBehaviour {

        public bool IsBattleActive {get; private set; } = false; 
        public Entity.EntityMaster[] Participants { get; private set; }
        public UI.BattleUI BattleUI;
        public BattleArenaManager ArenaManager;
        public Cameras.BattlePreparationCamera PreparationCamera;
        private bool _isWaitingForBattle = false;

        void Start() {
            gameObject.GetComponent<Master>().GameMaster.OnEncounterStarted += SetupBattle;
        }

        public void SetupBattle(object sender, LootQuest.Models.Events.EncounterArgs args) {
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
                    player.GetComponent<PlayerMaster>().ReadyForBattle();
                } else {
                    npcs.Add(participant);
                }
                participant.BattleMaster.ReadyForBattle();
                participant.Master.BattleCommander.OnDeath += FinishBattle;
            }

            PreparationCamera.gameObject.SetActive(true);
            PreparationCamera.AnimateFade(npcs.First(), FadeFinished);
        }

        private void FadeFinished() {
            Entity.EntityMaster player = null;
            List<Entity.EntityMaster> npcs = new List<Entity.EntityMaster>();

            foreach (var participant in Participants) {
                if (participant.IsPlayer) {
                    player = participant;
                } else {
                    npcs.Add(participant);
                }
            }
            ArenaManager.Setup(new List<Entity.EntityMaster>() {player, npcs.First()});

            _isWaitingForBattle = true;

        }
        void Update() {
            if (_isWaitingForBattle && Input.GetMouseButtonDown(0)) {
                _isWaitingForBattle = false;
                PreparationCamera.AnimateUnfade(ArenaManager, StartBattle);
            }   
        }

        public void StartBattle() {
            Entity.EntityMaster player = null;
            List<Entity.EntityMaster> npcs = new List<Entity.EntityMaster>();

            foreach (var participant in Participants) {
                if (participant.IsPlayer) {
                    player = participant;
                } else {
                    npcs.Add(participant);
                }
                participant.BattleMaster.StartBattle();
            }

            PreparationCamera.gameObject.SetActive(false);
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
            PlayerMaster.Shared.ReadyForExploring();
            ArenaManager.Close();
        }
    }
}