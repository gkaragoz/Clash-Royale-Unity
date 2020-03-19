using UnityEngine;

public abstract class LivingEntity : MonoBehaviour, ILivingEntity {

    public abstract void MoveTo(Transform target);

    public abstract void MoveTo(Vector2 position);

    public abstract void MoveTo(LivingEntity entity);

    public abstract void AttackTo(LivingEntity entity);

    public abstract void Die();

}
