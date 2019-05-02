using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Frontend.DebugHelper
{
    public class EncounterSimulator: MonoBehaviour {


        void Update() {
            if (Input.GetKeyDown(KeyCode.B)) {

            }
        }

        private void StartBattle() {
            LootQuest.Logic.Pawns.BattlePawn pawn = new LootQuest.Logic.Pawns.BattlePawn(new LootQuest.Models.Common.Attributes(20, 20, 20), new List<LootQuest.Models.Action.ActionRoot>());
        }
    }
}