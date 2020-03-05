using UnityEngine;

public class UIGridSnap : MonoBehaviour {

    public float offset = 1f;

    [Header("Initializations")]
    [SerializeField]
    public Grid grid = null;
    [SerializeField]
    private Transform _gridSnapIndicator = null;

    private Camera _cam;
    private RaycastHit2D _hit2D;

    public Vector2 GetIndicatorPosition { 
        get {
            return _gridSnapIndicator.position;       
        }
    }

    private void Awake() {
        _cam = Camera.main;
    }

    private void Update() {
        _hit2D = Physics2D.Raycast(_cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
    public Vector2 rotate(Vector2 v, float delta) {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
    private void OnDrawGizmos() {
        if (_hit2D != false) {
            Gizmos.color = Color.red;
            Vector2 centerPoint = _hit2D.collider.bounds.min;
            Vector2 hitPoint = _hit2D.point;

            Vector2 direction = hitPoint - centerPoint;
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(centerPoint, direction);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(hitPoint, 0.1f);

            Vector2 differenceVector = hitPoint - centerPoint;
            Vector2 finalPosition = Vector2.zero;
            if (Vector2.Distance(hitPoint, _hit2D.collider.bounds.min) < Vector2.Distance(hitPoint, _hit2D.collider.bounds.max)) {
                // Bottom Left
                if (differenceVector.x < differenceVector.y) {
                    // Choose X
                    finalPosition = new Vector2(_hit2D.collider.bounds.min.x - grid.cellSize.x / 2, hitPoint.y);
                } else {
                    // Choose Y
                    finalPosition = new Vector2(hitPoint.x, _hit2D.collider.bounds.min.y - grid.cellSize.y / 2);
                }
            } else {
                // Upper Right
                if (differenceVector.x > differenceVector.y) {
                    // Choose Y
                    finalPosition = new Vector2(_hit2D.collider.bounds.max.x + grid.cellSize.x / 2, hitPoint.y);
                } else {
                    // Choose X
                    finalPosition = new Vector2(hitPoint.x, _hit2D.collider.bounds.max.y + grid.cellSize.y / 2);
                }
            }

            Gizmos.DrawSphere(finalPosition, 0.1f);
            _gridSnapIndicator.position = grid.GetCellCenterWorld(Vector3Int.FloorToInt(new Vector2(finalPosition.x / grid.cellSize.x, finalPosition.y / grid.cellSize.y)));
        } else {
            if (grid == null || _gridSnapIndicator == null || _cam == null)
                return;

            Vector3 mouseWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 gridLogicPosition = new Vector3(mouseWorldPosition.x / grid.cellSize.x, mouseWorldPosition.y / grid.cellSize.y, 0f);
            _gridSnapIndicator.position = grid.GetCellCenterWorld(Vector3Int.FloorToInt(gridLogicPosition));
        }
    }
}
