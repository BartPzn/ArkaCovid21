[System.Serializable]
public class GameData
{
    public int lives;
    public int points;
    public float time;
    public string name;

    public GameData(int scoreInt, int nameStr, float timePlayedF, string userName)
    {
        lives = scoreInt;
        points = nameStr;
        time = timePlayedF;
        name = userName;
    }
}