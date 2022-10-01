using System;
using Architecture;
using UnityEngine;

namespace InputServicing {
    public class InputService : MonoBehaviour {
        [SerializeField] private GameLifeCycle _gameLifeCycle;

        public event Action<Vector2> Clicked;

        private Camera _camera;
        private bool _enabled = true;

        private void Awake() => _camera = Camera.main;

        private void OnEnable() {
            _gameLifeCycle.Losed += Disable;
            _gameLifeCycle.Wined += Disable;
            _gameLifeCycle.Started += Enable;
        }

        private void OnDisable() {
            _gameLifeCycle.Losed -= Disable;
            _gameLifeCycle.Wined -= Disable;
            _gameLifeCycle.Started -= Enable;
        }

        private void Update() {
            if (!_enabled) return;

            if (Input.GetMouseButtonDown(0)) {
                Vector2 pointerWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                Clicked?.Invoke(pointerWorldPosition);
            }
        }

        private void Enable() => _enabled = true;
        private void Disable() => _enabled = false;
    }
}
