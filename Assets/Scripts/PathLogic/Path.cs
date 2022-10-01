using System;
using System.Collections.Generic;
using Architecture;
using InputServicing;
using UnityEngine;

namespace PathLogic {
    public class Path : MonoBehaviour {
        [SerializeField] private InputService _input;
        [SerializeField] private GameLifeCycle _gameLifeCycle;

        public event Action Changed;

        private Queue<Vector2> _pathQueue = new Queue<Vector2>();

        public IEnumerable<Vector2> PathPositions => _pathQueue;

        private void OnEnable() {
            _input.Clicked += Add;
            _gameLifeCycle.Losed += Clear;
            _gameLifeCycle.Wined += Clear;
        }

        private void OnDisable() {
            _gameLifeCycle.Losed -= Clear;
            _gameLifeCycle.Wined -= Clear;
        }

        public bool TryGetCurrent(out Vector2 position) {
            return _pathQueue.TryPeek(out position);
        }

        public void Next() {
            _pathQueue.TryDequeue(out Vector2 position);
            Changed?.Invoke();
        }

        private void Add(Vector2 position) {
            _pathQueue.Enqueue(position);
            Changed?.Invoke();
        }

        private void Clear() {
            _pathQueue.Clear();
            Changed?.Invoke();
        }
    }
}
