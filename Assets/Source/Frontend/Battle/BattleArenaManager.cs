using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Frontend.Battle {
    public class BattleArenaManager : MonoBehaviour
    {
        private struct ParticipantWorldData {
            public Transform Refference;
            public Vector3 Position;
            public Vector3 Rotation;
        }

        public bool IsDefault = false;
        public Transform[] PlacementMarkers;
        public Camera BattleCamera;

        private List<Frontend.Entity.EntityMaster> _participants;
        private ParticipantWorldData[] _participantWorldData;

        void Awake() {
            BattleCamera.gameObject.SetActive(false);
        }

        void Start() {
            if (IsDefault) {
                Frontend.Master.Shared.BattleManager.ArenaManager = this;
            }
        }

        public void Setup(List<Frontend.Entity.EntityMaster> entities) {
            _participants = entities;
            _participantWorldData = new ParticipantWorldData[entities.Count];
            for (int i = 0; i < entities.Count; i++) {
                _participantWorldData[i] = new ParticipantWorldData() {
                    Refference = entities[i].transform,
                    Position = entities[i].transform.position,
                    Rotation = entities[i].transform.eulerAngles
                };
                entities[i].transform.position = PlacementMarkers[i].position;
            }

            BattleCamera.gameObject.SetActive(true);
        }

        public void Close() {
            for (int i = 0; i < _participants.Count; i++) {
                _participants[i].transform.position = _participantWorldData[i].Position;
                _participants[i].transform.eulerAngles = _participantWorldData[i].Rotation;
            }

            BattleCamera.gameObject.SetActive(false);
        }
    }
}