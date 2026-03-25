using UnityEngine;

public class AttackIndicatorApper : MonoBehaviour {
    public GameObject AttacAttackIndicatorUp;
    public GameObject AttacAttackIndicatorMiddle;
    public GameObject AttacAttackIndicatorDown;
    public SaberControl SaberControl;
    public EnemyStamina EnemyStamina;
    void Start() {
        AttackIndicatorPositon(-1);
        InvokeRepeating("RandomAttack", 1f, 4f);
        InvokeRepeating("Attack", 2.5f, 4f);
    }


    void Update() {

    }

    public void AttackIndicatorPositon(int posAttack) {
        AttacAttackIndicatorUp.SetActive(posAttack == 1);
        AttacAttackIndicatorMiddle.SetActive(posAttack == 2);
        AttacAttackIndicatorDown.SetActive(posAttack == 3);
    }

    void RandomAttack() {
        int pos = Random.Range(1, 4);
        AttackIndicatorPositon(pos);
    }

    void Attack() {
        int posAttack = 0;
        if (AttacAttackIndicatorUp.activeSelf) posAttack = 1;
        if (AttacAttackIndicatorMiddle.activeSelf) posAttack = 2;
        if (AttacAttackIndicatorDown.activeSelf) posAttack = 3;

        int pos = 0;
        if (SaberControl.SaberUp.activeSelf) pos = 1;
        if (SaberControl.SaberMiddle.activeSelf) pos = 2;
        if (SaberControl.SaberDown.activeSelf) pos = 3;



        if (pos == posAttack) {
            EnemyStamina.licznikStaminaEnemy--;
        } else {
            EnemyStamina.licznikStaminaEnemy++;
        }
    }
}