using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Combatant {

	public string Name;

	// Action stuff
	bool HasActed;
	int ActionPoints;

	// Stats go here
	public Stat Endurance;
	public Stat Might;

	GameObject PawnObject;

	// Use this for initialization
	void Start () {
		Endurance.SetValue(Random.Range(10, 100));
		Might.SetValue(Random.Range(10, 100));

		Endurance.CreateMod("Armor", 10.0f, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPawn(GameObject NewPawn) {
		if (PawnObject) {
			GameObject.Destroy(PawnObject);
		}

		PawnObject = NewPawn;
	}
}
