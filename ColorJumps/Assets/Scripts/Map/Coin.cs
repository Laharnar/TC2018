
using System;
using UnityEngine;
public class Coin : MonoBehaviour, ICollisionReciever {
    public int amount = 1;

    public void OnCollidePlayer(Player player) {
        GameplayManager.AddCoin(amount);
        Destroy(gameObject);
    }

}
