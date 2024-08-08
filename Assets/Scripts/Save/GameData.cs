[System.Serializable]
public class GameData
{
    public CabinetData[] CabinetDatas;

    public GameData(CabinetData[] cabinetDatas)
    {
        CabinetDatas = cabinetDatas;
    }
}
