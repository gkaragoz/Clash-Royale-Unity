using UnityEngine;

[System.Serializable]
public class CardUpgradeable {

    [Header("Initializations")]
    [SerializeField]
    private CardUpgradeable_SO _cardLevel = null;

    #region Setters

    public void SetBaseLevel(int baseLevel) {
        _cardLevel.BaseLevel = baseLevel;
    }

    public void SetMaxLevel(int maxLevel) {
        _cardLevel.MaxLevel = maxLevel;
    }

    public void SetLevelUp(LevelUp[] levels) {
        _cardLevel.Levels = levels;
    }

    #endregion

    #region Reporters

    public int GetBaseLevel() {
        return _cardLevel.BaseLevel;
    }

    public int GetMaxLevel() {
        return _cardLevel.MaxLevel;
    }

    public LevelUp[] GetLevelUp() {
        return _cardLevel.Levels;
    }

    #endregion

    #region Custom Methods

    #endregion

}