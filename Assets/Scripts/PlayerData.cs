using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //public static PlayerData Instance;
    public string playerName;
    public Vector3 playerPosition;
    public int playerMaxHealth;
    public int playerMaxMana;
    public int playerEXP;

    /*void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }*/

    public void SaveData()
    {
        /*UserData.playerName = playerName;
        UserData.playerMaxHealth = playerMaxHealth;
        UserData.playerMaxMana = playerMaxMana;
        UserData.playerEXP = playerEXP;
        UserData.playerPosition = playerPosition;

        Debug.Log("Data Saved");*/
        Stats.dataUser.playerName = playerName;
        Stats.dataUser.playerMaxHealth = playerMaxHealth;
        Stats.dataUser.playerPosition = playerPosition;

        SavingDataSistem.Save();
    }
    public void LoadData()
    {
        /*playerName = UserData.playerName;
        playerMaxHealth = UserData.playerMaxHealth;
        playerMaxMana = UserData.playerMaxMana;
        playerEXP = UserData.playerEXP;
        playerPosition = UserData.playerPosition;

        Debug.Log("Data Loaded");*/
        playerName = Stats.dataUser.playerName;
        playerMaxHealth = Stats.dataUser.playerMaxHealth;
        playerPosition = Stats.dataUser.playerPosition;

        SavingDataSistem.Load();
    }

    public void SavePref()
    {
        PlayerPrefs.SetString("Player Name", playerName);
        PlayerPrefs.SetInt("Player Health", playerMaxHealth);
        PlayerPrefs.SetInt("Player Mana", playerMaxMana);
        PlayerPrefs.SetInt("Player EXP", playerEXP);
        PlayerPrefs.SetFloat("Player Position X", playerPosition.x);
        PlayerPrefs.SetFloat("Player Position Y", playerPosition.y);
        PlayerPrefs.SetFloat("Player Position Z", playerPosition.z);
    }
    public void LoadPref()
    {
        playerName = PlayerPrefs.GetString("Player Name", "No Name");
        playerMaxHealth = PlayerPrefs.GetInt("Player Health", 1);
        playerMaxMana = PlayerPrefs.GetInt("Player Mana", 1);
        playerEXP = PlayerPrefs.GetInt("Player EXP", 1);
        playerPosition.x = PlayerPrefs.GetFloat("Player Position X");
        playerPosition.y = PlayerPrefs.GetFloat("Player Position Y");
        playerPosition.z = PlayerPrefs.GetFloat("Player Position Z");
    }

}
