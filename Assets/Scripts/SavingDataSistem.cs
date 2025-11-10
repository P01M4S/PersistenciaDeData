using UnityEngine;
using System.IO;

public static class SavingDataSistem
{
    static string savePath = Application.persistentDataPath + "/SaveFile.json";
    public static void Save()
    {
        string json = JsonUtility.ToJson(Stats.dataUser, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Guardado en: " + savePath);
    }
    public static void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            Stats.dataUser = JsonUtility.FromJson<DataUser>(json);
            Debug.Log("Datos Guardados");
        }
        else
        {
            Debug.Log("Datos  NO Guardados");
        }
    }
}
