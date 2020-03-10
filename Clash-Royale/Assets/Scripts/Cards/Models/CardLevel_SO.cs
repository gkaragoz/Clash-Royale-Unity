using UnityEngine;

[CreateAssetMenu(fileName = "Card Level", menuName = "Scriptable Objects/Cards/Card Level")]
public class CardLevel_SO : ScriptableObject {

    [Header("Debug")]
    [SerializeField]
    private int _baseLevel;
    [SerializeField]
    private int _maxLevel;
    [SerializeField]
    private int _currentLevel;
    [SerializeField]
    private LevelUp[] _levels;

    public int BaseLevel { get => _baseLevel; set => _baseLevel = value; }
    public int MaxLevel { get => _maxLevel; set => _maxLevel = value; }
    public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
    public LevelUp[] Levels { get => _levels; set => _levels = value; }
}

[System.Serializable]
public class LevelUp {
    [SerializeField]
    private int _number;
    [SerializeField]
    private int _upgradeCost;
    [SerializeField]
    private int _requiredCards;

    public int Number { get => _number; set => _number = value; }
    public int UpgradeCost { get => _upgradeCost; set => _upgradeCost = value; }
    public int RequiredCards { get => _requiredCards; set => _requiredCards = value; }
}
