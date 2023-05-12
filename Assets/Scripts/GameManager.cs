using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnRate = 0.5f;
    public GameObject Circle;

    void Start()
    {
        //MULTIPLE NEALS
        spawnRate = MainManager.instance.spawnRate;
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget(){
        while(true){
            yield return new WaitForSeconds(spawnRate);
            Instantiate(Circle);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
