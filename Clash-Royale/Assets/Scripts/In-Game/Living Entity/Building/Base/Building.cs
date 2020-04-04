using UnityEngine;

[RequireComponent(typeof(BuildingStats))]
public abstract class Building : LivingEntity {

    [Header("Initializations")]
    [SerializeField]
    private BuildingStats _buildingStats;

    private const string CLASS_NAME = "[BUILDING]";

    public override void Awake() {
        base.Awake();

        Debug.Log(CLASS_NAME + " awake.");
    }

    public override void OnObjectReused() {
        base.OnObjectReused();

        Debug.Log("On Object Reused");

        Deploy();
    }

    public override void Deploy() {
        base.Deploy();

        // a* 'ı aç. 
        // target belirle.
        // sdflksdf
        this.gameObject.SetActive(true);

        // Timer UI tetikle
        // Deploy time kadar geriye say.
        // Hareket classlarını aktif et.

        Debug.Log(CLASS_NAME + this + " Deployed.");
    }

    public override void AttackTo(ILivingEntity entity) {
        base.AttackTo(entity);

       // Debug.Log(CLASS_NAME + this + " AttackTo " + entity.name + " entity.");
    }

    public override void Die() {
        base.Die();

        Debug.Log(CLASS_NAME + this + " is going to die.");
    }
}
