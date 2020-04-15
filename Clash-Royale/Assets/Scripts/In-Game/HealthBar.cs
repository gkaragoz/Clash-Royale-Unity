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
    private ICanDamageable _targetDamageble;
    [SerializeField]
    [Utils.ReadOnly]
    private RectTransform _targetCanvas;

    private void Awake() {
        _healthBar = GetComponent<RectTransform>();
        _targetCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }

    private void Update() {
        if (_targetTransform.gameObject.activeSelf)
        {
        RepositionHealthBar();
        }
        else
        {
            Hide();
        }
    }

    private void RepositionHealthBar() {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(_targetTransform.position);

        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * _targetCanvas.sizeDelta.x) - (_targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * _targetCanvas.sizeDelta.y) - (_targetCanvas.sizeDelta.y*.42f)));
        _healthBar.anchoredPosition = WorldObject_ScreenPosition;
        OnHealthChanged(_targetDamageble.Health/_targetDamageble.MaxHealth);
    }

    public void SetHealthBarData(Transform targetTransform) {
        _targetTransform = targetTransform;
        _targetDamageble = targetTransform.GetComponent<ICanDamageable>();
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