using UnityEngine;

public class LivingEntity :MonoBehaviour{
    private int Id { get; set; }
    private LivingEntityTypes ObjectType { get; set; }
    private float PlayerId { get; set; }


    #region Increasers
     
    #endregion

    #region Decreasers

    #endregion

    #region Setters

    public void SetId(int value)
    {
        Id = value;
    }
    public void SetObjectType(LivingEntityTypes value)
    {
        ObjectType = value;
    }
    public void SetPlayerId(float value)
    {
        PlayerId = value;
    }

    #endregion

    #region Reporters

    public int GetId()
    {
        return Id;
    }

    public LivingEntityTypes GetObjectType()
    {
        return ObjectType;
    }
    public float GetPlayerId()
    {
        return PlayerId;
    }
    #endregion

    #region Custom Methods
    #endregion


}
