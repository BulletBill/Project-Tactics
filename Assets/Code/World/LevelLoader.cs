using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

	public Texture2D LevelMap;

	// Use this for initialization
	void Start () {
		LoadMap();
	}

	void EmptyMap() {
		while (transform.childCount > 0) {
			Transform child = transform.GetChild(0);
			child.SetParent(null);
			Destroy(child.gameObject);
		}
	}
	
	void LoadMap() {
		EmptyMap();

		Color32[] allPixels = LevelMap.GetPixels32();
		int width = LevelMap.width;
		int height = LevelMap.height;

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {

				SpawnTileAt(allPixels[(y * width) + x], x, y);

			}
		}
	}

	void SpawnTileAt( Color32 c, int x, int y) {

		//Fully transparent pixel
		if (c.a <= 0) {
			return;
		}

		foreach(ColorToTile ctp in TileDefs.ColorToTile.colorToPrefab) {
			if (ctp.color.Equals(c)) { //ctp.color.r == c.r && ctp.color.g == c.g && ctp.color.b == c.b && ctp.color.a == c.a) {
				GameObject go = Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
				return;
			}
		}

		Debug.LogError("No match found for tile with color:" + c.ToString() + " at " + x.ToString() + "," + y.ToString());

	}
}
