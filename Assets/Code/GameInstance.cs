using UnityEngine;
using System.Collections;

public class GameInstance : MonoBehaviour {

	//Static reference to the game instance singleton
	public static GameInstance Game;

	public InputSettings Input;

	public PartyOfCharacters Party;

	// Use this for initialization
	void Awake() {
		if (!Game) {
			DontDestroyOnLoad(this.gameObject);
			Game = this;
		} else {
			GameObject.Destroy(this.gameObject);
		}
	}

	void Start () {
		Input = new InputSettings();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
