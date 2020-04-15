using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    #region Singleton

    public static TargetManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    #endregion

    public List<Transform> movebleTargets; //////////////////    
    public List<Transform> Player1TargetList;
    public List<Transform> Player2TargetList;


   public void StartTargetMatch()
    {
        foreach (LivingEntity go in Resources.FindObjectsOfTypeAll(typeof(LivingEntity)) as LivingEntity[])
        {
            Debug.Log(go.GetPlayerId());
            if (go.GetPlayerId()==-1)
            {
               Player1TargetList.Add( go.gameObject.transform);
            }
            else if(go.GetPlayerId() == 1)
            {
                Player2TargetList.Add(go.gameObject.transform);

            }
        }
    }


    public List<Transform> GetMyTargetList(LivingEntity user)
    {       
        List<Transform> tempList=new List<Transform>();
        switch (user.GetPlayerId())
        {
            case 1:
                Character userCharacter = user.GetComponent<Character>();
                foreach (var item in Player1TargetList)
                {
                    for (int i = 0; i < userCharacter.TypesOfEnemeyToAttack.Length; i++)
                    {
                        LivingEntityTypes templiv = item.GetComponent<LivingEntity>().GetObjectType();               
                        if (templiv == userCharacter.TypesOfEnemeyToAttack[i])
                        {
                            tempList.Add(item);
                        }
                   
                        
                    }
                }

                return tempList;
            
            case -1:
                Character userCharacter2 = user.GetComponent<Character>();

                foreach (var item in Player2TargetList)
                {
                    for (int i = 0; i < userCharacter2.TypesOfEnemeyToAttack.Length; i++)
                    {
                        LivingEntityTypes templiv = item.GetComponent<LivingEntity>().GetObjectType();
                        if (templiv == userCharacter2.TypesOfEnemeyToAttack[i])
                        {
                            tempList.Add(item);
                        }
                    }
                }

                return tempList;
            default:

                return tempList;
        }

    }

    public void AddTarget(Character user)
    {
        switch (user.GetPlayerId())
        {
            case 1:

                break;
            case 2:
                break;
            default:
                break;
        }
    }



    public void RemoveTarget(LivingEntity user)
    {
        if (user.GetPlayerId() == -1)
        {
            Player1TargetList.Remove(user.gameObject.transform);
            
        }
        else
        {
            Player2TargetList.Remove(user.gameObject.transform);

        }
    }




    private void Start() {

        ObjectPooler.instance.InitializePool("Ingame_Poseidon");
        ObjectPooler.instance.InitializePool("Ingame_Enemy");
        ObjectPooler.instance.InitializePool("Ingame_HealthBar");
        StartTargetMatch();
    }


}
