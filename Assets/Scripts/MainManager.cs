using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public float spawnRate;
    public GameObject MainMenu;
    public GameObject DifficultySelector;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        getExistingScores();
        DontDestroyOnLoad(gameObject);
    }

    public void setSpawnRate(float f)
    {
        spawnRate = f;
        SceneManager.LoadScene("Main");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void startBtn()
    {
        MainMenu.SetActive(false);
        DifficultySelector.SetActive(true);
    }

    public void backBtn()
    {
        DifficultySelector.SetActive(false);
        MainMenu.SetActive(true);
    }


    [System.Serializable]
    class SaveData
    {
        public List<PlayerScore> PlayerScoreList;

        public SaveData()
        {
            this.PlayerScoreList = new List<PlayerScore>();
        }
        public void addEntry(PlayerScore playerScore)
        {
            this.PlayerScoreList.Add(playerScore);
        }

        public void sort()
        {
            for (int i = 0; i < this.PlayerScoreList.Count; i++)
            {
                for (int j = i + 1; j < this.PlayerScoreList.Count; j++)
                {
                    if (this.PlayerScoreList[j].score > this.PlayerScoreList[i].score)
                    {
                        PlayerScore temp = this.PlayerScoreList[i];
                        this.PlayerScoreList[i] = this.PlayerScoreList[j];
                        this.PlayerScoreList[j] = temp;
                    }
                }
            }
        }
    }

    class PlayerScore
    {
        public int score;
        public string name;

        public PlayerScore(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
    }

    SaveData getExistingScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        SaveData s;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            s = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.Log(path);
            s = new SaveData();
        }
        return s;
    }

    public void addNewScore(int score, string name)
    {
        SaveData s = getExistingScores();
        PlayerScore newScore = new PlayerScore(score, name);
        s.addEntry(newScore);
        s.sort();

        string json = JsonUtility.ToJson(s);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
