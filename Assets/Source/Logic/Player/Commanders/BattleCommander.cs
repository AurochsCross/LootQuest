using System.Collections.Generic;

namespace Logic.Player.Commanders {
    class BattleCommander {
        public Logic.Pawns.BattlePawn battlePawn { get; private set; }
        public BattleCommander(Common.Attributes baseAttributes, List<Actions.Action> actions) {
            battlePawn = new Logic.Pawns.BattlePawn(baseAttributes, actions);
        }
    }
}