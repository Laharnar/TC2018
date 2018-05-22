using UnityEngine;

public class UiManager:MonoBehaviour {

    static UiManager m;

    public GameObject tutorialUI;
    public GameObject gameplayUI;
    public GameObject endgameUI;

    private void Awake() {
        m = this;
    }


    public static void LoadTutorialUi() {
        m.tutorialUI.SetActive(true);
        m.gameplayUI.SetActive(false);
        m.endgameUI.SetActive(false);
    }

    public static void LoadGameplayUi() {
        m.tutorialUI.SetActive(false);
        m.gameplayUI.SetActive(true);
        m.endgameUI.SetActive(false);
    }

    public static void LoadEndGameUi() {
        m.tutorialUI.SetActive(false);
        m.gameplayUI.SetActive(false);
        m.endgameUI.SetActive(true);
    }
}
