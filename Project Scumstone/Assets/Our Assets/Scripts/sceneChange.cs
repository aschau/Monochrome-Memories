using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class sceneChange : MonoBehaviour {
    public string sceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void stageLoader()
    {
        SceneManager.LoadScene(sceneName);
    }
}
