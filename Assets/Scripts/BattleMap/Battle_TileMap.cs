using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Battle_TileMap : MonoBehaviour {

	//Used to convert colors in the map image to tile objects
	public TileDefs TileDefList;

	//Array of tiles to represent the map
	List<Battle_Tile> map = new List<Battle_Tile>();

	//Idealy we could generate the map from an image
	public Texture2D mapImage;

	//GameObject used for tileselection
	public Object TileSelectorObject;
	TileSelection TileSelector;

	//Set by loaded map asset
	int sizeX;
	int sizeY;

	// Use this for initialization
	void Start () {
		GenerateTileMap();

		GameObject ts = GameObject.Instantiate(TileSelectorObject) as GameObject;
		TileSelector = ts.GetComponent<TileSelection>();
	}

	//------------------------------------------------------
	//------------------------------------------------------
	//Creates the array of tile objects the make up the map
	void GenerateTileMap() {
		EmptyMap();

		Color32[] allPixels = mapImage.GetPixels32();
		sizeX = mapImage.width;
		sizeY = mapImage.height;

		//Set camera bounds based on size
		Camera.main.GetComponent<CameraMovement>().SetCameraBounds(sizeX, sizeY);

		for (int x = 0; x < sizeX; x++) {
			for (int y = 0; y < sizeY; y++) {

				SpawnTileAt(allPixels[(y * sizeX) + x], x, y);

			}
		}
	}

	void EmptyMap() {
		while (transform.childCount > 0) {
			Transform child = transform.GetChild(0);
			child.SetParent(null);
			DestroyImmediate(child.gameObject);
		}
	}

	void SpawnTileAt(Color32 c, int x, int y) {

		foreach (ColorToTile ctp in TileDefList.colorToPrefab) {
			if (ctp.color.Equals(c)) { //ctp.color.r == c.r && ctp.color.g == c.g && ctp.color.b == c.b && ctp.color.a == c.a) {
				GameObject go = Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
				go.transform.parent = transform;

				Battle_Tile newTile = go.GetComponent<Battle_Tile>();
				if (newTile != null) {
					map.Add(go.GetComponent<Battle_Tile>());
				} else {
					Debug.LogError("Object is not a battle tile at: " + x.ToString() + "," + y.ToString());
				}
				return;
			}
		}
		Debug.LogError("No match found for tile with color:" + c.ToString() + " at " + x.ToString() + "," + y.ToString());
	}

	//------------------------------------------------------
	//------------------------------------------------------
	//Map helper functions
	public Battle_Tile TileAt(int tx, int ty) {
		int index = (ty * sizeX) + tx;
		if (index < map.Count) {
			return map[index];
		}

		Debug.LogError("Tile array index of " + index.ToString() + " is out of bounds.");
		return null;
	}
}
