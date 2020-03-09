using UnityEngine;

public class UICardSnap : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Grid _grid = null;
    [SerializeField]
    private Collider2D _collider = null;
    [SerializeField]
    private Transform _cardSpawnIndicator = null;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private Vector3 _closestPoint;
    [SerializeField]
    [Utils.ReadOnly]
    private Camera _cam = null;

    private void Awake() {
        _cam = Camera.main;
    }

    private void Update() {
        _closestPoint = Physics2D.ClosestPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), _collider);

        SetCardSpawnIndicatorPosition();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_closestPoint, 0.15f);
    }

    private void SetCardSpawnIndicatorPosition() {
        Vector3 cardSpawnLogicPosition = new Vector3(_closestPoint.x / _grid.cellSize.x, _closestPoint.y / _grid.cellSize.y, 0f);
        _cardSpawnIndicator.position = _grid.GetCellCenterWorld(Vector3Int.FloorToInt(cardSpawnLogicPosition));
    }

}
