using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Frontend.Battle.UI {
    public class ActionButton : MonoBehaviour
    {
        public Image ActionIcon;

        public void Setup(Sprite icon) {
            ActionIcon.sprite = icon;
        }

        void Start() {
            gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
            gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
            gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);
            gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public void TestDebug() {
            Debug.Log("Button worked");
        }
    }
}