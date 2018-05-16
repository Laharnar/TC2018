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
        yield return StartCoroutine(Tutorial.Run());
        throw new NotImplementedException("Load ui, load map, load tutorial");
    }

    private void Update() {
        if (playerSource.health < 1) {
            EndGame();
        }
    }

    private void EndGame() {
        throw new NotImplementedException("Dissolve map and player, Load end ui");
    }
}
