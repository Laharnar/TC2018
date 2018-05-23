
using System;
using UnityEngine;
public class Coin : MonoBehaviour, ICollisionReciever {
    public int amount = 1;
    public bool addCoin = true;

    public void OnCollidePlayer(Player player) {
        if (addCoin)
            GameplayManager.AddCoin(amount);
        Destroy(gameObject);
    }

}
