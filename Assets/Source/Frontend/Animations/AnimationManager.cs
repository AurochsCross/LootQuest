using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Animations {
    public class AnimationManager : MonoBehaviour {
        public Animator MainAnimator;
        public int SimpleAttackAnimationCount = 1;

        public virtual void PlaySimpleAttack() {
            MainAnimator.SetTrigger(AnimationConfig.SimpleAnimationType.SimpleAttack.ToName());
        }

        public virtual void PlayTakeDamage(int index = 0) {
            MainAnimator.SetTrigger("Reset");
            MainAnimator.Play(string.Format("TakeDamage_{0}", index));
        }

        public virtual void PlayGetReadyForBattleAnimation() {
            MainAnimator.SetTrigger(AnimationConfig.SimpleAnimationType.ReadyForBattle.ToName());
            MainAnimator.Play("GetReadyForBattle");
        }

        public virtual void PlayDeathAnimation() {
            MainAnimator.SetTrigger(AnimationConfig.SimpleAnimationType.Death.ToName());
        }

        public virtual void SetTrigger(string triggerName) {
            MainAnimator.SetTrigger(triggerName);
        }
    }
}