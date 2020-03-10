using UnityEngine;

[CreateAssetMenu(fileName = "Arena", menuName = "Scriptable Objects/Arena/Arena")]
public class Arena_SO : ScriptableObject {

    [SerializeField]
    private int _id;
    [SerializeField]
    private string _name;
    [SerializeField]
    private string _description;
    [SerializeField]
    private bool _isRevealed;
    [SerializeField]
    private int _trophy;

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }
    public bool IsRevealed { get => _isRevealed; set => _isRevealed = value; }
    public int Trophy { get => _trophy; set => _trophy = value; }
}