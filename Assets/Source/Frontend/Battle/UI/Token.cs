using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Frontend.Battle.UI {
    public class Token : MonoBehaviour
    {
        public Text ValueLabel;
        public void Setup(int value, Transform parent, Vector3 position) {
            transform.SetParent(parent);
            transform.position = position;
            ValueLabel.text = value.ToString();
            gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(0, 20), 0.1f).SetDelay(0.5f).OnComplete(() => Destroy(gameObject));// = //.DOSizeDelta(new Vector2(0, 20), 5f);
            
            Camera.main.DOShakePosition(0.2f, 0.35f, 50, 90, true);
        }
    }
}