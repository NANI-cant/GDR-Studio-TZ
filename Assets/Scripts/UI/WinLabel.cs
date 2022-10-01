using Architecture;
using UnityEngine;

namespace UI {
    public class WinLabel : MonoBehaviour {
        [SerializeField] private GameLifeCycle _gameLifeCycle;

        private void Awake() {
            _gameLifeCycle.Wined += OnWin;
            _gameLifeCycle.Losed += OnLose;
        }

        private void OnDestroy() {
            _gameLifeCycle.Wined -= OnWin;
            _gameLifeCycle.Losed -= OnLose;
        }

        private void OnWin() => gameObject.SetActive(true);
        private void OnLose() => gameObject.SetActive(false);
    }
}
