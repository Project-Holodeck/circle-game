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
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI bulletsText;
    public bool gameOver = false;
    public SpriteRenderer spriteRenderer;
    public Sprite[] pistolSprites;
    public Sprite[] shotgunSprites;
    public Sprite[] bananaSprites;
    public static GameManager instance;
    public GameObject storeButton;
    public AudioSource hitSoundEffect;

    [SerializeField]
    private FloatSO scoreSO;
    [SerializeField]
    private FloatSO moneySO;
    [SerializeField]
    private IntegerSO weaponSO;
    [SerializeField]
    public IntegerSO bulletsSO;

    void Start()
    {
        //MULTIPLE NEALS
        spawnRate = MainManager.instance.spawnRate;
        StartCoroutine(SpawnTarget());

        //Initiating
        UpdateScore(0);
        UpdateMoney(0);
        UpdateBullets(5);
        if(moneySO.Value < 20){
            storeButton.SetActive(false);
        }
    }

    public void playHitSoundEffect(){
        hitSoundEffect.Play();
    }

    public void UpdateBullets(int value){
        bulletsSO.Value += value;
        bulletsText.text = bulletsSO.Value+"/5";
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
        scoreSO.Value += scoreToAdd;
        scoreText.text = "Score: "+scoreSO.Value;
    }

    public void UpdateMoney(int scoreToAdd){
        moneySO.Value += scoreToAdd;
        moneyText.text = "Money: $"+moneySO.Value;
        if(moneySO.Value >= 20){
            storeButton.SetActive(true);
        }
    }

    public void GameOver(){
        gameOver = true;
        scoreText.text = "GAME OVER!\nScore: "+scoreSO.Value;
    }

    private void ChangeGunSprite(int index){
        if(weaponSO.Value == 0){
            spriteRenderer.sprite = pistolSprites[index];
        }
        else if(weaponSO.Value == 1){
            spriteRenderer.sprite = shotgunSprites[index];
        }
        else if(weaponSO.Value == 2){
            spriteRenderer.sprite = bananaSprites[index];
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
        if(Input.GetMouseButtonDown(0) && bulletsSO.Value != 0){
            UpdateBullets(-1);
        }
        if(Input.GetKeyDown("r") && bulletsSO.Value != 5){
            UpdateBullets(5-bulletsSO.Value);
        }
    }
}
