using System.Collections.Generic;
using Player;
using UnityEngine;

namespace PathLogic {
    [RequireComponent(typeof(LineRenderer))]
    public class PathDrawer : MonoBehaviour {
        [SerializeField] private Path _path;
        [SerializeField] private PlayerBehaviour _player;

        private LineRenderer _line;

        private void Awake() {
            _line = GetComponent<LineRenderer>();
        }

        private void Start() {
            _line.useWorldSpace = true;
            _line.positionCount = 1;
            _line.SetPosition(0, _player.transform.position);
        }

        private void OnEnable() => _path.Changed += OnChanged;
        private void OnDisable() => _path.Changed -= OnChanged;

        private void Update() {
            _line.SetPosition(0, _player.transform.position);
        }

        private void OnChanged() {
            List<Vector3> positions = new List<Vector3>();

            positions.Add(_player.transform.position);
            foreach (var position2D in _path.PathPositions) {
                positions.Add(position2D);
            }

            _line.positionCount = positions.Count;
            _line.SetPositions(positions.ToArray());
        }
    }
}
