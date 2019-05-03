using System.Collections.Generic;
using System.Linq;
using LootQuest.Models.Action.Aura;

namespace LootQuest.Logic.Actions {
    public class AuraHandler {
        #region Events
        public delegate void AuraEventHandler(object sender, Models.Events.BattlePawnArgs args);
        public AuraEventHandler OnAuraDamageActionTaken;
        public AuraEventHandler OnAuraDamageTaken;
        public AuraEventHandler OnCreation;
        public AuraEventHandler OnDestruction;
        public AuraEventHandler OnCompletion;
        public AuraEventHandler OnTimer;

        #endregion
        private Models.Action.Aura.AuraRoot _aura;
        private Logic.Entity.Commanders.BattleCommander _caster;
        private Logic.Entity.Commanders.BattleCommander _other;
        private Dictionary<CasterType, Dictionary<CompletionConditionType, int>> _completionCounters;
        private Dictionary<TriggerType, List<Trigger>> _triggers = new Dictionary<TriggerType, List<Trigger>>() {
            { TriggerType.OnCompletion, new List<Trigger>() },
            { TriggerType.OnCreation, new List<Trigger>() },
            { TriggerType.OnDamageTaken, new List<Trigger>() },
            { TriggerType.OnDestruction, new List<Trigger>() },
            { TriggerType.OnHealingTaken, new List<Trigger>() },
            { TriggerType.OnInflictingDamage, new List<Trigger>() },
            { TriggerType.OnRepeatingTimer, new List<Trigger>() }
        };

        public AuraHandler(Models.Action.Aura.AuraRoot aura, Logic.Entity.Commanders.BattleCommander caster, Logic.Entity.Commanders.BattleCommander other) {
            _aura = aura;
            _caster = caster;
            _other = other;
        }

        public int TakeDamage(int amount) {
            if (OnAuraDamageActionTaken != null) {
                OnAuraDamageActionTaken(this, new Models.Events.BattlePawnArgs(1));
            }

            if (OnAuraDamageTaken != null) {
                OnAuraDamageTaken(this, new Models.Events.BattlePawnArgs(amount));
            }

            if (_aura.IsOverridingDamage) {
                string calculationString = _aura.DamageOverride.Replace("[a:damage]", amount.ToString());
                int calculatedValue = (int)Helpers.ActionCalculationHelper.CalculateValue(calculationString, null, _caster, _other);
                return calculatedValue;
            }
            
            return amount;
        }

        public int TakeHealing(int amount) {
            if (_aura.IsOverridingHealing) {
                string calculationString = _aura.HealingOverride.Replace("[a:healing]", amount.ToString());
                int calculatedValue = (int)Helpers.ActionCalculationHelper.CalculateValue(calculationString, null, _caster, _other);
                return calculatedValue;
            }

            return amount;
        }

        #region Setup

        public void SetupAura() {
            SetupCompletionConditionsSubscription();
            SetupTriggers();
            OnCompletion += OnCompleted;
            OnDestruction += OnDestroyed;
        }

        #region Completions
        private void SetupCompletionConditionsSubscription() {
            SetupCompletionCounters();
            foreach (var condition in _aura.CompletionConditions) {
                SetupCompletionConditionSubscription(condition);
            }
            foreach (var condition in _aura.DestroyConditions) {
                SetupCompletionConditionSubscription(condition, true);
            }
        }

