using UnityEngine;

[System.Serializable]
public class CardStringProperty {

    [SerializeField]
    private CardProperty_SO _propertySO;
    [SerializeField]
    private string _value;

    public string Value { get => _value; set => _value = value; }
    public CardProperty_SO PropertySO { get => _propertySO; set => _propertySO = value; }
}
