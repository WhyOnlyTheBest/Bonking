using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    public string notACleverName;
    public int score;
    public GameObject MainManager;
    private int m_Score;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Awake()
    {
        LoadColor();
    }

    // Update is called once per frame
    void Update()
    {
        MainManager = GameObject.Find("MainManager");

        m_Score = MainManager.GetComponent<MainManager>().m_Points;
    }

    [System.Serializable]
    class SaveData
    {
        public int m_Score;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.m_Score = m_Score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            m_Score = data.m_Score;
        }
    }


}
