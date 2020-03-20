using UnityEngine;

public class Center : Building {

    public override void Awake() {
        //base.Awake();

        //Debug.Log("Poseidon awake.");

        //Deploy();
    }

    public override void Deploy() {
        base.Deploy();

        Debug.Log("Final deployed");
    }

    public override void MoveTo(Vector2 position) {
        base.MoveTo(position);
    }

}
