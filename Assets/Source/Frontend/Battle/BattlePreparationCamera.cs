using UnityEngine;
using DG.Tweening;
using System;

namespace Frontend.Battle {
    public class BattlePreparationCamera: MonoBehaviour {

        public MeshRenderer OverlayRenderer;    
        public void AnimateFade(Entity.EntityMaster enemy, Action onComplete) {
            transform.parent = enemy.transform;
            transform.position = Camera.main.transform.position;
            transform.eulerAngles = Camera.main.transform.eulerAngles;

            transform.DOMove(enemy.transform.position + new Vector3(2.85f, 2.13f, -2.85f), 1f);
            transform.DORotate(new Vector3(20f, -45f, 0f), 1f); 

            DOTween.To(x => OverlayRenderer.material.SetFloat("_Visibility", x), 0f, 1f, 1f).OnComplete(() => onComplete());
        }

        public void AnimateUnfade(BattleArenaManager arena, Action onComplete) {
            DOTween.To(x => OverlayRenderer.material.SetFloat("_Visibility", x), 1f, 0f, 1f).OnComplete(() => onComplete());
            transform.parent = null;
            transform.DOMove(arena.BattleCamera.transform.position, 1f);
            transform.DORotate(arena.BattleCamera.transform.eulerAngles, 1f); 
        }
    }
}