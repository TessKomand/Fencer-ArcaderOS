using NUnit.Framework.Internal;
using UnityEngine;

public class FakeAttak : MonoBehaviour {
    public EnemyStamina EnemyStamina;
    public AttackIndicatorApper posAttackForFake;
    public GameObject FakeAttackIndicatorUp;
    public GameObject FakeAttackIndicatorMiddle;
    public GameObject FakeAttackIndicatorDown;
    public AttackIndicatorApper AttackIndicatorApper;
    void Start() {
        FakeAttackIndicatorPositon(-1);
        InvokeRepeating("AttackRemove", 2.5f, 4f);
    }

    // Update is called once per frame
    void Update() {
    }

    public void FakeRandomAttack() {   
        if (EnemyStamina.licznikStaminaEnemy > 0) {
            int pos = Random.Range(1, 4);
            if (pos == AttackIndicatorApper.posAttackfForFake) {
                pos = -1;
            }
            if (AttackIndicatorApper.posAttackfForFake == 4) {
                pos = -1;
            }
            Debug.Log("Generated fake attack position: " + pos);
            FakeAttackIndicatorPositon(pos);
        }
    }

    void AttackRemove() {
        FakeAttackIndicatorPositon(-1);
    }

    public void FakeAttackIndicatorPositon(int posAttack) {
        FakeAttackIndicatorUp.SetActive(posAttack == 1);
        FakeAttackIndicatorMiddle.SetActive(posAttack == 2);
        FakeAttackIndicatorDown.SetActive(posAttack == 3);
    }
}
