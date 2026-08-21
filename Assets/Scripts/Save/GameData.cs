[System.Serializable]
public class GameData
{
    public CabinetData[] cabinetDatas;
    public EngineTableData engineTableData;
    public SerializableTransform playerTransform;
    public SerializableTransform monsterTransform;

    public ExchangeDeskData exchangeDeskData01;
    public ExchangeDeskData exchangeDeskData02;
    public ExchangeDeskData exchangeDeskData03;


    public GameData(
        CabinetData[] cabinetDatas, 
        EngineTableData engineTableData, 
        SerializableTransform playerTransform, 
        SerializableTransform monsterTransform,
        ExchangeDeskData exchangeDeskData01,
        ExchangeDeskData exchangeDeskData02,
        ExchangeDeskData exchangeDeskData03
        )
    {
        this.cabinetDatas = cabinetDatas;
        this.engineTableData = engineTableData;
        this.playerTransform = playerTransform;
        this.monsterTransform = monsterTransform;
        this.exchangeDeskData01 = exchangeDeskData01;
        this.exchangeDeskData02 = exchangeDeskData02;
        this.exchangeDeskData03 = exchangeDeskData03;
    }
}
