using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NameToPawn {
	public string name;
	public GameObject prefab;
}

// This class exists to have a central definition for converting named unit data to visible sprites
// All values should be defined in the editor and saved as a prefab to be used in the approriate scene
public class PawnDefs : MonoBehaviour {

	static public PawnDefs NameToPawn { get; protected set; }

	public List<NameToPawn> nameToPrefab;

	void Start() {
	}

	public GameObject CreatePawnOfName(string Name) {
		foreach (var p in nameToPrefab) {
			if (p.name == Name) {

				return Instantiate(p.prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			}
		}

		return null;
	}

}