#define PC
using UnityEngine;
public class UiManager:MonoBehaviour {

    public UnityEngine.UI.Text coinsTarget;
    public string coinsPrefix;

    // Update is called once per frame
    void Update() {
        coinsTarget.text = coinsPrefix + GameplayManager.coins;
    }

    void LoadGameplayUi() {
        // nothing?
    }

    void LoadEndGameUi() {
        // total score (coins)
        // checkpoints? direction changes?
    }
}
