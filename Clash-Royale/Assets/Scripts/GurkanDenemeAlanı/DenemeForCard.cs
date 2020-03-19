using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DenemeForCard : MonoBehaviour {

    public List<Button> buttons;

    public GameObject troopPrefab;
    public GameObject troopPrefabHighLight;
    public GameObject buildingPrefab;
    public GameObject buildingPrefabHighLight;
    public GameObject birdPrefab;
    public GameObject objectHolder;

    bool isSelected;

    [SerializeField]
    int currentIndex = 10;
    [SerializeField]
    Vector3[] firstSize;
    int fixedUpdateCount;

    private void Start() {
        firstSize = new Vector3[buttons.Count];
        for (int i = 0; i < buttons.Count; i++) {
            firstSize[i] = buttons[i].transform.position;
        }
    }

    public void SelectUICardButton(int index) {

        if (currentIndex != index) {

            isSelected = true;

            currentIndex = index;
            buttons[index].transform.position = Vector3.up * 20 + buttons[index].transform.position;


            for (int i = 0; i < buttons.Count; i++) {
                if (i == index) {
                    continue;
                }
                buttons[i].transform.position = firstSize[i];
            }



            switch (index) {
                case 0:
                    StartCoroutine(SelectCard(troopPrefab, troopPrefabHighLight));
                    break;
                case 1:
                    StartCoroutine(SelectCard(buildingPrefab, buildingPrefabHighLight));
                    break;
                default:
                    break;
            }
        }

    }



    IEnumerator SelectCard(GameObject card, GameObject high) {
        GameObject cloneObje = Instantiate(card, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);


        while (isSelected) {

            Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cloneObje.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;  // Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;

            // cloneObje.transform.position = Vector3.MoveTowards(cloneObje.transform.position, new Vector3(cam.x, cam.y, 0), 200 * Time.deltaTime); ;   // Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            if (Input.GetMouseButtonDown(0)) {
                //  Destroy(cloneObje);
                //Instantiate(card, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                isSelected = false;
            }

            yield return new WaitForFixedUpdate();
        }


    }



}
