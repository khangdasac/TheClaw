[System.Serializable]
public class ExchangeDeskData
{
    public bool isExchanged;
    public ExchangeItemData[] exchangeItems;

    public ExchangeDeskData(bool isExchanged, ExchangeItemData[] exchangeItems)
    {
        this.isExchanged = isExchanged;
        this.exchangeItems = exchangeItems;
    }
}
