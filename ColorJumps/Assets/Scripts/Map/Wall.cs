
using System;
using UnityEngine;
public class Wall:MonoBehaviour, ICollisionReciever {
    public void OnCollidePlayer(Player player) {
        player.LoseHp();
        Destroy(gameObject);
    }

    private void OnDestroy() {
        //Debug.Log("Spawn wall destroy particles");
    }
}