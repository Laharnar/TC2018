
using UnityEngine;

/// <summary>
/// Rotates camera by x degrees, when player hits the block.
/// </summary>
public class CamRotateBlock : MonoBehaviour, ICollisionReciever {

    Transform cam;

    public float angleDegrees=0;

    private void Start() {
        cam = Camera.main.transform;
    }

    public void OnCollidePlayer(Player player) {
        cam.Rotate(Vector3.forward, angleDegrees);
        Destroy(gameObject);
    }
}