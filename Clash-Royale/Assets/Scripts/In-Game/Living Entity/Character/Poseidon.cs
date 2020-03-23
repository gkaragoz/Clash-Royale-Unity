using UnityEngine;
public class Poseidon : Character {

    private GameObject _target;
    TargetManager targetManager;
    public override void Awake() {
        //base.Awake();

        //Debug.Log("Poseidon awake.");

        //Deploy();
    }

    public override void Deploy() {
        base.Deploy();


        Debug.Log("Final deployed");
        targetManager = GameObject.Find("__TargetManager").GetComponent<TargetManager>();
        targetManager.GiveMeTarget(transform);
    }

    public override void MoveTo(Vector2 position) {
        base.MoveTo(position);
    }

}
