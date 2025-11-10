using UnityEngine;

public class DataUser
{
    public string playerName;
    public Vector3 playerPosition;
    public int playerMaxHealth;
    public int playerMaxMana;
    public int playerEXP;
}

public static class Stats
{
    public static DataUser dataUser = new DataUser();
}
