#define PC
using System;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerSide {
    LEFT = 0,
    RIGHT = 1
}

public class Player : MonoBehaviour {

    public int health = 1;

    // Where player is positioned when left/right
    public Transform leftPos, rightPos;
    PlayerSide activeSide = PlayerSide.LEFT;
    
    // Update is called once per frame
	void Update () {
        if (GameplayManager.playerHasControl) {
#if UNITY_STANDALONE
            if (Input.GetKeyDown(KeyCode.Space)) {
#elif UNITY_ANDROID
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
#endif
                OnInput();
            }
        }
    }

    void OnInput() {
        Swap();
    }

    public void Swap() {
        switch (activeSide) {
            case PlayerSide.LEFT:
                activeSide = PlayerSide.RIGHT;
                transform.position = leftPos.position;
                break;
            case PlayerSide.RIGHT:
                activeSide = PlayerSide.LEFT;
                transform.position = rightPos.position;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        ICollisionReciever[] r = collision.GetComponents<ICollisionReciever>();
        foreach (var item in r) {
            item.OnCollidePlayer(this);
        }
    }

    internal void LoseHp() {
        health -= 1;
        if (health <= 0)
            gameObject.SetActive(false);
    }
}
