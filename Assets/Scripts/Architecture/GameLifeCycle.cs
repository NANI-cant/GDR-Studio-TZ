using System;
using CoinLogic;
using Player;
using UnityEngine;

namespace Architecture {
    public class GameLifeCycle : MonoBehaviour {
        [SerializeField] private PlayerBehaviour _player;
        [SerializeField] private CoinContainer _coinContainer;

        public event Action Wined;
        public event Action Losed;
        public event Action Started;

        private void Start() => StartGame();

        private void OnEnable() {
            _player.Died += OnPlayerDied;
            _coinContainer.CoinsCollected += OnCoinsCollected;
        }

        private void OnDisable() {
            _player.Died -= OnPlayerDied;
            _coinContainer.CoinsCollected -= OnCoinsCollected;
        }

        public void StartGame() => Started?.Invoke();
        private void OnPlayerDied() => Losed?.Invoke();
        private void OnCoinsCollected() => Wined?.Invoke();
    }
}
