using System;
using UnityEngine;

public class CardBase : MonoBehaviour {

    public Action OnIdChanged;
    public Action OnNameChanged;
    public Action OnDescriptionChanged;
    public Action OnArenaChanged;
    public Action OnCardTypeChanged;
    public Action OnCardRarityChanged;
    public Action OnCardLevelChanged;
    public Action OnElixirCostChanged;

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

        OnIdChanged?.Invoke();
    }

    public void SetName(CardStringProperty name) {
        _cardBase.Name = name;

        OnNameChanged?.Invoke();
    }

    public void SetDescription(CardStringProperty description) {
        _cardBase.Description = description;

        OnDescriptionChanged?.Invoke();
    }

    public void SetArena(Arena_SO arena) {
        _cardBase.Arena = arena;

        OnArenaChanged?.Invoke();
    }

    public void SetCardType(CardType type) {
        _cardBase.CardType = type;

        OnCardTypeChanged?.Invoke();
    }

    public void SetCardRarity(CardRarity rarity) {
        _cardBase.CardRarity = rarity;

        OnCardRarityChanged?.Invoke();
    }

    public void SetCardLevel(CardLevel_SO cardLevel) {
        _cardBase.CardLevel = cardLevel;

        OnCardLevelChanged?.Invoke();
    }

    public void SetElixirCost(CardIntProperty cost) {
        _cardBase.ElixirCost = cost;
        
        OnElixirCostChanged?.Invoke();
    }

    #endregion

    #region Reporters

    public int GetId() {
        return _cardBase.Id;
    }

    public string GetName() {
        return _cardBase.Name.Value;
    }

    public string GetDescription() {
        return _cardBase.Description.Value;
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

    public int GetElixirCost() {
        return _cardBase.ElixirCost.Value;
    }

    #endregion

    #region Custom Methods

    #endregion

}