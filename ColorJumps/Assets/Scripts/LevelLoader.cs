
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader: MonoBehaviour {

    public static LevelLoader m;

    private void Start() {
        m = this;
    }

    public void LoadLevel(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

}