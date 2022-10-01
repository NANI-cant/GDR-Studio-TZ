using Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour {
        [SerializeField] private GameLifeCycle _gameLifeCycle;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();
        private void OnEnable() => _button.onClick.AddListener(_gameLifeCycle.StartGame);
        private void OnDisable() => _button.onClick.RemoveListener(_gameLifeCycle.StartGame);
    }
}
