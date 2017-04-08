using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	public TileSelection TileSelector;
	public Battle_TileMap BattleMap;
	public List<Combatant> Units;
	
	// Use this for initialization
	void Start () {
		PopulateUnitList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void PopulateUnitList() {
		if (GameInstance.Game != null && GameInstance.Game.Party != null)
		foreach (Combatant c in GameInstance.Game.Party.PartyMembers) {
			Units.Add(c);
		}
	}
}