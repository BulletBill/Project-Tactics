using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PartyMember : Combatant {

	// Party member is a player controlled combatant that has extra information specific to the player
	// Such as equipment, abilities and experience points

	List<string> Items;

	// Use this for initialization
	public override void Start () {
		base.Start();
	}
	
}
