using LootQuest.Logic.Pawns;
using System;
using System.Linq;
using org.mariuszgromada.math.mxparser;

namespace LootQuest.Logic.Actions.Helpers {
    public class ActionCalculationHelper {
        private static string ReplacePlaceholdersWithValues(string calculation, LootQuest.Models.Action.ActionRoot action, Logic.Entity.Commanders.BattleCommander source, Logic.Entity.Commanders.BattleCommander target) {
            string result = calculation;

            result = result.Replace("[s:strength]", source.BattlePawn.baseAttributes.strength.ToString());
            result = result.Replace("[s:intelligence]", source.BattlePawn.baseAttributes.intelligence.ToString());
            result = result.Replace("[s:dexterity]", source.BattlePawn.baseAttributes.dexterity.ToString());
            result = result.Replace("[s:hp]", source.BattlePawn.currentHitPoints.ToString());
            result = result.Replace("[s:maxHp]", source.BattlePawn.maxHitPoints.ToString());
            
            result = result.Replace("[t:strength]", target.BattlePawn.baseAttributes.strength.ToString());
            result = result.Replace("[t:intelligence]", target.BattlePawn.baseAttributes.intelligence.ToString());
            result = result.Replace("[t:dexterity]", target.BattlePawn.baseAttributes.dexterity.ToString());
            result = result.Replace("[t:hp]", target.BattlePawn.currentHitPoints.ToString());
            result = result.Replace("[t:maxHp]", target.BattlePawn.maxHitPoints.ToString());

            if (action != null) {
                action.effects.ToList().ForEach( x => result = result.Replace(String.Format("[{0}:didHit]", x.id), x.didHit ? "1" : "0"));
                action.effects.ToList().ForEach( x => result = result.Replace(String.Format("[{0}:calculatedValue]", x.id), x.calculatedValue.ToString()));
            }

            return result;
        }

        public static bool CalculateDidHit(string calculation, LootQuest.Models.Action.ActionRoot action, Logic.Entity.Commanders.BattleCommander source, Logic.Entity.Commanders.BattleCommander target) {
            if (calculation == null || string.IsNullOrWhiteSpace(calculation)) {
                return true;
            }
            
            string valueCalculation = String.Format("if({0}, 1, 0)", ReplacePlaceholdersWithValues(calculation, action, source, target));
            return new Expression(valueCalculation).calculate() == 1 ? true : false;
        }

        public static float CalculateValue(string calculation, LootQuest.Models.Action.ActionRoot action, Logic.Entity.Commanders.BattleCommander source, Logic.Entity.Commanders.BattleCommander target) {
            string valueCalculation = ReplacePlaceholdersWithValues(calculation, action, source, target);
            return (float)(new Expression(valueCalculation).calculate());
        }
    }
}