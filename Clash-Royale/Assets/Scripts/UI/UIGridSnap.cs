using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class UIGridSnap : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    public Grid grid = null;
    [SerializeField]
    private Transform _gridSnapIndicator = null;

    private Camera _cam;
   

    private void Start() {
        _cam = Camera.main;
    }
    private void OnDrawGizmos() {
        if (grid == null || _gridSnapIndicator == null || _cam == null)
            return;

        Vector3 mouseWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gridLogicPosition = new Vector3(mouseWorldPosition.x / 0.585f, mouseWorldPosition.y / 0.5f, 0f);
        _gridSnapIndicator.position = grid.GetCellCenterWorld(Vector3Int.FloorToInt(gridLogicPosition));
       
    }

    public Vector2 getGridPosition
    {
        get { return _gridSnapIndicator.position; }
       
    }




}
