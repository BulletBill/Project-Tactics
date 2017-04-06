using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	public TileSelection TileSelector;

	public List<Combatant> Units;
	
	// Use this for initialization
	void Start () {
		PopulateUnitList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void PopulateUnitList() {

	}
}