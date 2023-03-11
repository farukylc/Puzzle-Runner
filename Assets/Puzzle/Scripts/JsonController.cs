using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonController : MonoBehaviour
{
    public UserStats user1 = new UserStats();
    
    // void Start()
    // {
    //     if(!File.Exists(Application.dataPath + "/Saves/UserData.json"))
    //     {
    //         JsonSave();
    //     }
    //     else if(File.Exists(Application.dataPath + "/Saves/UserData.json"))
    //     {
    //         JsonLoad();
    //     }
    // }
    // public void JsonSave()
    // {
    //     string jsonString = JsonUtility.ToJson(user1);
    //     File.WriteAllText(Application.dataPath + "/Saves/UserData.json", jsonString);
    // }
    // public void JsonLoad()
    // {
    //     string dataPath = Application.dataPath + "/Saves/UserData.json";
    //     if(File.Exists(dataPath))
    //     {
    //         string jsonString = File.ReadAllText(dataPath);
    //         user1 = JsonUtility.FromJson<UserStats>(jsonString); 
    //     }
    //     else
    //     {
    //         Debug.Log("Kayit bulunamadi");
    //     }
    // }
    public void JsonSave()
    {
        var json = JsonUtility.ToJson(user1);
        File.WriteAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "GameData.txt", json);
    }

    public void JsonLoad()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "GameData.txt"))
        {
            var json = File.ReadAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "GameData.txt");

            JsonUtility.FromJsonOverwrite(json, user1);
        }
        else
        {
            var json = JsonUtility.ToJson(user1);
            File.WriteAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "GameData.txt", json);
        }
    }
}
