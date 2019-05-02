using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Frontend.Battle.UI {
    public class BattleUI : MonoBehaviour {
        public BattleManager BattleManager;
        public GameObject UIParent;
        public bool IsVisible {
            get {
                return _isVisible;
            }
            set {
                _isVisible = value;
                UIParent.SetActive(_isVisible);
            }
        }
        public Slider PlayerSlider;
        public Text PlayerHealthText;
        public Text EnemyTitle;
        public Slider EnemySlider;
        public Text EnemyHealthText;
        private bool _isVisible = false;
        public Transform[] ActionButtonContainers;
        public GameObject ActionButtonTemplate;
        private int _actionButtonCount = 0;

        private LootQuest.Logic.Pawns.BattlePawn _mainPawn;
        private LootQuest.Logic.Pawns.BattlePawn _hostilePawn;

        private bool _isReady = false;

        void Start() {

        }

        void Update() {
            if (BattleManager.IsBattleActive && _isReady) {
                UpdateHealthIndicators();
            }
        }

        private void UpdateHealthIndicators() {
            PlayerSlider.value = 1f / (float)_mainPawn.maxHitPoints * (float)_mainPawn.currentHitPoints;
            PlayerHealthText.text = string.Format("{0}/{1}", _mainPawn.currentHitPoints.ToString(), _mainPawn.maxHitPoints.ToString());

            EnemySlider.value = 1f / (float)_hostilePawn.maxHitPoints * (float)_hostilePawn.currentHitPoints;
            EnemyHealthText.text = string.Format("{0}/{1}", _hostilePawn.currentHitPoints.ToString(), _hostilePawn.maxHitPoints.ToString());
        }

        public void Setup(Entity.EntityMaster player, Entity.EntityMaster enemy) {
            _actionButtonCount = 0;
            _mainPawn = player.Master.BattleCommander.BattlePawn;
            _hostilePawn = enemy.Master.BattleCommander.BattlePawn;

            EnemyTitle.text = enemy.Name;
            ClearPlayerActionButtons();

            player.Master.EquipmentCommander.GetActions().ForEach( x => {
                AddPlayerActionButton(player, x);
            });
            _isReady = true;
        }
        
        public void ClearPlayerActionButtons() {
            foreach (Transform container in ActionButtonContainers) {
                if (container.childCount > 0) {
                    Destroy(container.GetChild(0).gameObject);
                }
            }
        }

        private void AddPlayerActionButton(Entity.EntityMaster entity, LootQuest.Models.Action.ActionRoot action) {
            var button = Instantiate(ActionButtonTemplate) as GameObject;
            button.transform.SetParent(ActionButtonContainers[_actionButtonCount]);
            button.GetComponent<ActionButton>().Setup(action.GetRepresentable<Tools.ActionBuilder.Nodes.ActionNode>().ActionIcon);
            button.GetComponent<Button>().onClick.AddListener(delegate { entity.BattleMaster.UseAction(action); } );

            _actionButtonCount++;
        }
    }
}