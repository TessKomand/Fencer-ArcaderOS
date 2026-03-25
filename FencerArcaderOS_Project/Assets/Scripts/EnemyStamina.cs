using UnityEngine;
using TMPro;

public class EnemyStamina : MonoBehaviour{
    public int licznikStaminaEnemy;

    public TMP_Text Stamina;
    void Start() {
        licznikStaminaEnemy = 5;
        Stamina.text = "Stamina: " + licznikStaminaEnemy.ToString();
    }


    void Update(){
        Stamina.text = "Stamina: " + licznikStaminaEnemy.ToString();
    }
}
