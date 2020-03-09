#if UNITY_EDITOR
using UnityEngine;

[ExecuteInEditMode]
public class OrthoBoundryClamper : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private float scaleX = 1f;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private float aspectRatio = 1.77777f;

    private void Update() {
        float scaleY = scaleX * aspectRatio;
        transform.localScale = new Vector2(scaleX, scaleY);
    }

}
#endif
