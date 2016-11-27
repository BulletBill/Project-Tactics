using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Battle_Tile : MonoBehaviour {

	//Game rules for the tile, set in editor, saved with prefab
	public string Name;
	public int movementCost;
	public int coverBonus;
	public List<string> description;

	//Orientation is based on nearby tiles, or random in the case of something like rocks or debris
	//Affects which visual the tile will use
	int orientation;

	void Start() {

	}

	void Update() {

	}
}
