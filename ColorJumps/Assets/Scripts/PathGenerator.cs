#define PC
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator:MonoBehaviour {

    [Range(0f, 1f)]
    public float trackEmptyness = 0.5f; // 1: full every x secs

    [Range(0f, 1f)]
    public float coin_wall_weight = 0.3f;// 0.3 -> one third will be coins, 1 -> all coins

    public float spawnRate = 1f;

    public List<Transform> coinPrefs = new List<Transform>();
    public List<Transform> wallPrefs = new List<Transform>();

    private void Start() {
        StartCoroutine(Generator());
    }

    private IEnumerator Generator() {
        yield return null;
        while (GameplayManager.mapIsGenerated) {
            int spawnMode = GetSpawnId();
            if (spawnMode == -1) {
                // nothing
            } else
            if (spawnMode == 1 && coinPrefs.Count > 0) {
                // spawn coin
                int id = Random.Range(0, coinPrefs.Count);
                GeneratedPath.AddItem(Instantiate(coinPrefs[id], MapManager.m.spawnPoint.transform.position, new Quaternion()));
            } else if (spawnMode == 2) {
                // spawn wall
                if (wallPrefs.Count > 0) {
                    int id = Random.Range(0, wallPrefs.Count);
                    GeneratedPath.AddItem(Instantiate(wallPrefs[id], MapManager.m.spawnPoint.transform.position, new Quaternion()));
                } else {
                    Debug.Log("Nothing to spawn, no data.", this);
                }
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private int GetSpawnId() {
        int id = -1; // nothing
        bool spawnSmth = UnityEngine.Random.Range(0f, 1f) > trackEmptyness;
        if (spawnSmth) {
            return coin_wall_weight == 1 
                || UnityEngine.Random.Range(0f, 1f) <= coin_wall_weight ? 1 : 2;
        }
        return id;
    }
}

public static class GeneratedPath {

    public static void AddItem(Transform pathItem) {
        MapManager.m.pathItems.Add(pathItem);
    }
}