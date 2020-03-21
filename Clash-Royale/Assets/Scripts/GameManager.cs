using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton

    public static GameManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    #endregion

    private void Start() {
        ObjectPooler.instance.InitializePool("Ingame_Poseidon");
        ObjectPooler.instance.InitializePool("Ingame_StaticBuilding");

    }

    public void Ins() {
        GameObject obj = ObjectPooler.instance.SpawnFromPool("Ingame_Poseidon", new Vector2(5, 5), Quaternion.identity);
    }

    public float vSliderValue = 0.0f;

    void OnGUI() {
        vSliderValue = GUI.VerticalSlider(new Rect(Screen.width - 30, Screen.height / 4 , 30, Screen.height / 2), vSliderValue, 25.5f, 5f);

        GUIStyle s = new GUIStyle();
        s.fontSize = 50;
        
        GUI.Label(new Rect(Screen.width - 30, Screen.height / 4, 100, 100), vSliderValue.ToString(), s);
        Camera.main.orthographicSize = vSliderValue;
    }

}
