using System;
using Architecture;
using UnityEngine;

namespace Stats {
    public class Bank : MonoBehaviour {
        [SerializeField] private GameLifeCycle _gameLifeCycle;

        public event Action Changed;

        public int Amount { get; private set; }

        private void OnEnable() => _gameLifeCycle.Started += Clear;
        private void OnDisable() => _gameLifeCycle.Started -= Clear;

        public void Earn() {
            Amount++;
            Changed?.Invoke();
        }

        private void Clear() {
            Amount = 0;
            Changed?.Invoke();
        }
    }
}
