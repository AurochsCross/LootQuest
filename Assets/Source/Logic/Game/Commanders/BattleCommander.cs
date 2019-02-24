using System.Collections.Generic;
using System.Linq;
using Logic.Actions;

namespace Logic.Game.Commanders {
    class BattleCommander {
        public List<Pawns.BattlePawn> pawns { get; private set; } = new List<Pawns.BattlePawn>();

        public List<Pawns.BattlePawn> GetOtherPawns(Pawns.BattlePawn pawn) {
            return new List<Pawns.BattlePawn>(pawns.SkipWhile(x => x == pawn));
        }

        public void ExecuteAction(Models.Action.ActionRoot action, IActionAffectable source, IActionAffectable target) {
            
        }
    }
}