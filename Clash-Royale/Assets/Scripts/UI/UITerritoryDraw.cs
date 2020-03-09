using UnityEngine;

public class UITerritoryDraw : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Color _territoryColor = Color.red;
    [Header("Left Territory Settings")]
    [SerializeField]
    private TerritoryDraw _leftTerritory = null;
    [Header("Right Territory Settings")]
    [SerializeField]
    private TerritoryDraw _rightTerritory = null;

    public void DestroyTerritory(int index) {
        switch (index) {
            case 0:
                _leftTerritory.size.y = _leftTerritory.onDestroyedY;
                break;
            case 1:
                _rightTerritory.size.y = _rightTerritory.onDestroyedY;
                break;
        }
    }

    private void OnGUI() {
        DrawRect.DrawRectangle(new Rect(_leftTerritory.position.x, _leftTerritory.position.y, _leftTerritory.size.x, _leftTerritory.size.y), _territoryColor);
        DrawRect.DrawRectangle(new Rect(_rightTerritory.position.x, _rightTerritory.position.y, _rightTerritory.size.x, _rightTerritory.size.y), _territoryColor);
    }

}

[System.Serializable]
public class TerritoryDraw {
    public Vector2 position = Vector2.zero;
    public Vector2 size = Vector2.one;
    public float onDestroyedY = 595f;
}
