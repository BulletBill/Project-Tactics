using UnityEngine;
using System.Collections;

public class TileSelection : MonoBehaviour {

	//public enum SelectMode { None, TargetAlly, TargetEnemy, TargetArea, Move }
	//SelectMode CurrentMode = SelectMode.None;
	
	Vector2 MousePosition;
	Vector2 PrevMousePosition;

	int HoverX;
	int HoverY;
	float keyWaitTime;

	Battle_Tile SelectedTile;

	//Reference to the tile map
	Battle_TileMap TheTileMap;
	//Reference to the tile UI
	TerrainInfoUI TerrainInfo;

	// Use this for initialization
	void Start () {
		TheTileMap = GameObject.FindGameObjectWithTag("MainTileMap").GetComponent<Battle_TileMap>();
		TerrainInfo = GameObject.FindGameObjectWithTag("TerrainInfoUI").GetComponent<TerrainInfoUI>();
    }

	// Update is called once per frame
	Vector2 KeyboardDelta;
	int HorzDelta;
	int VertDelta;

	void Update () {
		MousePosition = Input.mousePosition;

		//Move hover selection with mouse
		if (PrevMousePosition != MousePosition) {
			Vector2 MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			ChangeHover(Mathf.Floor(MouseWorldPosition.x), Mathf.Floor(MouseWorldPosition.y));
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

		PrevMousePosition = MousePosition;
	}

	void ChangeHover(float NewX, float NewY) {
		HoverX = (int)NewX;
		HoverY = (int)NewY;

		this.transform.position = new Vector2(NewX, NewY);

		//Set info on the UI for the tile
		Battle_Tile hoverTile = GetHoverTile();
		if (hoverTile != null) {
			TerrainInfo.SetValues(GetHoverTile().description, GetHoverTile().GetComponent<SpriteRenderer>().sprite);
		}
	}

	Battle_Tile GetHoverTile() { 
		return TheTileMap.TileAt(HoverX, HoverY);
	}
}
