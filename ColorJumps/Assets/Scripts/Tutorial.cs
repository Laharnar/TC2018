#define PC
using System.Collections;
using UnityEngine;
public class Tutorial {
    internal static IEnumerator Run(Player player) {
        // TODO: display msg = TAP TO SWAP
        yield return new WaitForSeconds(0.5f);
        Debug.Log("asd");
        while (!Input.GetKeyUp(KeyCode.Space)) {
            Debug.Log("asd 2");
            yield return null;
        }
        Debug.Log("asd 3");
        player.Swap();
    }
}