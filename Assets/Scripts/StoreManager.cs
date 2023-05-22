using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static StoreManager instance;
    public double spawnRate;
    public MainManager mainManager;
    public bool usingPistol;

    void Start(){
        mainManager = GameObject.Find("SceneManager").GetComponent<MainManager>();
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void pistolButton(){
        usingPistol = true;
        spawnRate = mainManager.spawnRate;
        SceneManager.LoadScene("Main");
    }

    public void shotgunButton(){
        usingPistol = false;
        spawnRate = mainManager.spawnRate;
        SceneManager.LoadScene("Main");
    }
}
