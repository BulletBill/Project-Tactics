using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct BattleUnit {
	public Combatant UnitStats;
	public GameObject UnitPawn;
}

[System.Serializable]
public struct StartingPosition {
	public enum LocationTeam { NONE, PLAYER, ENEMY }
	public LocationTeam Team;
	public Vector2 Location;
}

public class BattleController : MonoBehaviour {

	public GameObject TileSelectorPrefab;
	GameObject TileSelectorObj;
	TileSelection TileSelector;

	public GameObject BattleMapPrefab;
	GameObject BattleMapObj;
	TileMap BattleMap;

	public Texture2D MapImage;
	public List<BattleUnit> Units;

	public List<StartingPosition> StartingPositions;

	//Used to convert pawn image names in the to pawn objects
	public PawnDefs PawnDefList;

	//Create instances of objects so they can be referenced by each other on Start
	void Awake () {
		//Spawn map
		BattleMapObj = Instantiate(BattleMapPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		if (BattleMapObj) { BattleMap = BattleMapObj.GetComponent<TileMap>(); }

		if (MapImage && BattleMap) {
			BattleMap.transform.SetParent(transform);
			BattleMap.GenerateTileMap(MapImage);
		}
		
		//Spawn tile selection object
		TileSelectorObj = Instantiate(TileSelectorPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		if (TileSelectorObj) {
			Camera.main.GetComponent<CameraMovement>().FollowObject = TileSelectorObj.transform;
			TileSelector = TileSelectorObj.GetComponent<TileSelection>();
		}

		//Spawn Units
		PopulateUnitList();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void PopulateUnitList() {
		if (GameInstance.Game != null && GameInstance.Game.Party != null) {
			foreach (Combatant c in GameInstance.Game.Party.PartyMembers) {
				BattleUnit NewUnit = new BattleUnit();
				NewUnit.UnitStats = c;
				GameObject PlayerPawn = PawnDefList.GetPawnOfName("Character");
				if (PlayerPawn) {
					NewUnit.UnitPawn = PlayerPawn;
				}

				Units.Add(NewUnit);
			}
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		foreach (var Spot in StartingPositions) {
			Gizmos.DrawSphere(new Vector3(Spot.Location.x, Spot.Location.y, 0.0f), 0.5f);
		}
	}
}