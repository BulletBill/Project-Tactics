using UnityEngine;
using System.Collections;

public class TileSelection : MonoBehaviour {

	public enum SelectMode { None, TargetAlly, TargetEnemy, TargetArea, Move }
	SelectMode CurrentMode = SelectMode.None;
	
	Vector2 MouseWorldPosition;
	Vector2 PrevMouseWorldPosition;

	int SelectionX;
	int SelectionY;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (PrevMouseWorldPosition != MouseWorldPosition) {
			ChangeSelection(Mathf.Floor(MouseWorldPosition.x), Mathf.Floor(MouseWorldPosition.y));
		}		

		PrevMouseWorldPosition = MouseWorldPosition;
	}

	void ChangeSelection(float NewX, float NewY) {
		SelectionX = (int)NewX;
		SelectionY = (int)NewY;

		this.transform.position = new Vector2(NewX, NewY);
	}
}
