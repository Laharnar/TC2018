#define PC
using System;
using System.Collections;
using UnityEngine;
public class GameplayManager:MonoBehaviour {

    public Player playerSource;
    public UiManager uiSource;

    public static bool playerHasControl = false;

    private void Start() {
        if (!playerSource)
            playerSource = GameObject.FindObjectOfType<Player>();
        if (!uiSource)
            uiSource = GameObject.FindObjectOfType<UiManager>();


        StartCoroutine(StartGame());
    }
    //TAP TO SWAP
    private IEnumerator StartGame() {
        yield return StartCoroutine(Tutorial.Run(playerSource));
        playerHasControl = true;
        Debug.Log("startgame: Load ui, load map, load tutorial");
    }

    private void Update() {
        if (playerSource.health < 1) {
            EndGame();
        }
    }

    private void EndGame() {
        Debug.Log("Endgame: Dissolve map and player, Load end ui");
    }
}
