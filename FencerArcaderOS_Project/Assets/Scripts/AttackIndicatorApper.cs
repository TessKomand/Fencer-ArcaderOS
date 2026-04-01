using UnityEngine;
using System.Collections;

public class AttackIndicatorApper : MonoBehaviour {
    public GameObject AttacAttackIndicatorUp;
    public GameObject AttacAttackIndicatorMiddle;
    public GameObject AttacAttackIndicatorDown;
    public GameObject AttackIndicatorWide;
    public SaberControl SaberControl;
    public EnemyStamina EnemyStamina;
    public FakeAttak FakeAttak;
    public int posAttackfForFake;

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
        AttackIndicatorWide.SetActive(posAttack == 4);
    }

    void RandomAttack() {
        if (EnemyStamina.licznikStaminaEnemy > 0) {
            int pos = Random.Range(1, 5);
            posAttackfForFake = pos;
            Debug.Log("Generated attack position: " + posAttackfForFake);
            AttackIndicatorPositon(pos);

            FakeAttak.FakeRandomAttack();
        }
    }

    void Attack() {
        int posAttack = 0;
        if (AttacAttackIndicatorUp.activeSelf) posAttack = 1;
        if (AttacAttackIndicatorMiddle.activeSelf) posAttack = 2;
        if (AttacAttackIndicatorDown.activeSelf) posAttack = 3;
        if (AttackIndicatorWide.activeSelf) posAttack = 4;


        int pos = 0;
        if (SaberControl.SaberUp.activeSelf) pos = 1;
        if (SaberControl.SaberMiddle.activeSelf) pos = 2;
        if (SaberControl.SaberDown.activeSelf) pos = 3;
        if (SaberControl.SaberWide.activeSelf) pos = 4;

        StartCoroutine(AttackHide());

        if (pos == posAttack) {
            EnemyStamina.licznikStaminaEnemy--;
        } else {
            EnemyStamina.licznikStaminaEnemy++;
        }
    }


    IEnumerator AttackHide() {
        AttackIndicatorPositon(-1);
        yield return new WaitForSeconds(0.5f);
    }
}