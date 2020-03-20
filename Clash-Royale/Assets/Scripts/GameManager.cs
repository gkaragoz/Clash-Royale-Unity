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

        InvokeRepeating("Ins", 0f, 1f);
    }

    public void Ins() {
        GameObject obj = ObjectPooler.instance.SpawnFromPool("Ingame_Poseidon", new Vector2(5, 5), Quaternion.identity);
    }

}
