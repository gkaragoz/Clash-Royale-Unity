using UnityEngine;

public class CardLevel : MonoBehaviour {

    [Header("Initialization")]
    [SerializeField]
    private CardLevel_SO _cardLevelDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private CardLevel_SO _cardLevel = null;

    #region Initializations

    private void Awake() {
        if (_cardLevelDefinition_Template != null) {
            _cardLevel = Instantiate(_cardLevelDefinition_Template);
        }
    }

    #endregion

    #region Setters
    
    public void SetBaseLevel(int baseLevel) {
        _cardLevel.BaseLevel = baseLevel;
    }

    public void SetMaxLevel(int maxLevel) {
        _cardLevel.MaxLevel = maxLevel;
    }

    public void SetCurrentLevel(int currentLevel) {
        _cardLevel.CurrentLevel = currentLevel;
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

    public int GetCurrentLevel() {
        return _cardLevel.CurrentLevel;
    }

    public LevelUp[] GetLevelUp() {
        return _cardLevel.Levels;
    }

    #endregion

    #region Custom Methods

    #endregion

}