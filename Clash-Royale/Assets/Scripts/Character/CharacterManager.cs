using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterManager : LivingEntity {

    [Header("Initializations")]
    [SerializeField]
    private CharacterStats _characterStats;

    public override void MoveTo(Transform target) {
        Debug.Log(this.gameObject.name + " MoveTo " + target.name + " transform.");
    }

    public override void MoveTo(Vector2 position) {
        Debug.Log(this.gameObject.name + " MoveTo " + position + " position.");
    }

    public override void MoveTo(LivingEntity entity) {
        Debug.Log(this.gameObject.name + " MoveTo " + entity.name + " entity.");
    }

    public override void AttackTo(LivingEntity entity) {
        Debug.Log(this.gameObject.name + " AttackTo " + entity.name + " entity.");
    }

    public override void Die() {
        Debug.Log(this.gameObject.name + " is going to die.");
    }

}
