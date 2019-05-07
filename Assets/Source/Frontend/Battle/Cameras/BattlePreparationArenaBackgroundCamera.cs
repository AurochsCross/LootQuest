using UnityEngine;
using DG.Tweening;
using System;

namespace Frontend.Battle.Cameras {
    public class BattlePreparationArenaBackgroundCamera: MonoBehaviour {
        private Transform _followTarget;
        private Vector3 _offset;

        private bool _isActive = false;
        public void Activate(Transform followTarget, Vector3 offset) {
            _followTarget = followTarget;
            _offset = offset;
        }

        void Update() {
            if (_isActive) {
                transform.eulerAngles = _followTarget.eulerAngles;
            }
        }


    }
}