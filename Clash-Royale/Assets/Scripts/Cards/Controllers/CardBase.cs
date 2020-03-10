using UnityEngine;

public class CardBase : MonoBehaviour {

    [Header("Initialization")]
    [SerializeField]
    private CardBase_SO _cardBaseDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private CardBase_SO _cardBase = null;

    #region Initializations

    private void Awake() {
        if (_cardBaseDefinition_Template != null) {
            _cardBase = Instantiate(_cardBaseDefinition_Template);
        }
    }

    #endregion

    #region Setters
    public void SetId(int id) {
        _cardBase.Id = id;
    }

    public void SetName(CardStringProperty name) {
        _cardBase.Name = name;
    }

    public void SetDescription(CardStringProperty description) {
        _cardBase.Description = description;
    }

    public void SetArena(Arena_SO arena) {
        _cardBase.Arena = arena;
    }

    public void SetCardType(CardType type) {
        _cardBase.CardType = type;
    }

    public void SetCardRarity(CardRarity rarity) {
        _cardBase.CardRarity = rarity;
    }

    public void SetCardLevel(CardLevel_SO cardLevel) {
        _cardBase.CardLevel = cardLevel;
    }

    public void SetElixirCost(CardIntProperty cost) {
        _cardBase.ElixirCost = cost;
    }

    #endregion

    #region Reporters

    public int GetId() {
        return _cardBase.Id;
    }

    public CardStringProperty GetName() {
        return _cardBase.Name;
    }

    public CardStringProperty GetDescription() {
        return _cardBase.Description;
    }

    public Arena_SO GetArena() {
        return _cardBase.Arena;
    }

    public CardType GetCardType() {
        return _cardBase.CardType;
    }

    public CardRarity GetCardRarity() {
        return _cardBase.CardRarity;
    }

    public CardLevel_SO GetCardLevel() {
        return _cardBase.CardLevel;
    }

    public CardIntProperty GetElixirCost() {
        return _cardBase.ElixirCost;
    }

    #endregion

    #region Custom Methods

    #endregion

}