        private void SetupCompletionConditionSubscription(CompletionCondition condition, bool isDestroy = false) {
            switch (condition.Type) {
                case CompletionConditionType.ActionsUsed: {
                    condition.EventHandler = (object sender, Models.Events.BattlePawnArgs args) => SetupConditionEventHandling(condition, args.Amount, isDestroy);
                    AffectedFromCasterType(condition.Caster).OnActionUsed += condition.EventHandler;
                    break;
                }
                case CompletionConditionType.AuraDamageActionsTaken: {
                    condition.EventHandler = (object sender, Models.Events.BattlePawnArgs args) => SetupConditionEventHandling(condition, args.Amount, isDestroy);
                    OnAuraDamageActionTaken += ((object obj, Models.Events.BattlePawnArgs args) => {
                        SetupConditionEventHandling(condition, args.Amount, isDestroy);
                    });
                    break;
                }
                case CompletionConditionType.AuraDamageTaken: {
                    condition.EventHandler = (object sender, Models.Events.BattlePawnArgs args) => SetupConditionEventHandling(condition, args.Amount, isDestroy);
                    OnAuraDamageTaken += ((object obj, Models.Events.BattlePawnArgs args) => {
                        SetupConditionEventHandling(condition, args.Amount, isDestroy);
                    });
                    break;
                }
                case CompletionConditionType.DamageActionsTaken: {
                    condition.EventHandler = (object sender, Models.Events.BattlePawnArgs args) => SetupConditionEventHandling(condition, args.Amount, isDestroy);
                    AffectedFromCasterType(condition.Caster).OnDamageTaken += condition.EventHandler;
                    break;
                }
                case CompletionConditionType.DamageTaken: {
                    condition.EventHandler = (object sender, Models.Events.BattlePawnArgs args) => SetupConditionEventHandling(condition, args.Amount, isDestroy);
                    AffectedFromCasterType(condition.Caster).OnDamageTaken += condition.EventHandler;
                    break;
                }
                case CompletionConditionType.Time: {
                    System.Console.WriteLine("Not implemented");
                    break;
                }
            }
        }

        private void UnsubscribeCompletionConditions() {
            foreach (var condition in _aura.CompletionConditions) {
                UnsubscribeCompletionCondition(condition);
            }
            foreach (var condition in _aura.DestroyConditions) {
                UnsubscribeCompletionCondition(condition);
            }
        }

        private void UnsubscribeCompletionCondition(CompletionCondition condition) {
            switch (condition.Type) {
                case CompletionConditionType.ActionsUsed: {
                    AffectedFromCasterType(condition.Caster).OnActionUsed -= condition.EventHandler;
                    break;
                }
                case CompletionConditionType.AuraDamageActionsTaken: {
                    OnAuraDamageActionTaken -= ((object obj, Models.Events.BattlePawnArgs args) => {
                        SetupConditionEventHandling(condition, args.Amount, false);
                    });
                    break;
                }
                case CompletionConditionType.AuraDamageTaken: {
                    OnAuraDamageTaken -= ((object obj, Models.Events.BattlePawnArgs args) => {
                        SetupConditionEventHandling(condition, args.Amount, false);
                    });
                    break;
                }
                case CompletionConditionType.DamageActionsTaken: {
                    AffectedFromCasterType(condition.Caster).OnDamageTaken -= condition.EventHandler;
                    break;
                }
                case CompletionConditionType.DamageTaken: {
                    AffectedFromCasterType(condition.Caster).OnDamageTaken -= condition.EventHandler;
                    break;
                }
                case CompletionConditionType.Time: {
                    System.Console.WriteLine("Not implemented");
                    break;
                }
            }
        }

        private void SetupConditionEventHandling(CompletionCondition condition, int amount, bool isDestroy = false) {
            _completionCounters[condition.Caster][condition.Type] += amount;
            if (_completionCounters[condition.Caster][condition.Type] >= int.Parse(condition.Value)) {
                if (isDestroy) {
                    if (OnDestruction != null) {
                        OnDestruction(this, null);
                    }
                } else {
                    if (OnCompletion != null) {
                        OnCompletion(this, null);
                    }
                }
            }
        }

        private void SetupCompletionCounters() {

            _completionCounters = new Dictionary<CasterType, Dictionary<CompletionConditionType, int>>() {
                { 
                    CasterType.Self, new Dictionary<CompletionConditionType, int>() {
                        { CompletionConditionType.ActionsUsed, 0 },
                        { CompletionConditionType.DamageActionsTaken, 0 },
                        { CompletionConditionType.DamageInflicted, 0 },
                        { CompletionConditionType.DamageTaken, 0 },
                        { CompletionConditionType.AuraDamageTaken, 0 },
                        { CompletionConditionType.AuraDamageActionsTaken, 0 }
                    }
                },
                { 
                    CasterType.Other, new Dictionary<CompletionConditionType, int>() {
                        { CompletionConditionType.ActionsUsed, 0 },
                        { CompletionConditionType.DamageActionsTaken, 0 },
                        { CompletionConditionType.DamageInflicted, 0 },
                        { CompletionConditionType.DamageTaken, 0 }
                    }
                }
            };
        }

