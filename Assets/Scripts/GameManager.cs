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
    public List<GameObject> circles;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public bool gameOver = false;

    void Start()
    {
        //MULTIPLE NEALS
        spawnRate = MainManager.instance.spawnRate;
        StartCoroutine(SpawnTarget());

        //Initiating score
        UpdateScore(0);
    }

    IEnumerator SpawnTarget(){
        while(true && !gameOver){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,circles.Count);
            Instantiate(circles[index]);
        }
    }

    public void UpdateScore(int scoreToAdd){
        this.score += scoreToAdd;
        scoreText.text = "Score: "+score;
    }

    public void GameOver(){
        gameOver = true;
        scoreText.text = "GAME OVER!\nScore: "+score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
