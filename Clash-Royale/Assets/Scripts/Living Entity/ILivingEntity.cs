using UnityEngine;

public interface ILivingEntity {

    void MoveTo(Transform target);

    void MoveTo(Vector2 position);

    void MoveTo(LivingEntity entity);

    void AttackTo(LivingEntity entity);

    void Die();

}
