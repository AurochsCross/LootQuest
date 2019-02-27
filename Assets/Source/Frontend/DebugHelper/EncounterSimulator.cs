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
            Logic.Pawns.BattlePawn pawn = new Logic.Pawns.BattlePawn(new Models.Common.Attributes(20, 20, 20), new List<Models.Action.ActionRoot>());
        }
    }
}