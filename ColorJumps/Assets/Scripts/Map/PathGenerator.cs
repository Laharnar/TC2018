
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns interactible parts of level.
/// </summary>
public class PathGenerator:MonoBehaviour {
    public static PathGenerator m;
    [Range(0f, 1f)]
    public float trackEmptyness = 0.5f; // 1: full every x secs

    [Range(0f, 1f)]
    public float coinVsWallWeight = 0.3f;// 0.3 -> one third will be coins, 1 -> all coins

    [Range(0f, 1f)]
    public float camChangeWeight = 0.1f;// 0.3 -> one third will be coins, 1 -> all coins

    public float spawnRate = 1f;

    public List<Transform> coinPrefs = new List<Transform>();
    public List<Transform> wallPrefs = new List<Transform>();
    public List<Transform> camChangesPrefs = new List<Transform>();

    private void Awake() {
        m = this;
    }

    public static void StartPath() {
        m.StartCoroutine(m.Generator());
    }

    private IEnumerator Generator() {
        yield return new WaitForEndOfFrame();
        while (GameplayManager.mapIsGenerated) {
            int spawnMode = ChooseSpawnItem();
            if (spawnMode == -1) {
                // nothing
            } else if (spawnMode == 0) {
                SpawnRandomItemOnMap(camChangesPrefs);
            } else if (spawnMode == 1 && coinPrefs.Count > 0) {
                // spawn coin
                SpawnRandomItemOnMap(coinPrefs);
            } else if (spawnMode == 2) {
                // spawn wall
                SpawnRandomItemOnMap(wallPrefs);
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnRandomItemOnMap(List<Transform> items) {
        if (items.Count > 0) {
            int id = UnityEngine.Random.Range(0, items.Count);
            GeneratedPath.AddItem(Instantiate(items[id], MapManager.m.spawnPoint.transform.position, new Quaternion()));
        } else {
            Debug.Log("No items to spawn.");
        }
    }

    private int ChooseSpawnItem() {
        int id = -1; // nothing
        bool spawnSmth = UnityEngine.Random.Range(0f, 1f) > trackEmptyness;
        if (spawnSmth) {
            if (UnityEngine.Random.Range(0, 1f) <= camChangeWeight)
                return 0;// camera change
            if (coinVsWallWeight == 1 || UnityEngine.Random.Range(0f, 1f) <= coinVsWallWeight)
                return 1; // coin
            else return 2; // wall
        }
        return id;
    }
}

public static class GeneratedPath {

    public static void AddItem(Transform pathItem) {
        MapManager.m.pathItems.Add(pathItem);
    }
}