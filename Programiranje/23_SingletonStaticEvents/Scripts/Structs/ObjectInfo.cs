using UnityEngine;

[System.Serializable]
public struct ObjectInfo
{
    public string ObjectName;
    public Vector3 ObjectPosition;
    public Color ObjectColor;
    public Enemy Enemy;

    public ObjectInfo(string objectName, Vector3 objectPosition, Color objectColor, Enemy enemy)
    {
        ObjectName = objectName;
        ObjectPosition = objectPosition;
        ObjectColor = objectColor;
        Enemy = enemy;
    }
}
