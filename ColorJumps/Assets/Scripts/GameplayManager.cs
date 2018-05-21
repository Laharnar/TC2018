#define PC
using System;
using System.Collections;
using UnityEngine;
public class GameplayManager:MonoBehaviour {

    public Player playerSource;
    public UiManager uiSource;

    public static int coins=0;

    public static bool playerHasControl = false;
    public static bool mapIsGenerated = true;

    private void Start() {
        if (!playerSource)
            playerSource = GameObject.FindObjectOfType<Player>();
        if (!uiSource)
            uiSource = GameObject.FindObjectOfType<UiManager>();


        StartCoroutine(StartGame());
    }
    //TAP TO SWAP
    private IEnumerator StartGame() {
        coins = 0;
        mapIsGenerated = false;
        playerHasControl = false;
        yield return StartCoroutine(Tutorial.Run(playerSource));
        playerHasControl = true;
        mapIsGenerated = true;
        MapManager.StartBackground();
        PathGenerator.StartPath();
        Debug.Log("startgame: Load ui, load map, load tutorial");
    }

    private void Update() {
        if (playerSource.gameObject.activeSelf == false) {
            EndGame();
        }
        if (Input.GetKeyUp(KeyCode.R)) {
            EndGame();
            StartGame();
        }
    }

    private void EndGame() {
        Debug.Log("Endgame: Dissolve map and player, Load end ui");
        MapManager.StopBackground();
        playerHasControl = false;
    }

    internal static void AddCoin(int amount) {
        coins += amount;
    }
}
