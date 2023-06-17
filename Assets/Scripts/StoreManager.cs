using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI moneyText;
    public GameObject shotgunButton;

    [SerializeField]
    private FloatSO scoreSO;
    [SerializeField]
    private FloatSO moneySO;
    [SerializeField]
    private IntegerSO weaponSO;

    void Start(){
        UpdateMoney(0);
        CheckMoney();
        Cursor.visible = true;
    }

    private void CheckMoney(){
        if(moneySO.Value < 50){
            shotgunButton.SetActive(false);
        }
        else{
            shotgunButton.SetActive(true);
        }
    }
    
    public void UpdateMoney(int scoreToAdd){
        moneySO.Value += scoreToAdd;
        moneyText.text = "MONEY: $"+moneySO.Value;
    }

    public void PistolButton(){
        weaponSO.Value = 0;
        UpdateMoney(-20);
        SceneManager.LoadScene("Main");
    }

    public void ShotgunButton(){
        weaponSO.Value = 1;
        UpdateMoney(-50);
        SceneManager.LoadScene("Main");
    }
}
