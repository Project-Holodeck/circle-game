using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public float spawnRate;
    public GameObject MainMenu;
    public GameObject DifficultySelector;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
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
}
