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

}

[System.Serializable]
public class LevelUp {
    [SerializeField]
    private int _number;
    [SerializeField]
    private int _upgradeCost;
    [SerializeField]
    private int _requiredCards;
}
