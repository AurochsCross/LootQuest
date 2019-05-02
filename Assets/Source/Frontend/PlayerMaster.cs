using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend {
    public class PlayerMaster : MonoBehaviour
    {
        public static PlayerMaster Shared;
        public Exploring.PlayerMovement Movement;
        public Exploring.Camera.PlayerCamera Camera;

        public Animator PlayerAnimator;

        void Awake() {
            Shared = this;
        }
    }
}