using Player;
using UnityEngine;

namespace SpikeLogic {
    [RequireComponent(typeof(Collider2D))]
    public class Spike : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D collider) {
            if (collider.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour _player)) {
                _player.Die();
            }
        }
    }
}
