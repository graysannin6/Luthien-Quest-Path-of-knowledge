using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;


public enum ItemType
{
    Equipment,
    Material,

}

[CreateAssetMenu(fileName = "new ItemData", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite icon;

    public string itemId;

    protected StringBuilder sb = new StringBuilder();

    private void OnValidate()
    {
#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        itemId = AssetDatabase.AssetPathToGUID(path);
#endif
    }

    public virtual string GetDescription()
    {
        return "";
    }
}
