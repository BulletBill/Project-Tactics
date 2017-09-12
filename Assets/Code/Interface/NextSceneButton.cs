using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour {

	public string SceneToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonPress() {
		SceneManager.LoadScene(SceneToLoad);
	}
}
