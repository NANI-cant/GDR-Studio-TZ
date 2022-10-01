using Metrics;
using PathLogic;
using UnityEngine;

namespace Player {
    public class PlayerMover : MonoBehaviour {
        [SerializeField] private PlayerMetric _metric;
        [SerializeField] private Path _path;

        private const float Accuracy = 0.1f;

        private Transform _transform;
        private Vector2 _destination;

        private void Awake() => _transform = transform;

        public void Move() {
            UpdateDestination();
            HandleArriving();
            Translate();
        }

        private void UpdateDestination() {
            if (!_path.TryGetCurrent(out _destination)) {
                _destination = _transform.position;
            }
        }

        private void HandleArriving() {
            float distance = Vector2.Distance(_transform.position, _destination);
            if (distance < Accuracy) {
                _path.Next();
                UpdateDestination();
            }
        }

        private void Translate() {
            Vector2 direction = (_destination - (Vector2)_transform.position).normalized;
            _transform.Translate(direction * _metric.Speed * Time.deltaTime);
        }
    }
}
