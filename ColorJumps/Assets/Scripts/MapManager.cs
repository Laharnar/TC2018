#define PC
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager:MonoBehaviour {

    public static MapManager m;

    public List<BackgroundItem> backgroundSlots=new List<BackgroundItem>();

    /// <summary>
    /// Standard height of all background.
    /// </summary>
    public float backgroundSize = 10f;

    public float speed = 1;

    public Transform spawnPoint;

    private void Start() {
        m = this;
        if (backgroundSlots.Count >= 2) {
            backgroundSlots[0].instance.transform.position = Vector3.up * backgroundSize;
            backgroundSlots[1].instance.transform.position = Vector3.up * backgroundSize * 2;
        }
    }

    private void Update() {
        // keep backgrounds stacked 1 after another
        for (int i = 0; i < backgroundSlots.Count; i++) {
            if (backgroundSlots[i].instance.position.y < -backgroundSize) {
                int prevBkg = (i + 1) % backgroundSlots.Count;
                backgroundSlots[i].instance.position = (Vector2)backgroundSlots[prevBkg].instance.position+Vector2.up*backgroundSize;
            }
            backgroundSlots[i].instance.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }
}
