using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DenemeForCard : MonoBehaviour {
    [Header("Initializations")]
    [SerializeField]
    private Grid _grid = null;
    [Header("Area Dedection")]
    [SerializeField]
    private float availableHeightLeft;
    [SerializeField]
    private float availableHeightRight;
    [Header("Cards and Buttons")]
    public GameObject troopPrefab;
    public GameObject buildingPrefab;
    public GameObject birdPrefab;
    bool isSelected;
    [Header("Cards and Buttons")]
    [SerializeField]
    [Utils.ReadOnly]
    Vector3 mousePosToRealWorld;
    int currentIndex = 10;

    private void Start() {

    }
    private void OnDrawGizmos() {
        //
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Vector3.zero + Vector3.up * availableHeightRight, Vector3.right * 100 + Vector3.up * availableHeightRight);

        Gizmos.color = Color.black;
        Gizmos.DrawLine(Vector3.zero + Vector3.up * availableHeightLeft, Vector3.left * 100 + Vector3.up * availableHeightLeft);
    }
    public void SelectUICardButton(int index) {

        if (currentIndex != index) {

            isSelected = true;

            switch (index) {
                case 0:
                    StartCoroutine(SelectCard(troopPrefab));
                    break;
                case 1:
                    StartCoroutine(SelectCard(buildingPrefab));
                    break;
                case 2:
                    StartCoroutine(SelectCard(buildingPrefab));
                    break;
                default:
                    break;
            }
        }

    }


    /// <summary>
    /// İHTİMAL BİR
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    IEnumerator SelectCard(GameObject card) {
        GameObject cardClone = Instantiate(card, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);


        while (isSelected) {

            mousePosToRealWorld = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x / _grid.cellSize.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y / _grid.cellSize.y, 0f);

            cardClone.transform.position = _grid.GetCellCenterWorld(Vector3Int.FloorToInt(mousePosToRealWorld));


            if (Input.GetMouseButtonDown(0)) {
                if (currentIndex == 0) {
                    cardClone.AddComponent<CharacterAnimation>();
                }
                isSelected = false;
            }

            yield return new WaitForFixedUpdate();
        }


    }





    /// <summary>
    /// İHTİMAL İKİ
    /// </summary>
    /// <param name="card"></param>
    /// <param name="cardClonePicture"></param>
    /// <returns></returns>
    /* IEnumerator SelectCard(GameObject card,GameObject cardHighLightObject) {
         GameObject cloneObje = Instantiate(card, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);


         while (isSelected) {

             mousePosToRealWorld = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x / _grid.cellSize.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y / _grid.cellSize.y, 0f);


             cloneObje.transform.position = _grid.GetCellCenterWorld(Vector3Int.FloorToInt(mousePosToRealWorld));
             // cloneObje.transform.position = mousePosToRealWorld;  // Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;

             // cloneObje.transform.position = Vector3.MoveTowards(cloneObje.transform.position, new Vector3(cam.x, cam.y, 0), 200 * Time.deltaTime); ;   // Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
             if (Input.GetMouseButtonDown(0)) {
                 if (currentIndex == 0) {
                     cloneObje.AddComponent<CharacterAnimation>();

                 }
                 //Instantiate(card, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                 isSelected = false;
             }

             yield return new WaitForFixedUpdate();
         }

         */


}
