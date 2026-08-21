[System.Serializable]
public class ExchangeItemData
{
    public int id;
    public int quantity;

    public ExchangeItemData(int id, int quantity)
    {
        this.id = id;
        this.quantity = quantity;
    }
}
