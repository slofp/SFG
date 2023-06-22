using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeTransition : MonoBehaviour {

    public string sceneName;

    [SerializeField]
    Image image;

    public Color PanelColor {
        set {
            image.color = value;
		}
	}

    // Start is called before the first frame update
    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
    }

    public void ChangeScene() {
        SceneManager.LoadScene(sceneName);
    }

    public void EndTransition() {
        Destroy(gameObject);
    }
}
