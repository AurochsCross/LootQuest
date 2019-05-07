using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Battle.Effects {
    public class BattleEffectRandomAttackAnimation : MonoBehaviour {
        void Start() {
            var animationManager = gameObject.GetComponent<BattleEffect>()?.Source?.GetComponent<Frontend.Animations.AnimationManager>();

            int animationIndex = Random.Range(0, animationManager.SimpleAttackAnimationCount);
            animationManager.PlaySimpleAttack();
        }
    }
}