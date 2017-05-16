using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NameToPawn {
	public string name;
	public GameObject prefab;
}

//This class exists to have a central definition for converting colored unit data to visible sprites
//All values should be defined in the editor and saved as a prefab to be used in the approriate scene
public class PawnDefs : MonoBehaviour {

	static public PawnDefs NameToPawn { get; protected set; }

	public List<NameToPawn> nameToPrefab;

	void Start() {
	}

	public GameObject GetPawnOfName(string Name) {
		foreach (var p in nameToPrefab) {
			if (p.name == Name) {
				return p.prefab;
			}
		}

		return null;
	}

}