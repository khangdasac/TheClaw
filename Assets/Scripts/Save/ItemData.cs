using UnityEngine;
[System.Serializable]
public class ItemData
{
    public int id;
    public SerializableTransform transform;
    public ItemData(int id, SerializableTransform transform)
    {
        this.id = id;
        this.transform = transform;
    }

    public ItemData(int id, Transform transform)
    {
        this.id = id;
        this.transform = new SerializableTransform(transform);
    }
}
