using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Battle {
    public class Manager : MonoBehaviour
    {
        public void DidBeginEncounter(Logic.Pawns.BattlePawn encounterPawn) {
            Frontend.Master.main.gameMaster.InitiateBattle(encounterPawn);
        }
    }
}