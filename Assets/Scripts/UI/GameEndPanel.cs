using Architecture;
using UnityEngine;

namespace UI {
    public class GameEndPanel : MonoBehaviour {
        [SerializeField] private GameLifeCycle _gameLifeCycle;

        private void Awake() {
            _gameLifeCycle.Wined += OnGameEnd;
            _gameLifeCycle.Losed += OnGameEnd;
            _gameLifeCycle.Started += OnGameStart;
        }

        private void OnDestroy() {
            _gameLifeCycle.Wined += OnGameEnd;
            _gameLifeCycle.Losed += OnGameEnd;
            _gameLifeCycle.Started += OnGameStart;
        }

        private void OnGameEnd() => gameObject.SetActive(true);
        private void OnGameStart() => gameObject.SetActive(false);
    }
}
