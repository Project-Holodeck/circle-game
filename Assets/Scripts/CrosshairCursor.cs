using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager gameManager;
    Vector3 mouseCursorPos;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver) {
            Cursor.visible = true;
            gameObject.SetActive(false);
        }
        mouseCursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        transform.position = mouseCursorPos;
    }
}
