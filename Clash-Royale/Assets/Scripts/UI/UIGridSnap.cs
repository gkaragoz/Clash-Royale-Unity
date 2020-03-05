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
            Vector2 centerPoint = new Vector2(_hit2D.transform.position.x, _hit2D.transform.position.y);
            Vector2 hitPoint = _hit2D.point;

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(hitPoint, 0.1f);

            Vector2 direction = hitPoint - centerPoint;
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(centerPoint, direction);

            float angle = AnimationExtensions.GetAngleFromVector2(direction);
            if (angle > 45) {
                angle = 90 - angle;
            } else {
                Gizmos.color = Color.red;
                Vector2 rotatedDirection = rotate(direction, angle);
                Gizmos.DrawRay(rotatedDirection, direction);
            }
        }

        //if (_hit2D != false) {
        //    Gizmos.color = Color.red;
        //    Vector2 centerPoint = new Vector2(_hit2D.transform.position.x, _hit2D.transform.position.y);
        //    Vector2 hitPoint = _hit2D.point;

        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawSphere(hitPoint, 0.1f);

        //    Vector2 direction = hitPoint - centerPoint;
        //    Gizmos.color = Color.cyan;
        //    Gizmos.DrawRay(centerPoint, direction);

        //    Vector2 upperRight = _hit2D.collider.bounds.max;
        //    Vector2 lowerLeft = _hit2D.collider.bounds.min;
        //    Vector2 upperLeft = upperRight - (Vector2.right * _hit2D.collider.bounds.size.x);
        //    Vector2 lowerRight = upperRight - (Vector2.up * _hit2D.collider.bounds.size.y);

        //    // Area I   : +, +
        //    // Area II  : -, +
        //    // Area III : -, -
        //    // Area IV  : +, -
        //    Vector2 indicatorPosition = hitPoint;
        //    if (direction.x > 0 && direction.y > 0) {
        //        // Upper Right
        //        Vector2 comparisonVector = upperRight - hitPoint;

        //        if (comparisonVector.x < comparisonVector.y) {
        //            indicatorPosition = new Vector2(hitPoint.x + comparisonVector.x, hitPoint.y);
        //        } else {
        //            indicatorPosition = new Vector2(hitPoint.x, hitPoint.y + comparisonVector.y);
        //        }
        //    } else if (direction.x < 0 && direction.y > 0) {
        //        // Upper Left
        //    } else if (direction.x < 0 && direction.y < 0) {
        //        // Lower Left
        //    } else if (direction.x > 0 && direction.y < 0) {
        //        // Lower Right
        //    }

        //    Gizmos.DrawSphere(indicatorPosition, 0.2f);
        //}


        ///////////////////////////////////////////////////////////
        //if (grid == null || _gridSnapIndicator == null || _cam == null)
        //    return;


        //Vector3 mouseWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 gridLogicPosition = new Vector3(mouseWorldPosition.x / grid.cellSize.x, mouseWorldPosition.y / grid.cellSize.y, 0f);
        //_gridSnapIndicator.position = grid.GetCellCenterWorld(Vector3Int.FloorToInt(gridLogicPosition));
    }
}
