#define PC
using System.Collections;
using UnityEngine;
public class Tutorial {
    internal static IEnumerator Run() {
        // TODO: display msg = TAP TO SWAP
        yield return new WaitForSeconds(0.5f);
        while (!Input.GetKeyUp(KeyCode.Space)) {
            yield return null;
        }
    }
}