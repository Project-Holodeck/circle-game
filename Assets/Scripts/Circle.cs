using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update

    private float xRange = 6.5f;
    private float yRange = 6.5f;
    private GameManager gameManager;

    void Start()
    {
        moveCircle();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));
    }

    void moveCircle(){
        transform.position = RandomSpawnPos();
    }

    private void OnTriggerEnter(Collider other){
        StartCoroutine(Delete());
    }

    IEnumerator Delete(){
        yield return new WaitForSeconds(gameManager.spawnRate);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
