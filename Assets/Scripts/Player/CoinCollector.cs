using CoinLogic;
using Stats;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(Collider2D))]
    public class CoinCollector : MonoBehaviour {
        [SerializeField] private Bank _bank;

        private void OnTriggerEnter2D(Collider2D collider) {
            if (collider.TryGetComponent<Coin>(out Coin coin)) {
                coin.Collect();
                _bank.Earn();
            }
        }
    }
}
