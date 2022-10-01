using System;
using Architecture;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerBehaviour : MonoBehaviour {
        [SerializeField] private GameLifeCycle _gameLifeCycle;

        public event Action Died;

        private PlayerMover _mover;

        private void Awake() {
            _mover = GetComponent<PlayerMover>();
            _gameLifeCycle.Started += OnStart;
        }

        private void OnDestroy() => _gameLifeCycle.Started -= OnStart;
        private void Update() => _mover.Move();

        public void Die() {
            Died?.Invoke();
            gameObject.SetActive(false);
        }

        private void OnStart() {
            transform.position = Vector3.zero;
            gameObject.SetActive(true);
        }
    }
}
