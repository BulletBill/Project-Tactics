using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartyOfCharacters : MonoBehaviour {

	public List<PartyMember> PartyMembers;

	// Use this for initialization
	void Awake() {
		InitParty();
	}

	void Start () {
		foreach (var p in PartyMembers) {
			p.Start();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitParty() {
		PartyMembers = new List<PartyMember>();

		const int PartySize = 4;
		for (int i = 0; i < PartySize; i++) {
			PartyMembers.Add(new PartyMember());
		}

		//Temp init
		PartyMembers[0].Name = "Mandolin";
		PartyMembers[1].Name = "Brom";
		PartyMembers[2].Name = "Silver Winter";
		PartyMembers[3].Name = "Kabui";
	}

	void OnValidate() {
		foreach (var p in PartyMembers) {
			p.OnValidate();
		}
	}
}
