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

        public void ReadyForBattle() {
            Camera.gameObject.SetActive(false);
            Movement.DisableMovement();
            Debug.Log("Camera should be dissabled: " + Camera.gameObject.activeInHierarchy);
        }

        public void ReadyForExploring() {
            Camera.gameObject.SetActive(true);
            Movement.EnableMovement();
            Camera.State = Exploring.Camera.CameraState.Explore;
            Debug.Log("Camera should be enabled: " + Camera.gameObject.activeInHierarchy);
        }
    }
}