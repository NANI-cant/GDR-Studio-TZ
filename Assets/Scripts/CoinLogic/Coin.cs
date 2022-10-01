using System;
using UnityEngine;

namespace CoinLogic {
    [RequireComponent(typeof(Collider2D))]
    public class Coin : MonoBehaviour {
        public event Action Collected;

        public void Collect() {
            Collected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
