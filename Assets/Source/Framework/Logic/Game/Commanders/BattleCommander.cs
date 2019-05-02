using System.Collections.Generic;
using System.Linq;
using LootQuest.Logic.Actions;

namespace LootQuest.Logic.Game.Commanders {
    public class BattleCommander {

        #region Event

        public delegate void BattleHandler(object myObject, Models.Events.BattlePawnArgs args);
        public event BattleHandler OnDamageTaken;
        public event BattleHandler OnHealingTaken;

        public delegate void EffectHandler(object myObject, Models.Events.EffectExecutionArgs args);
        public event EffectHandler BeganEffectExecution;
        public event EffectHandler FinishedEffectExecution;

        #endregion

        public Logic.Entity.Commanders.BattleCommander[] Commanders { get; private set; }

        private Logic.Game.Master _master;

        public BattleCommander(Master master) {
            _master = master;
        }

        public void SetupBattle(Logic.Entity.Commanders.BattleCommander[] battleCommanders) {
            Commanders = battleCommanders;
        }

        public Logic.Entity.Commanders.BattleCommander GetOtherCommander(Logic.Entity.Commanders.BattleCommander commander) {
            return Commanders.First(x => x != commander);
        }

        public void ExecuteAction(LootQuest.Models.Action.ActionRoot action, Logic.Entity.Commanders.BattleCommander source) {
            ExecuteAction(action, source, GetOtherCommander(source));
        }

        public void ExecuteAction(LootQuest.Models.Action.ActionRoot action, Logic.Entity.Commanders.BattleCommander source, Logic.Entity.Commanders.BattleCommander target) {
            action.Reset();
            ExecuteNextAction(action.effects[0].Delay, action, source, target, 0);
        }

        private async void ExecuteNextAction(float delay, LootQuest.Models.Action.ActionRoot action, Logic.Entity.Commanders.BattleCommander source, Logic.Entity.Commanders.BattleCommander target, int effectIndex) {
            var subject = action.effects[effectIndex].subject == LootQuest.Models.Action.EffectSubject.Source ? source : target;
            source.DoEffect(subject.Master, action, effectIndex, true);
            
            await System.Threading.Tasks.Task.Delay((int)(delay * 1000));

            ExecuteActionEffect(action, action.effects[effectIndex], source, target);
            source.DoEffect(subject.Master, action, effectIndex, false);

            int nextEffectIndex = effectIndex + 1;
            if (nextEffectIndex < action.effects.Length) {
                ExecuteNextAction(action.effects[nextEffectIndex].Delay, action, source, target, nextEffectIndex);
            }
        }

        private bool ExecuteActionEffect(LootQuest.Models.Action.ActionRoot action, LootQuest.Models.Action.ActionEffect effect, Logic.Entity.Commanders.BattleCommander source, Logic.Entity.Commanders.BattleCommander target) {
            if (Actions.Helpers.ActionCalculationHelper.CalculateDidHit(effect.hitCalculation, action, source, target)) {
                effect.didHit = true;

                var value = Actions.Helpers.ActionCalculationHelper.CalculateValue(effect.valueCalculation, action, source, target);
                effect.calculatedValue = value;

                var subject = effect.subject == LootQuest.Models.Action.EffectSubject.Source ? source : target;

                if (effect.type == LootQuest.Models.Action.EffectType.Damage) {
                    subject.TakeDamage((int)value);
                } else if (effect.type == LootQuest.Models.Action.EffectType.Heal) {
                    subject.TakeHealing((int)value);
                }

                return true;
            }

            return false;
        }
    }
}