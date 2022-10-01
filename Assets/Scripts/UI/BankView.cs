using Stats;
using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BankView : MonoBehaviour {
        [SerializeField] private Bank _model;

        private TextMeshProUGUI _gui;

        private void Awake() => _gui = GetComponent<TextMeshProUGUI>();
        private void Start() => UpdateUI();

        private void OnEnable() => _model.Changed += UpdateUI;
        private void OnDisable() => _model.Changed -= UpdateUI;

        private void UpdateUI() {
            _gui.text = _model.Amount.ToString();
        }
    }
}
