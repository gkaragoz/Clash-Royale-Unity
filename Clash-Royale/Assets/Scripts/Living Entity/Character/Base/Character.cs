using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public abstract class Character : LivingEntity {

    [Header("Initializations")]
    [SerializeField]
    private CharacterStats _characterStats;

    private const string CLASS_NAME = "[CHARACTER]";

    public override void Awake() {
        base.Awake();

        Debug.Log(CLASS_NAME + " awake.");
    }

    public override void Deploy() {
        base.Deploy();

        // Timer UI tetikle
        // Deploy time kadar geriye say.
        // Hareket classlarını aktif et.

        Debug.Log(CLASS_NAME + this + " Deployed.");
    }

    public override void MoveTo(Transform target) {
        base.MoveTo(target);

        Debug.Log(CLASS_NAME + this + " MoveTo " + target.name + " transform.");
    }

    public override void MoveTo(Vector2 position) {
        base.MoveTo(position);

        Debug.Log(CLASS_NAME + this + " MoveTo " + position + " position.");
    }

    public override void MoveTo(LivingEntity entity) {
        base.MoveTo(entity);

        Debug.Log(CLASS_NAME + this + " MoveTo " + entity.name + " entity.");
    }

    public override void AttackTo(LivingEntity entity) {
        base.AttackTo(entity);

        Debug.Log(CLASS_NAME + this + " AttackTo " + entity.name + " entity.");
    }

    public override void Die() {
        base.Die();

        Debug.Log(CLASS_NAME + this + " is going to die.");
    }
}
