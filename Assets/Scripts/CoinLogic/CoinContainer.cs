using System;
using Architecture;
using UnityEngine;

namespace CoinLogic {
    public class CoinContainer : MonoBehaviour {
        [SerializeField] private GameLifeCycle _gameLifeCycle;

        public event Action CoinsCollected;

        private Coin[] _coins;
        private int _collectingCount = 0;

        private void Awake() {
            _coins = FindObjectsOfType<Coin>();
            foreach (var coin in _coins) {
                coin.transform.parent = transform;
            }
        }

        private void Start() => EnableCoins();

        private void OnEnable() {
            _gameLifeCycle.Started += EnableCoins;

            foreach (var coin in _coins) {
                coin.Collected += OnCoinCollected;
            }
        }

        private void OnDisable() {
            _gameLifeCycle.Started -= EnableCoins;

            foreach (var coin in _coins) {
                coin.Collected -= OnCoinCollected;
            }
        }

        public void EnableCoins() {
            foreach (var coin in _coins) {
                coin.gameObject.SetActive(true);
            }
        }

        private void OnCoinCollected() {
            _collectingCount++;
            if (_collectingCount == _coins.Length) {
                _collectingCount = 0;
                CoinsCollected?.Invoke();
            }
        }
    }
}
