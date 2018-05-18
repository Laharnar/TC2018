#define PC
using System;
using UnityEngine;
public class Coin : MonoBehaviour, ICollisionReciever {
    public void OnCollidePlayer(Player player) {
        GameplayManager.AddCoin();
        Destroy(gameObject);
    }

}
