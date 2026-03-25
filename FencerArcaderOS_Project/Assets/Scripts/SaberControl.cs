using UnityEngine;
using UnityEngine.InputSystem;

public class SaberControl : MonoBehaviour {
    public GameObject SaberUp;
    public GameObject SaberMiddle;
    public GameObject SaberDown;
    public AttackIndicatorApper AttackIndicatorApper;
    void Start() {
        SaberPositon(2);
    }

    // Update is called once per frame
    void Update() {
        if (Keyboard.current.wKey.wasPressedThisFrame) SaberPositon(1);
        if (Keyboard.current.dKey.wasPressedThisFrame) SaberPositon(2);
        if (Keyboard.current.sKey.wasPressedThisFrame) SaberPositon(3);
    }

    public void SaberPositon(int pos) {
        SaberUp.SetActive(pos == 1);
        SaberMiddle.SetActive(pos == 2);
        SaberDown.SetActive(pos == 3);
    }
}
