using UnityEngine;

[System.Serializable]
public class Player
{
    public string playerName;
    // Add any other player-related data here
}

[CreateAssetMenu(fileName = "PlayerData", menuName = "Create PlayerData")]
[System.Serializable]
public class PlayerData : ScriptableObject
{
    public Player[] players;
    // Add any other game-wide data here

    public void InitializePlayerData()
    {
        players = new Player[5]; // Assuming you have 5 player slots
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = new Player();
        }
    }

    // Factory method for creating a new instance of PlayerData
    public static PlayerData CreateInstance()
    {
        PlayerData data = ScriptableObject.CreateInstance<PlayerData>();
        data.InitializePlayerData();
        return data;
    }
}
