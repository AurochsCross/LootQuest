using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Frontend.Exploring.Camera {
    public enum CameraState { Explore, Inventory, Battle };

    public class PlayerCamera : MonoBehaviour {
        public static PlayerCamera Shared;
        public Vector3 CameraOffset;
        public Transform PlayerTransform;

        public CameraState State { 
            get {
                return _state;
            }
            set {
                _state = value;
                ApplyState();
            }
        }
        private CameraState _state = CameraState.Explore;

        void Awake() {
            Shared = this;
        }

        void Start() {
            State = CameraState.Explore;
        }

        void Update() {
            if (_state == CameraState.Explore) {
                transform.position = PlayerTransform.position + CameraOffset;
            }

            if (Input.GetKeyDown(KeyCode.Z)) {
                ApplyExploreState();
            } else if (Input.GetKeyDown(KeyCode.X)) {
                ApplyInventoryState();
            }
        }

        private void ApplyState() {
            switch (_state) {
                case CameraState.Inventory: ApplyInventoryState();
                break;
                case CameraState.Explore: ApplyExploreState();
                break;
            }
        }

        private void ApplyInventoryState() {
            transform.GetChild(0).DOLocalMove(new Vector3(0, 0, -3f), 1f);
            transform.DORotate(new Vector3(10f, -45f, 0), 1f);
        }

        private void ApplyExploreState() {
            transform.GetChild(0).DOLocalMove(new Vector3(0, 0, -8f), 1f);
            transform.DORotate(new Vector3(45f, -45f, 0), 1f);
        }

        public void ApplyBattleState(Vector3 enemyLocation) {
            Vector3 targetDir = enemyLocation - transform.position;
            targetDir = new Vector3(targetDir.x, 0, targetDir.z);

            float angle = Vector3.Angle(new Vector3(1f, 0, 0), targetDir);

            if (targetDir.z < 0) {
                angle  = 360f - angle;
            }

            if (angle > 180f) {
                angle -= 360f;
            }

            State = CameraState.Battle;
            transform.GetChild(0).DOLocalMove(new Vector3(0, 0, -5f), 1f);
            transform.DORotate(new Vector3(35f, 25f - angle, 0f), 1f);
        }
    }
}