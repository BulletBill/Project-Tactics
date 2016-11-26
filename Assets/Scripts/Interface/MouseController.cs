using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public GameObject TileHighlight;

	Vector2 MouseWorldPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		this.transform.position = MouseWorldPosition;

		if (TileHighlight != null) {
			Vector2 NewHighLightPosition = new Vector2(Mathf.Round(this.transform.position.x - 0.5f) + 0.5f, Mathf.Round(this.transform.position.y - 0.5f) + 0.5f);
			TileHighlight.transform.position = NewHighLightPosition;
        }
	}
}
