using UnityEngine;

[CreateAssetMenu(fileName = "New Department", menuName = "ScriptableObject/Department")]
public class Department : ScriptableObject
{
    public string title;
    public string description;
}
