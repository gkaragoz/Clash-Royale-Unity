using UnityEngine;

public class UICardPlacer : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private int _row = 3;
    [SerializeField]
    private int _column = 3;
    [SerializeField]
    private LayerMask _layerMask = -1;
    [SerializeField]
    private BoxCollider2D _pathFinderCollider = null;

    [SerializeField]
    [Utils.ReadOnly]
    private bool _isColliding;
    [SerializeField]
    [Utils.ReadOnly]
    private bool _build = false;

    [SerializeField]
    [Utils.ReadOnly]
    private UICardSnap _positionData;
    [SerializeField]
    [Utils.ReadOnly]
    private SpriteRenderer _renderSprite;
    [SerializeField]
    [Utils.ReadOnly]
    private Collider2D _buildableArea;

    private void Awake() {
        _renderSprite = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        _positionData = GameObject.Find("__UICardSnap").GetComponent<UICardSnap>();
    }

    private void Update() {
        if (!_build) {
            _renderSprite.color = Color.white;

            transform.position = _positionData.ExportPosition();

            _buildableArea = Physics2D.OverlapBox(transform.position - new Vector3(0, .5f, 0), new Vector2(0.585f * _row, .5f * _column), 0, _layerMask);
            if (_buildableArea != null) {
                _renderSprite.color = Color.red;
                _isColliding = true;
            } else {
                _isColliding = false;
            }
            if (Input.GetMouseButtonDown(0)) {
                if (!_isColliding) {
                    _build = true;
                    _pathFinderCollider.gameObject.SetActive(true);
                }
            }
        } else {
            return;
        }
    }
}
