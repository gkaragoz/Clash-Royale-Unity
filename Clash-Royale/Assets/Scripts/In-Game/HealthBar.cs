using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Image _imgFill = null;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private RectTransform _healthBar;
    [SerializeField]
    [Utils.ReadOnly]
    private Transform _targetTransform;
    [SerializeField]
    [Utils.ReadOnly]
    private RectTransform _targetCanvas;

    private void Awake() {
        _healthBar = GetComponent<RectTransform>();
    }

    private void Update() {
        RepositionHealthBar();
    }

    private void RepositionHealthBar() {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(_targetTransform.position);

        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * _targetCanvas.sizeDelta.x) - (_targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * _targetCanvas.sizeDelta.y) - (_targetCanvas.sizeDelta.y*.42f)));
        _healthBar.anchoredPosition = WorldObject_ScreenPosition;
    }

    public void SetHealthBarData(Transform targetTransform, RectTransform targetCanvas) {
        _targetTransform = targetTransform;
        _targetCanvas = targetCanvas;
        transform.SetParent(targetCanvas);
        Show();
        
        RepositionHealthBar();
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void OnHealthChanged(float healthFill) {
        _imgFill.fillAmount = healthFill;
    }

}