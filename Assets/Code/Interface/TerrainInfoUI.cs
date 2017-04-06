using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainInfoUI : MonoBehaviour {

	public UnityEngine.UI.Text MyText;
	public UnityEngine.UI.Image MyTileImage;	

	// Use this for initialization
	void Start () {
		//MyText = GetComponentInChildren<UnityEngine.UI.Text>();
		//MyTileImage = GetComponentInChildren<UnityEngine.UI.Image>();
	}
	
	public void SetValues(List<string> newText, Sprite newImage) {

		MyText.text = "";
		foreach (string s in newText) {
			MyText.text += s;
			MyText.text += "\n";
		}

		MyTileImage.overrideSprite = newImage;
	}
}
