using UnityEngine;

public class CameraScreenSize : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private SpriteRenderer _area = null;

    private void Start() {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = _area.bounds.size.x / _area.bounds.size.y;

        if (screenRatio >= targetRatio) {
            Camera.main.orthographicSize = _area.bounds.size.y / 2;
        } else {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = _area.bounds.size.y / 2 * differenceInSize;
        }
    }
}



