using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Exploring {
    [ExecuteInEditMode]
    public class ExploreSettings : MonoBehaviour
    {
        public bool IsDrawingGrid = false;
        public Vector3 DrawnGridOffset = new Vector3();

        public float UnitsPerPosition;

        public static ExploreSettings Shared;

        void Awake() {
            Shared = this;
        }

        void Update() {
            if (IsDrawingGrid) {
                DrawGrid();
            }
        }

        public LootQuest.Models.Exploring.Position PositionToExplorePosition(Vector3 pos) {
            return new LootQuest.Models.Exploring.Position(PositionToExplorePosition(pos.x), PositionToExplorePosition(pos.z));
        }

        private int PositionToExplorePosition(float pos) {
            return (int)((pos + (UnitsPerPosition / 2f * (pos < 0f ? -1f : 1f))) / UnitsPerPosition);
        }

        public void DrawGrid() {
            for (int i = -50; i < 50; i++) {
                float gridPos = UnitsPerPosition * i + UnitsPerPosition / 2f;// = PositionToExplorePosition((float)i);
                Debug.DrawLine(new Vector3(-100f, 0.25f, gridPos) + DrawnGridOffset, new Vector3(100f, 0.25f, gridPos) + DrawnGridOffset, Color.red);
                Debug.DrawLine(new Vector3(gridPos, 0.25f, -100f) + DrawnGridOffset, new Vector3(gridPos, 0.25f, 100f) + DrawnGridOffset, Color.red);
            }
        }
    }
}