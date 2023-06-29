using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update

    private float xRange = 6.0f;
    private float yRange = 5.6f;
    private GameManager gameManager;
    private bool destroyed = false;

    void Start()
    {
        moveCircle();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange, xRange), Random.Range(0, yRange));
    }

    void moveCircle(){
        transform.position = RandomSpawnPos();
    }

    private void OnTriggerEnter(Collider other){
        if(!destroyed){
            StartCoroutine(Delete());
        }  
    }

    IEnumerator Delete(){
        yield return new WaitForSeconds(gameManager.spawnRate);
        Destroy(gameObject);
    }

    private void OnMouseDown(){
        if(!gameManager.gameOver && gameManager.bulletsSO.Value != 0){
            Destroy(gameObject);
            destroyed = true;
            if(gameObject.tag == "Enemy"){
                gameManager.playHitSoundEffect();
                gameManager.GameOver();
            }
            else{
                gameManager.playHitSoundEffect();
                gameManager.UpdateScore(10);
                gameManager.UpdateMoney(10);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
 
    }
}