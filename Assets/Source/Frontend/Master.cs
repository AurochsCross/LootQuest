using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend {
    public class Master : MonoBehaviour
    {
        public static Master main;
        public Logic.Game.Master gameMaster { get; private set; }
        public Logic.Player.Master playerMaster { get; private set; } 

        void Awake() {
            main = this;
            gameMaster = new Logic.Game.Master();
            playerMaster = gameMaster.playerMaster;
        }
    }
}