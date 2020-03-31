using System.Collections.Generic;
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

    public List<Transform> movebleTargets; //////////////////


    public List<Transform> enemyTargets;


    private void Start() {
        ObjectPooler.instance.InitializePool("Ingame_Poseidon");
        ObjectPooler.instance.InitializePool("Ingame_StaticBuilding");
        ObjectPooler.instance.InitializePool("Ingame_HealthBar");
    }


}
