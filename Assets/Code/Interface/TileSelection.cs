using UnityEngine;
using System.Collections;

public class TileSelection : MonoBehaviour {

	public enum SelectMode { Paused, FreeSelect, TargetTile }
	SelectMode CurrentMode = SelectMode.FreeSelect;

	Vector2 MousePosition;
	Vector2 PrevMousePosition;

	int HoverX;
	int HoverY;
	float keyWaitTime;

	public Battle_Tile SelectedTile;

	//Reference to the tile map
	TileMap TheTileMap;
	//Reference to the tile UI
	TerrainInfoUI TerrainInfo;

	// Use this for initialization
	void Start() {
		GameObject FindObject = GameObject.FindGameObjectWithTag("MainTileMap");
		TheTileMap = FindObject ? FindObject.GetComponent<TileMap>() : null;

		FindObject = GameObject.FindGameObjectWithTag("TerrainInfoUI");
		TerrainInfo = FindObject ? FindObject.GetComponent<TerrainInfoUI>() : null;
	}

	// Update is called once per frame
	Vector2 KeyboardDelta;
	int HorzDelta;
	int VertDelta;

	void Update() {
		MousePosition = Input.mousePosition;

		// Early exit when paused
		if (CurrentMode == SelectMode.Paused) return;

		//Move hover selection with mouse
		if (PrevMousePosition != MousePosition) {
			Vector2 MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			ChangeHover((int)MouseWorldPosition.x, (int)MouseWorldPosition.y);
		}

		//Move hover selection with digital input
		if (keyWaitTime <= 0) {
			KeyboardDelta.x = Input.GetAxis("Horizontal");
			KeyboardDelta.y = Input.GetAxis("Vertical");
			HorzDelta = 0;
			VertDelta = 0;

			if (KeyboardDelta.x < 0) { HorzDelta--; }
			if (KeyboardDelta.x > 0) { HorzDelta++; }
			if (KeyboardDelta.y < 0) { VertDelta--; }
			if (KeyboardDelta.y > 0) { VertDelta++; }

			if (HorzDelta != 0 || VertDelta != 0) {
				keyWaitTime = GameInstance.Game.Input.KeyRepeat;
				ChangeHover(HoverX + HorzDelta, HoverY + VertDelta);
			}
		} else {
			keyWaitTime -= Time.deltaTime;
		}

		//Reset repeat if all inputs are clear so you can quickly tap
		if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
			keyWaitTime = 0;
		}

		PrevMousePosition = MousePosition;
	}

	void ChangeHover(int NewX, int NewY) {
		if (null == TheTileMap) return;

		//Only operate if the new tile is valid
		Battle_Tile hoverTile = TheTileMap.TileAt(NewX, NewY) as Battle_Tile;

		if (null == hoverTile) return;

		SelectedTile = hoverTile;

		this.transform.position = new Vector2(NewX, NewY);
		HoverX = NewX;
		HoverY = NewY;

		TerrainInfo.SetValues(hoverTile.description, hoverTile.GetComponent<SpriteRenderer>().sprite);
	}
}

