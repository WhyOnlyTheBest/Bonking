using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveyThing : MonoBehaviour
{
    
    public Text BestScoreText;
    public string Name;
    public Text Namey;

    public GameObject NameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        LoadColor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
    }

    public void SaveColor()
    {
        Name = Namey.text;
        SaveData data = new SaveData();

        data.Name = Name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Name);

    }

    public void LoadColor()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Does Work");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            BestScoreText.text = "Best Score " + data.Name;
        }
    }
}
