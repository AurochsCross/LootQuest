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
        public event BattleHandler OnActionUsed;

        public delegate void EffectHandler(object myObject, Models.Events.EffectExecutionArgs args);
        public event EffectHandler OnEffectExecution;
        
        private List<Logic.Actions.AuraHandler> _activeAuras = new List<Logic.Actions.AuraHandler>();

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
            
            if (OnActionUsed != null) {
                OnActionUsed(this, new Models.Events.BattlePawnArgs(1));
            }

            _battleMaster.ExecuteAction(action, this);
        }

        public void AddAura(Models.Action.Aura.AuraRoot aura) {
            var auraHandler = new Actions.AuraHandler(aura, this, _battleMaster.GetOtherCommander(this));
            auraHandler.SetupAura();
            _activeAuras.Add(auraHandler);
        }

        public void RemoveAura(Actions.AuraHandler auraHandler) {
            _activeAuras.Remove(auraHandler);
            auraHandler = null;
        }

        public void TakeDamage(int value) {
            int damageAmount = value;
            foreach (var aura in _activeAuras.ToList()) {
                damageAmount = aura.TakeDamage(damageAmount);
            }

            if (damageAmount <= 0)
                return;

            BattlePawn.TakeDamage(damageAmount);

            if (BattlePawn.currentHitPoints <= 0) {
                OnDeath(this, null);
                Master.ExplorePawn.CurrentPosition = new Models.Exploring.Position(Utilities.IdGenerator.GetId(), 0);
                return;
            }

            if (OnDamageTaken != null) {
                OnDamageTaken(this, new Models.Events.BattlePawnArgs(damageAmount));
            }
        }

        public void TakeHealing(int value) {
            int healingAmount = value;
            foreach (var aura in _activeAuras.ToList()) {
                healingAmount = aura.TakeHealing(healingAmount);
            }

            if (healingAmount <= 0)
                return;

            BattlePawn.TakeHealing(healingAmount);
            if (OnHealingTaken != null) {
                OnHealingTaken(this, new Models.Events.BattlePawnArgs(healingAmount));
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