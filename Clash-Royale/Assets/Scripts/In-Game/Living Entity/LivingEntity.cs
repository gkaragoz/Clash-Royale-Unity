using UnityEngine;

public class LivingEntity : MonoBehaviour, ILivingEntity, IPooledObject {

    private const string CLASS_NAME = "[LIVING ENTITY]";

    public virtual void Awake() {
        Debug.Log(CLASS_NAME + " awake.");
    }

    public virtual void Deploy() {
        Debug.Log(CLASS_NAME + this.gameObject.name + " Deployed.");
    }

    public virtual void MoveTo(Transform target) {
        Debug.Log(CLASS_NAME + this.gameObject.name + " MoveTo " + target.name + " transform.");
    }

    public virtual void MoveTo(Vector2 position) {
        Debug.Log(CLASS_NAME + this.gameObject.name + " MoveTo " + position + " position.");
    }

    public virtual void MoveTo(LivingEntity entity) {
        Debug.Log(CLASS_NAME + this.gameObject.name + " MoveTo " + entity.name + " entity.");
    }

    public virtual void AttackTo(LivingEntity entity) {
        Debug.Log(CLASS_NAME + this.gameObject.name + " AttackTo " + entity.name + " entity.");
    }

    public virtual void Die() {
        Debug.Log(CLASS_NAME + this.gameObject.name + " is going to die.");
    }

    public virtual void OnObjectReused() {
        Debug.Log("OnObjectReused");
    }

}
