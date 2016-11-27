using UnityEngine;
using System.Collections;

public class TileSelection : MonoBehaviour {

	public enum SelectMode { None, TargetAlly, TargetEnemy, TargetArea, Move }
	SelectMode CurrentMode = SelectMode.None;
	GameObject CurrentTarget;

	public Object TileHighlightPrefab;
	GameObject TileHighlight;

	Vector2 MouseWorldPosition;
	Vector2 PrevMouseWorldPosition;

	int SelectionX;
	int SelectionY;

	// Use this for initialization
	void Start () {
		TileHighlight = GameObject.Instantiate(TileHighlightPrefab) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (PrevMouseWorldPosition != MouseWorldPosition) {
			this.transform.position = MouseWorldPosition;

			if (TileHighlight != null) {
				Vector2 NewHighLightPosition = new Vector2(Mathf.Floor(this.transform.position.x), Mathf.Floor(this.transform.position.y));
				TileHighlight.transform.position = NewHighLightPosition;
			}
		}		

		PrevMouseWorldPosition = MouseWorldPosition;
	}

	void ChangeSelection(int NewX, int NewY) {
		SelectionX = NewX;
		SelectionY = NewY;

		TileHighlight.transform.position = new Vector2(NewX, NewY);
	}
}
