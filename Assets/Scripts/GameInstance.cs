using UnityEngine;
using System.Collections;

public class GameInstance : MonoBehaviour {

	//Static reference to the game instance singleton
	public static GameObject Game;

	// Use this for initialization
	void Awake() {
		if (!Game) {
			DontDestroyOnLoad(this.gameObject);
			Game = this.gameObject;
		} else {
			GameObject.Destroy(this.gameObject);
		}
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
