public interface ILivingEntity {

    void Deploy();

    void MoveTo(ILivingEntity target);

    void AttackTo(ILivingEntity entity);

    void Die();

}
