using System.Collections;
using UnityEngine;
public class GameplayManager:MonoBehaviour {

    public Player playerSource;

    public static int coins=0;

    public static bool playerHasControl = false;
    public static bool mapIsGenerated = true;

    private void Start() {
        if (!playerSource)
            playerSource = GameObject.FindObjectOfType<Player>();

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
#if UNITY_STANDALONE
        // restart level
        if (Input.GetKeyUp(KeyCode.R)) {
            EndGame();
            StartGame();
        }
#endif
    }

    private void EndGame() {
        Debug.Log("Endgame: Dissolve map and player, Load end ui");
        MapManager.StopBackground();
        playerHasControl = false;
        UiManager.LoadEndGameUi();
    }

    internal static void AddCoin(int amount) {
        coins += amount;
    }
}
