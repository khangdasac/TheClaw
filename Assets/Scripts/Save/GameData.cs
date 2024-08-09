[System.Serializable]
public class GameData
{
    public CabinetData[] cabinetDatas;
    public EngineTableData engineTableData;
    public SerializableTransform playerTransform;
    public SerializableTransform monsterTransform;

    public GameData(CabinetData[] cabinetDatas, EngineTableData engineTableData, SerializableTransform playerTransform, SerializableTransform monsterTransform)
    {
        this.cabinetDatas = cabinetDatas;
        this.engineTableData = engineTableData;
        this.playerTransform = playerTransform;
        this.monsterTransform = monsterTransform;
    }
}
