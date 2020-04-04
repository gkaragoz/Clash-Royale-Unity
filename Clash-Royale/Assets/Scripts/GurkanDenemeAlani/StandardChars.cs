using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardChars : MonoBehaviour, IAliveObject
{
    public float Health { get ; set; }
    public LivingEntityTypes CharacterType { get ; set ; }

    public virtual void Deploy()
    {
    }

    public virtual void Die()
    {
    }

    public virtual void TakeDamage(float damageAmount)
    {

    }

    public void TakeHeal(float healAmount)
    {

    }
   

   


}
