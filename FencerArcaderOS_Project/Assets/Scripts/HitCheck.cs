using UnityEngine;

public class HitManager : MonoBehaviour {
    public EnemyStamina EnemyStamina;
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }



    public void Attack(int posAttack, int pos) {


        Debug.Log("Attack position: " + posAttack + ", Saber position: " + pos);

        if (pos == posAttack) {
            EnemyStamina.licznikStaminaEnemy--;
        } 
    }
}
