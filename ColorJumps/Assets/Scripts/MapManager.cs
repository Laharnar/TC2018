#define PC
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager:MonoBehaviour {

    public static MapManager m;

    public List<BackgroundItem> backgroundSlots=new List<BackgroundItem>();
    public List<Transform> pathItems=new List<Transform>();

    /// <summary>
    /// Standard height of all background.
    /// </summary>
    public float backgroundSize = 10f;

    public float backgroundSpeed = 1;
    public float pathSpeed = 1;
    float originalSpeed = 0;

    public Transform spawnPoint;

    public float minPoint = -20f;

    private void Start() {
        m = this;
        originalSpeed = backgroundSpeed;
        // init background
        if (backgroundSlots.Count >= 2) {
            backgroundSlots[0].instance.transform.position = Vector3.up * backgroundSize;
            backgroundSlots[1].instance.transform.position = Vector3.up * backgroundSize * 2;
        }
    }

    private void Update() {
        // move backgrounds and keep them aligned
        for (int i = 0; i < backgroundSlots.Count; i++) {
            if (backgroundSlots[i].instance.position.y < minPoint) {
                int prevBkg = (i - 1+backgroundSlots.Count) % backgroundSlots.Count;
                backgroundSlots[i].instance.position = (Vector2)backgroundSlots[prevBkg].instance.position+Vector2.up*backgroundSize;
            }
            backgroundSlots[i].instance.Translate(Vector2.down * Time.deltaTime * backgroundSpeed);
            
        }
        // move items
        for (int i = 0; i < pathItems.Count; i++) {
            if (pathItems[i] == null) {
                pathItems.RemoveAt(i);
                i--;
                continue;
            }
            pathItems[i].Translate(Vector2.down * Time.deltaTime * pathSpeed);
            if (pathItems[i].transform.position.y < minPoint) {
                Destroy(pathItems[i].gameObject);
            }
        }
    }

    internal static void StopBackground() {
        m.backgroundSpeed = 0;
    }

    internal static void StartBackground() {
        m.backgroundSpeed = m.originalSpeed;
    }

}
