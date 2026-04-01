using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class SaberControl : MonoBehaviour {
    public GameObject SaberUp;
    public GameObject SaberMiddle;
    public GameObject SaberDown;
    public GameObject SaberWide;
    public EnemyStamina EnemyStamina;
    int HitDone = 0;
    bool canAttack = true;
    void Start() {
        SaberPositon(2);
    }

    // Update is called once per frame
    void Update() {
        if (Keyboard.current.wKey.wasPressedThisFrame) SaberPositon(1);
        if (Keyboard.current.dKey.wasPressedThisFrame) SaberPositon(2);
        if (Keyboard.current.sKey.wasPressedThisFrame) SaberPositon(3);
        if (Keyboard.current.fKey.wasPressedThisFrame) SaberPositon(4);
        if (EnemyStamina.licznikStaminaEnemy <= 0 && canAttack == true) {
            if (Keyboard.current.gKey.wasPressedThisFrame) StartCoroutine(PlayerAttackMove());
        }
    }

    public void SaberPositon(int pos) {
        SaberUp.SetActive(pos == 1);
        SaberMiddle.SetActive(pos == 2);
        SaberDown.SetActive(pos == 3);
        SaberWide.SetActive(pos == 4);
        if (pos != 4) {
            canAttack = true;
        } else {
            canAttack = false;
        }

    }




    IEnumerator PlayerAttackMove() {

        GameObject activeSaber = null;
        if (SaberUp.activeSelf) activeSaber = SaberUp;
        if (SaberMiddle.activeSelf) activeSaber = SaberMiddle;
        if (SaberDown.activeSelf) activeSaber = SaberDown;
        if (activeSaber == null) yield break;

        Vector2 originalPosition = transform.position;
        Vector2 movePositon = originalPosition + new Vector2(10f, 0);
        float time = 0.2f;
        float t = 0;

        while (t < 1f) {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(originalPosition, movePositon, t);
            yield return null;
        }

        
        t = 0f;
        while (t < 1f) {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(movePositon, originalPosition, t);
            yield return null;
        }
    }

}
