using System.Collections;
using UnityEngine;

public class Tutorial {

    internal static IEnumerator Run(Player player) {
        // TODO: display msg = TAP TO SWAP
        UiManager.LoadTutorialUi();
        GameObject line = GameObject.Find("Line");
        if (line) {
            line.GetComponent<Animator>().enabled = false;
            line.GetComponent<SpriteRenderer>().enabled=(false);
        }
        yield return new WaitForSeconds(0.5f);

#if UNITY_STANDALONE
        while (!Input.GetKeyUp(KeyCode.Space)) {
            yield return null;
        }
#elif UNITY_ANDROID
        while (Input.touchCount == 0) {
            yield return null;
        }
#endif

        if (line) {
            line.GetComponent<SpriteRenderer>().enabled=true;
            line.GetComponent<Animator>().enabled = true;
        }
        UiManager.LoadGameplayUi();
        player.Swap();
    }
}