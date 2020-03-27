using UnityEngine;

public class LivingEntity : MonoBehaviour, ILivingEntity, IPooledObject {

    private const string CLASS_NAME = "[LIVING ENTITY]";

    public virtual void Awake() {
    }

    public virtual void Deploy() {
    }

    public virtual void MoveTo(ILivingEntity target) {
    }

    public virtual void AttackTo(LivingEntity entity) {
    }

    public virtual void Die() {
    }

    public virtual void OnObjectReused() {
    }

}
