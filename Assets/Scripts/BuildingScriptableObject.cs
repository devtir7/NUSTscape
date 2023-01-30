using UnityEngine;

[CreateAssetMenu(fileName = "BuildingScriptableObject", menuName = "ScriptableObject/Department")]
public class BuildingScriptableObject : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] string description;

    public void setTitle(string name)
    {
        title = name;
    }

    public void setDescription(string desc)
    {
        description = desc;
    }

    public string getTitle()
    {
        return title;
    }

    public string getDescription()
    {
        return description;
    }
}