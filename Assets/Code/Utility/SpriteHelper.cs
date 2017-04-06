using UnityEngine;
using System.Collections;

public class SpriteHelper : MonoBehaviour {

	SpriteRenderer localSprite;

	public Vector2 WorldSize; //{ get; protected set; }
	public Vector2 WorldOrigin; //{ get; protected set; }

	// Use this for initialization
	void Start () {
		localSprite = GetComponent<SpriteRenderer>();
		if (localSprite) {
			WorldSize = localSprite.bounds.size;
			WorldOrigin = localSprite.bounds.center;
		} else {
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		WorldOrigin = localSprite.bounds.center;
	}
}
