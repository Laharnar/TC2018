using UnityEngine;
public class UiShowCoins:MonoBehaviour {

    public UnityEngine.UI.Text coinsTarget;
    public string coinsPrefix = "";

    // Update is called once per frame
    void Update() {
        coinsTarget.text = coinsPrefix + GameplayManager.coins;
    }
}
