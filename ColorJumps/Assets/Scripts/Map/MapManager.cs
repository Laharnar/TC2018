
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves level and backgrounds down, and makes sure backgrounds repeat.
/// </summary>
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
    float originalBackgroundSpeed = 0;
    float originalPathSpeed = 0;

    public Transform spawnPoint;

    public float minPoint = -20f;

    public float speedMultiplier = 1.06f;


    private void Start() {
        m = this;

        originalBackgroundSpeed = backgroundSpeed;
        originalPathSpeed = pathSpeed;

        // init background
        for (int i = 0; i < backgroundSlots.Count; i++) {
            backgroundSlots[i].instance.transform.position = Vector3.up * backgroundSize*(i);
        }

        StartCoroutine(IncreaseSpeed());
    }

    private IEnumerator IncreaseSpeed() {
        while (true) {
            yield return new WaitForSeconds(5);
            pathSpeed *= speedMultiplier;
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
        m.backgroundSpeed = m.originalBackgroundSpeed;
        m.pathSpeed = m.originalPathSpeed;
    }

}