        #endregion

        #region Triggers
        private void SetupTriggers() {
            foreach (var trigger in _aura.Triggers) {

                switch (trigger.Type) {
                    case TriggerType.OnAuraDamageTaken: {
                        trigger.EventHandler = ((object obj, Models.Events.BattlePawnArgs args) => ExecuteTrigger(trigger, args.Amount));
                        OnAuraDamageTaken += ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                    case TriggerType.OnDamageTaken: {
                        trigger.EventHandler = ((object obj, Models.Events.BattlePawnArgs args) => ExecuteTrigger(trigger, args.Amount));
                        _caster.OnDamageTaken += trigger.EventHandler;
                        break;
                    }
                    case TriggerType.OnCreation: {
                        trigger.EventHandler = ((object obj, Models.Events.BattlePawnArgs args) => ExecuteTrigger(trigger, args.Amount));
                        OnCreation += ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                    case TriggerType.OnCompletion: {
                        trigger.EventHandler = ((object obj, Models.Events.BattlePawnArgs args) => ExecuteTrigger(trigger, args.Amount));
                        OnCompletion += ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                    case TriggerType.OnDestruction: {
                        trigger.EventHandler = ((object obj, Models.Events.BattlePawnArgs args) => ExecuteTrigger(trigger, args.Amount));
                        OnDestruction += ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                    case TriggerType.OnHealingTaken: {
                        trigger.EventHandler = ((object obj, Models.Events.BattlePawnArgs args) => ExecuteTrigger(trigger, args.Amount));
                        _caster.OnHealingTaken += trigger.EventHandler;
                        break;
                    }
                    case TriggerType.OnRepeatingTimer: {
                        trigger.EventHandler = ((object obj, Models.Events.BattlePawnArgs args) => ExecuteTrigger(trigger, args.Amount));
                        OnTimer += ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                }
            }
        }

        private void UnsubscribeTriggerEvents() {
            foreach (var trigger in _aura.Triggers) {

                switch (trigger.Type) {
                    case TriggerType.OnAuraDamageTaken: {
                        OnAuraDamageTaken -= ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                    case TriggerType.OnDamageTaken: {
                        _caster.OnDamageTaken -= trigger.EventHandler;
                        break;
                    }
                    case TriggerType.OnCreation: {
                        OnCreation -= ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                    case TriggerType.OnCompletion: {
                        OnCompletion -= ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                    case TriggerType.OnDestruction: {
                        OnDestruction -= ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                    case TriggerType.OnHealingTaken: {
                        _caster.OnHealingTaken -= trigger.EventHandler;
                        break;
                    }
                    case TriggerType.OnRepeatingTimer: {
                        OnTimer -= ((object obj, Models.Events.BattlePawnArgs args) => {
                            ExecuteTrigger(trigger, args.Amount);
                        });
                        break;
                    }
                }
            }
        }

        private void ExecuteTrigger(Trigger trigger, int value) {
            foreach (var effect in trigger.TriggeredAction.effects) {
                effect.valueCalculation = effect.originalValueCalculation.Replace("[trigger:value]", value.ToString());
            }
            _caster.UseAction(trigger.TriggeredAction);
        }

        #endregion
        
        #endregion

        private void OnCompleted(object sender, Models.Events.BattlePawnArgs args) {
            _caster.RemoveAura(this);
            Cleanup();
        }

        private void OnDestroyed(object sender, Models.Events.BattlePawnArgs args) {
            _caster.RemoveAura(this);
            Cleanup();
        }

        private void Cleanup() {
            UnsubscribeCompletionConditions();
            UnsubscribeTriggerEvents();
        }

        private Logic.Entity.Commanders.BattleCommander AffectedFromCasterType(CasterType type) {
            if (type == CasterType.Self)
                return _caster;

            return _other;
        }
    }
}