[System.Serializable]
public class GameData
{
    public int playerScore;
    public float playerHealth;
    public SerializableVector3 playerPosition;

    public GameData(int playerScore, float playerHealth, SerializableVector3 playerPosition)
    {
        this.playerScore = playerScore;
        this.playerHealth = playerHealth;
        this.playerPosition = playerPosition;
    }
}
