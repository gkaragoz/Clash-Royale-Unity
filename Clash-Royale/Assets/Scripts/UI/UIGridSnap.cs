using Pathfinding;
using UnityEngine;

public class UIGridSnap : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    public Grid grid = null;
    [SerializeField]
    private Transform _gridSnapIndicator = null;
    [SerializeField]
    private AIDestinationSetter _cardPrefab = null;
    [SerializeField]
    private Transform _targetTransform = null;

    [Header("Debug")]
    [SerializeField]
    private float _maxInputHeightLeft;
    [SerializeField]
    private float _maxInputHeightRight;
    [SerializeField]
    private bool _cardReleaseMode = false;

    private Camera _cam;
    private RaycastHit2D _hit2D;

    public bool CardReleaseMode { 
        get {
            return _cardReleaseMode;
        } 
        set {
            _cardReleaseMode = value;
            if (!_cardReleaseMode) {
                _gridSnapIndicator.position = Vector3.zero;
            }
        } 
    }

    public Vector2 GetIndicatorPosition {
        get {
            return _gridSnapIndicator.position;
        }
    }

    private void Awake() {
        _cam = Camera.main;
    }

    private void Update() {
        Vector2 mouseWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        _hit2D = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);

        if (Input.GetMouseButtonDown(0) && CardReleaseMode) {
            Instantiate(_cardPrefab, _gridSnapIndicator.position, Quaternion.identity).target = _targetTransform;
        }

        if (Input.GetMouseButtonDown(0) && !Utils.IsPointerOverUIObject()) {
            if (!CardReleaseMode) {
                _targetTransform.position = mouseWorldPosition;
            }
        }
    }
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(new Vector3(0, _maxInputHeightLeft, 0), new Vector3(6.5f, _maxInputHeightLeft, 0));
        Gizmos.color = Color.white;

        Gizmos.DrawLine(new Vector3(6.5f, _maxInputHeightRight, 0), new Vector3(13f, _maxInputHeightRight, 0));

        if (!CardReleaseMode) {
            return;
        }

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= 6.5f) {

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < _maxInputHeightRight) {

                if (_hit2D != false) {
                    Gizmos.color = Color.red;
                    Vector2 centerPoint = _hit2D.collider.bounds.min;
                    Vector2 hitPoint = _hit2D.point;

                    Vector2 direction = hitPoint - centerPoint;
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawRay(centerPoint, direction);

                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(hitPoint, 0.1f);

                    Vector2 rightUp = _hit2D.collider.bounds.max;
                    Vector2 rightDown = new Vector2(_hit2D.collider.bounds.max.x, _hit2D.collider.bounds.min.y);
                    Vector2 leftUp = new Vector2(_hit2D.collider.bounds.min.x, _hit2D.collider.bounds.max.y);
                    Vector2 leftDown = _hit2D.collider.bounds.min;
                    Vector2[] pointsArray = new Vector2[] { rightUp, rightDown, leftDown, leftUp };
                    Vector2 finalPosition = Vector2.zero;
                    Vector2 closestPoint = pointsArray[0];
                    Vector2 differenceVector = Vector2.zero;

                    // Find the closest point to hitPoint
                    for (int i = 0; i < pointsArray.Length; i++) {
                        if (Vector2.Distance(hitPoint, pointsArray[i]) <= Vector2.Distance(hitPoint, closestPoint)) {
                            closestPoint = pointsArray[i];
                            differenceVector = closestPoint - hitPoint;
                        }
                    }

                    if (Mathf.Abs(differenceVector.x) < (Mathf.Abs(differenceVector.y))) {
                        if (differenceVector.x < 0) {
                            // Choose X
                            finalPosition = new Vector2(closestPoint.x - grid.cellSize.x / 2, hitPoint.y);
                        } else {
                            // Choose X
                            finalPosition = new Vector2(closestPoint.x + grid.cellSize.x / 2, hitPoint.y);
                        }
                    } else {
                        if (differenceVector.y < 0) {
                            // Choose Y
                            finalPosition = new Vector2(hitPoint.x, closestPoint.y - grid.cellSize.y / 2);
                        } else {
                            // Choose Y
                            finalPosition = new Vector2(hitPoint.x, closestPoint.y + grid.cellSize.y / 2);
                        }
                    }

                    Gizmos.DrawSphere(finalPosition, 0.1f);
                    Gizmos.DrawSphere(closestPoint, 0.1f);
                    _gridSnapIndicator.position = grid.GetCellCenterWorld(Vector3Int.FloorToInt(new Vector2(finalPosition.x / grid.cellSize.x, finalPosition.y / grid.cellSize.y)));
                } else {
                    if (grid == null || _gridSnapIndicator == null || _cam == null)
                        return;

                    Vector3 mouseWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 gridLogicPosition = new Vector3(mouseWorldPosition.x / grid.cellSize.x, mouseWorldPosition.y / grid.cellSize.y, 0f);
                    _gridSnapIndicator.position = grid.GetCellCenterWorld(Vector3Int.FloorToInt(gridLogicPosition));
                }
            }
        } else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 6.5f) {

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < _maxInputHeightLeft) {

                if (_hit2D != false) {
                    Gizmos.color = Color.red;
                    Vector2 centerPoint = _hit2D.collider.bounds.min;
                    Vector2 hitPoint = _hit2D.point;

                    Vector2 direction = hitPoint - centerPoint;
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawRay(centerPoint, direction);

                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(hitPoint, 0.1f);

                    Vector2 rightUp = _hit2D.collider.bounds.max;
                    Vector2 rightDown = new Vector2(_hit2D.collider.bounds.max.x, _hit2D.collider.bounds.min.y);
                    Vector2 leftUp = new Vector2(_hit2D.collider.bounds.min.x, _hit2D.collider.bounds.max.y);
                    Vector2 leftDown = _hit2D.collider.bounds.min;
                    Vector2[] pointsArray = new Vector2[] { rightUp, rightDown, leftDown, leftUp };
                    Vector2 finalPosition = Vector2.zero;
                    Vector2 closestPoint = pointsArray[0];
                    Vector2 differenceVector = Vector2.zero;
                    // Find the closest point to hitPoint
                    for (int i = 0; i < pointsArray.Length; i++) {
                        if (Vector2.Distance(hitPoint, pointsArray[i]) <= Vector2.Distance(hitPoint, closestPoint)) {
                            closestPoint = pointsArray[i];
                            differenceVector = closestPoint - hitPoint;
                        }
                    }

                    if (Mathf.Abs(differenceVector.x) < (Mathf.Abs(differenceVector.y))) {
                        if (differenceVector.x < 0) {
                            // Choose X
                            finalPosition = new Vector2(closestPoint.x - grid.cellSize.x / 2, hitPoint.y);
                        } else {
                            // Choose X
                            finalPosition = new Vector2(closestPoint.x + grid.cellSize.x / 2, hitPoint.y);
                        }
                    } else {
                        if (differenceVector.y < 0) {
                            // Choose Y
                            finalPosition = new Vector2(hitPoint.x, closestPoint.y - grid.cellSize.y / 2);
                        } else {
                            // Choose Y
                            finalPosition = new Vector2(hitPoint.x, closestPoint.y + grid.cellSize.y / 2);
                        }
                    }

                    Gizmos.DrawSphere(finalPosition, 0.1f);
                    Gizmos.DrawSphere(closestPoint, 0.1f);
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
    }

    public void DestroyTower(int index) {
        switch (index) {
            case 0:
                _maxInputHeightLeft = 16;
                break;
            case 1:
                _maxInputHeightRight = 16;
                break;
        }
    }


}
