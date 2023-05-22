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
    public SpriteRenderer spriteRenderer;
    public Sprite[] pistolSprites;
    public Sprite[] shotgunSprites;
    public bool usingPistol;

    void Start()
    {
        //MULTIPLE NEALS
        spawnRate = MainManager.instance.spawnRate;
        if(StoreManager.instance != null){
            usingPistol = StoreManager.instance.usingPistol;
        }
        StartCoroutine(SpawnTarget());

        //Initiating score
        UpdateScore(0);
    }

    IEnumerator SpawnTarget(){
        while(true && !gameOver){
            yield return new WaitForSeconds(spawnRate);
            int index = getRandIndex();
            Instantiate(circles[index]);
        }
    }

    private int getRandIndex(){
        int index = 0;
        double rand = Random.Range(0.0f, 1.0f);
        if(rand < 0.2){
            index = 1;
        }
        return index;
    }

    public void UpdateScore(int scoreToAdd){
        this.score += scoreToAdd;
        scoreText.text = "Score: "+score;
    }

    public void GameOver(){
        gameOver = true;
        scoreText.text = "GAME OVER!\nScore: "+score;
    }

    private void ChangeGunSprite(int index){
        if(usingPistol){
            spriteRenderer.sprite = pistolSprites[index];
        }
        else{
            spriteRenderer.sprite = shotgunSprites[index];
        }
    }

    private void UpdateGun(){
        Vector3 position = Input.mousePosition;
        if(position.x < Screen.width*0.35){
            ChangeGunSprite(0);
        }
        else if(position.x < Screen.width*0.5){
            ChangeGunSprite(1);
        }
        else if(position.x < Screen.width*0.65){
            ChangeGunSprite(2);
        }
        else{
            ChangeGunSprite(3);
        }
    }

    public void openStore(){
        SceneManager.LoadScene("Store");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGun();
    }
}
