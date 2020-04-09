using UnityEngine;

public interface IAliveObject
{
    float Health { get; set; }
    LivingEntityTypes CharacterType { get; set; }

    void TakeDamage(float damageAmount);
    
    void TakeHeal(float healAmount);

    void Deploy();

    void Die();

}

public interface IWalkable
{
    float MoveSpeed { get; set; }

    void Move(Transform Target);


}




public interface IFly
{
    float MoveSpeed { get; set; }
}



