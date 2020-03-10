using UnityEngine;

[CreateAssetMenu(fileName = "Card Stats", menuName = "Scriptable Objects/Cards/Card Stats")]
public class CardBase_SO : ScriptableObject {

    [SerializeField]
    private int _id;
    [SerializeField]
    private CardStringProperty _name;
    [SerializeField]
    private CardStringProperty _description;
    [SerializeField]
    private CardArena _arena;
    [SerializeField]
    private CardType _cardType;
    [SerializeField]
    private CardRarity _cardRarity;
    [SerializeField]
    private CardUpgradeable_SO _cardUpgradeable;
    [SerializeField]
    private CardIntProperty _elixirCost;
    [SerializeField]
    private CardIntProperty _currentLevel;

    public int Id { get => _id; set => _id = value; }
    public CardStringProperty Name { get => _name; set => _name = value; }
    public CardStringProperty Description { get => _description; set => _description = value; }
    public CardArena Arena { get => _arena; set => _arena = value; }
    public CardType CardType { get => _cardType; set => _cardType = value; }
    public CardRarity CardRarity { get => _cardRarity; set => _cardRarity = value; }
    public CardUpgradeable_SO CardUpgradeable { get => _cardUpgradeable; set => _cardUpgradeable = value; }
    public CardIntProperty ElixirCost { get => _elixirCost; set => _elixirCost = value; }
    public CardIntProperty CardLevel { get => _currentLevel; set => _currentLevel = value; }
}
