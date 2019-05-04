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
                    player.GetComponent<PlayerMaster>().ReadyForBattle();
                } else {
                    npcs.Add(participant);
                }
                participant.BattleMaster.ReadyForBattle();
                participant.Master.BattleCommander.OnDeath += FinishBattle;
            }
            
            BattleUI.Setup(player, npcs.First());
            ArenaManager.Setup(new List<Entity.EntityMaster>() {player, npcs.First()});
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