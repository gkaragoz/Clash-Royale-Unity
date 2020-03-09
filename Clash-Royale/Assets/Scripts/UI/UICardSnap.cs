using UnityEngine;

public class UICardSnap : MonoBehaviour {

    public new Collider2D collider;
    public Vector2 closestPoint;

    private void Update() {
        closestPoint = Physics2D.ClosestPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), collider);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(closestPoint, 0.25f);
    }

}
