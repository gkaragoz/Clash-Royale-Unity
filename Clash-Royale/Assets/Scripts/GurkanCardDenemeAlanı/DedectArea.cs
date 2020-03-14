using UnityEngine;

public class DedectArea : MonoBehaviour {
    bool isCollide;
    bool build = false;
    UICardSnap positionData;
    SpriteRenderer renderSprite;
    public int[] buildSize = new int[2];
    public LayerMask layerMask;
    Collider2D col;


    public GameObject pathFinderCollisionObject;
    private void Awake() {
        renderSprite = GetComponent<SpriteRenderer>();
    }
    private void Start() {
        positionData = GameObject.Find("__UICardSnap").GetComponent<UICardSnap>();

    }




    private void Update() {
        if (!build) {
            renderSprite.color = Color.white;



            transform.position = positionData.ExportPosition();

            Debug.Log(isCollide);
            col = Physics2D.OverlapBox(transform.position - new Vector3(0, .5f, 0), new Vector2(0.585f * buildSize[0], .5f * buildSize[0]), 0, layerMask);
            if (col != null) {

                renderSprite.color = Color.red;
                isCollide = true;
            } else {
                isCollide = false;
            }
            if (Input.GetMouseButtonDown(0)) {
                if (!isCollide) {
                    build = true;
                    pathFinderCollisionObject.SetActive(true);
                }
            }
        } else {
            return;
        }



    }


}
