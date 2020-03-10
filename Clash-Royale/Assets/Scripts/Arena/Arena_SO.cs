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

}