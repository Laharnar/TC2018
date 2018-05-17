#define PC
using UnityEngine;
public class Wall:MonoBehaviour {

    private void OnDestroy() {
        Debug.Log("Spawn wall destroy particles");
    }
}