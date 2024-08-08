[System.Serializable]
public class CabinetData
{
    public bool isOpen;
    public ItemData[] itemDatas;

    public CabinetData(bool isOpen, ItemData[] itemDatas)
    {
        this.isOpen = isOpen;
        this.itemDatas = itemDatas;
    }
}
