using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI moneyText;
    public GameObject shotgunButton, bananaButton;

    [SerializeField]
    private FloatSO scoreSO;
    [SerializeField]
    private FloatSO moneySO;
    [SerializeField]
    private IntegerSO weaponSO;
    [SerializeField]
    private IntegerSO bulletsSO;

    void Start(){
        UpdateMoney(0);
        CheckMoney();
        Cursor.visible = true;
    }

    public void CheckMoney(){
        if(moneySO.Value < 50){
            shotgunButton.SetActive(false);
        }
        else{
            shotgunButton.SetActive(true);
        }
        if(moneySO.Value < 200){
            bananaButton.SetActive(false);
        }
        else{
            bananaButton.SetActive(true);
        }
    }

    public void ResetBullets(){
        bulletsSO.Value = 0;
    }
    
    public void UpdateMoney(int scoreToAdd){
        moneySO.Value += scoreToAdd;
        moneyText.text = "MONEY: $"+moneySO.Value;
    }

    public void PistolButton(){
        weaponSO.Value = 0;
        UpdateMoney(-20);
        ResetBullets();
        SceneManager.LoadScene("Main");
    }

    public void ShotgunButton(){
        weaponSO.Value = 1;
        UpdateMoney(-50);
        ResetBullets();
        SceneManager.LoadScene("Main");
    }

    public void BananaButton(){
        weaponSO.Value = 2;
        UpdateMoney(-200);
        ResetBullets();
        SceneManager.LoadScene("Main");
    }
}
