
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Background/bkg", order = 1)]
public class BackgroundItem:ScriptableObject {
    public Transform pref;
    Transform _instance;
    internal Transform instance {
        get {
            if (_instance == null) {
                _instance = Instantiate(pref, MapManager.m.spawnPoint.position, new Quaternion());
            }
            return _instance;
        }
    }
}