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
    private Arena_SO _arena;
    [SerializeField]
    private CardType _cardType;
    [SerializeField]
    private CardRarity _cardRarity;
    [SerializeField]
    private CardLevel_SO _cardLevel;
    [SerializeField]
    private CardIntProperty _elixirCost;

    public int Id { get => _id; set => _id = value; }
    public CardStringProperty Name { get => _name; set => _name = value; }
    public CardStringProperty Description { get => _description; set => _description = value; }
    public Arena_SO Arena { get => _arena; set => _arena = value; }
    public CardType CardType { get => _cardType; set => _cardType = value; }
    public CardRarity CardRarity { get => _cardRarity; set => _cardRarity = value; }
    public CardLevel_SO CardLevel { get => _cardLevel; set => _cardLevel = value; }
    public CardIntProperty ElixirCost { get => _elixirCost; set => _elixirCost = value; }
}
