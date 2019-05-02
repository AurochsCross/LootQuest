using System.Collections.Generic;
using LootQuest.Models.Common;
using System.Linq;

namespace LootQuest.Logic.Entity.Commanders {
    public class BattleCommander {

        #region Events 

        public delegate void BattleHandler(object myObject, Models.Events.BattlePawnArgs args);
        public event BattleHandler OnDamageTaken;
        public event BattleHandler OnHealingTaken;
        public event BattleHandler OnDeath;

        public delegate void EffectHandler(object myObject, Models.Events.EffectExecutionArgs args);
        public event EffectHandler OnEffectExecution;

        #endregion
        public string Name { 
            get {
                return this.Master.Name;
            } 
        }
        public Logic.Pawns.BattlePawn BattlePawn { get; private set; }
        public Master Master { get; private set; }
        private LootQuest.Logic.Game.Commanders.BattleCommander _battleMaster;

        public BattleCommander(Master master, LootQuest.Logic.Game.Commanders.BattleCommander battleMaster, LootQuest.Models.Common.Attributes baseAttributes) {
            this.Master = master;
            BattlePawn = new Logic.Pawns.BattlePawn(baseAttributes, Master.AvailableActions);
            _battleMaster = battleMaster;
        }

        public void UseAction(LootQuest.Models.Action.ActionRoot action) {
            var actions = Master.AvailableActions;
            //if (actions.Contains(action)) {
                _battleMaster.ExecuteAction(action, this);
            //}
        }

        public void TakeDamage(int value) {
            BattlePawn.TakeDamage(value);

            if (BattlePawn.currentHitPoints <= 0) {
                OnDeath(this, null);
                Master.ExplorePawn.CurrentPosition = new Models.Exploring.Position(Utilities.IdGenerator.GetId(), 0);
                return;
            }

            if (OnDamageTaken != null) {
                OnDamageTaken(this, new Models.Events.BattlePawnArgs(value));
            }
        }

        public void TakeHealing(int value) {
            BattlePawn.TakeHealing(value);
            if (OnHealingTaken != null) {
                OnHealingTaken(this, new Models.Events.BattlePawnArgs(value));
            }
        }

        public void DoEffect(Master subject, LootQuest.Models.Action.ActionRoot action, int effectIndex, bool isWindup = false) {
            var args = new LootQuest.Models.Events.EffectExecutionArgs(action, this.Master, subject, effectIndex, isWindup);
            if (OnEffectExecution != null) {
                OnEffectExecution(this, args);
            }
        }
    }
}