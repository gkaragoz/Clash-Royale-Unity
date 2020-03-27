public interface ILivingEntity {

    void Deploy();

    void MoveTo(ILivingEntity target);

    void AttackTo(LivingEntity entity);

    void Die();

}
