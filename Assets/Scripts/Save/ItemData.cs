
[System.Serializable]
public class ItemData
{
    public int id;
    public SerializableVector3 position;
    public SerializableVector3 rotation;
    public ItemData(int id, SerializableVector3 position, SerializableVector3 rotation)
    {
        this.id = id;
        this.position = position;
        this.rotation = rotation;
    }
}
