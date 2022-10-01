using UnityEngine;

namespace Metrics {
    [CreateAssetMenu(fileName = "Player Metric", menuName = "Metrics/Player Metric")]
    public class PlayerMetric : ScriptableObject {
        [SerializeField][Min(0f)] private float _speed = 5f;

        public float Speed => _speed;
    }
}
