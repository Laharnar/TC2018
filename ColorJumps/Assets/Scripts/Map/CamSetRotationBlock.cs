using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Set camera to x degrees, when player hits the block.
/// </summary>
public class CamSetRotationBlock : MonoBehaviour, ICollisionReciever {

    Transform cam;

    public float angleDegrees=0;

    private void Start() {
        cam = Camera.main.transform;
    }

    public void OnCollidePlayer(Player player) {
        cam.rotation = Quaternion.Euler(Vector3.forward * angleDegrees);
        Destroy(gameObject);
    }
}