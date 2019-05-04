using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Exploring {
    public class PlayerMovement : MonoBehaviour {
        public LayerMask MovementSelectionDetectionMask;
        public Animator PlayerAnimator;
        private UnityEngine.AI.NavMeshAgent _navigationAgent;
        private LootQuest.Logic.Game.Commanders.ExploreCommander _exploreCommander;
        private LootQuest.Models.Exploring.Position lastPosition = new LootQuest.Models.Exploring.Position();
        private bool _isEnabled = true;

        void Start() {
            _navigationAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            _exploreCommander = Frontend.Master.Shared.GameMaster.ExploreCommander;
            lastPosition = ExploreSettings.Shared.PositionToExplorePosition(transform.position);
        }

        void Update() {
            if (Input.GetMouseButtonDown(0)  && _isEnabled) {
                HandleMoveSelection(Input.mousePosition);
            }

            var currentPosition = ExploreSettings.Shared.PositionToExplorePosition(transform.position);

            if (currentPosition != lastPosition) {
                lastPosition = currentPosition;
                _exploreCommander.MoveEntity(gameObject.GetComponent<Entity.EntityMaster>().Master, currentPosition);
            }
        }

        void FixedUpdate() {
            PlayerAnimator.SetFloat("velocity", _navigationAgent.velocity.magnitude);
        }

        public void DisableMovement() {
            _navigationAgent.isStopped = true;
            _isEnabled = false;
            _navigationAgent.enabled = false;
        }

        public void EnableMovement() {
            _navigationAgent.isStopped = false;
            _isEnabled = true;
            _navigationAgent.enabled = true;
            _navigationAgent.Warp(transform.position);
            //_navigationAgent.destination = transform.position;
        }

        private void HandleMoveSelection(Vector2 mousePosition) {
            RaycastHit hit;
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, MovementSelectionDetectionMask)) {
                MovePlayer(hit.point);
            }
        }

        private void MovePlayer(Vector3 location) {
            transform.LookAt(location);
            _navigationAgent.destination = location;
        }
    }
}