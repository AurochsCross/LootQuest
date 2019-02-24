using System.Collections.Generic;

namespace Logic.Player.Commanders {
    public class BattleCommander {
        public Logic.Pawns.BattlePawn battlePawn { get; private set; }
        public BattleCommander(Models.Common.Attributes baseAttributes, List<Models.Action.ActionRoot> actions) {
            battlePawn = new Logic.Pawns.BattlePawn(baseAttributes, actions);
        }
    }
}