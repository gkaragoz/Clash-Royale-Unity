using UnityEngine;

[System.Serializable]
public class CardArena {

    [Header("Initializations")]
    [SerializeField]
    private Arena_SO _arena = null;

    #region Reporters

    public int GetAreanaId() {
        return _arena.Id;
    }

    public string GetArenaName() {
        return _arena.Name;
    }

    public string GetArenaDescription() {
        return _arena.Description;
    }

    public bool GetIsRevealed() {
        return _arena.IsRevealed;
    }


    public int GetTrophy() {
        return _arena.Trophy;
    }

    #endregion


}
