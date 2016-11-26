using UnityEngine;
using System.Collections;

public class Battle_Tile : MonoBehaviour {

	//Game rules for the tile
	public string Name;
	public bool blocking;
	public int movementCost;
	public int coverBonus;

	//Orientation is based on nearby tiles, or random in the case of something like rocks or debris
	//Affects which visual the tile will use
	int orientation;

	void Start() {

	}

	void Update() {

	}
}
