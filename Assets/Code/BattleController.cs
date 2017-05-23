using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StartingPosition {
	public enum LocationTeam { NONE, PLAYER, ENEMY }
	public LocationTeam Team;
	public Vector2 Location;
	public bool bUsed;
}

public class BattleController : MonoBehaviour {

	public GameObject TileSelectorPrefab;
	TileSelection TileSelector;

	public GameObject BattleMapPrefab;
	TileMap BattleMap;

	public Texture2D MapImage;
	public List<Combatant> Units;

	public List<StartingPosition> StartingPositions;

	//Used to convert pawn image names in the to pawn objects
	public PawnDefs PawnDefList;

	//Create instances of objects so they can be referenced by each other on Start
	void Awake () {
		//Spawn map
		GameObject BattleMapObj = Instantiate(BattleMapPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		if (BattleMapObj) { BattleMap = BattleMapObj.GetComponent<TileMap>(); }

		if (MapImage && BattleMap) {
			BattleMap.transform.SetParent(transform);
			BattleMap.GenerateTileMap(MapImage);
		}
		
		//Spawn tile selection object
		GameObject TileSelectorObj = Instantiate(TileSelectorPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		if (TileSelectorObj) {
			Camera.main.GetComponent<CameraMovement>().FollowObject = TileSelectorObj.transform;
			TileSelector = TileSelectorObj.GetComponent<TileSelection>();
		}
	}

	// Use this for initialization
	void Start () {
		//Spawn Units
		PopulateUnitList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void PopulateUnitList() {
		// Spawn units for the party
		if (GameInstance.Game != null && GameInstance.Game.Party != null) {

			foreach (Combatant c in GameInstance.Game.Party.PartyMembers) {
				Units.Add(c);

				GameObject PlayerPawn = PawnDefList.CreatePawnOfName("Character");
				if (null == PlayerPawn) continue;

				PlayerPawn.transform.position = FindStartingLocation(StartingPosition.LocationTeam.PLAYER);
				c.SetPawn(PlayerPawn);
			}
		}

		// Spawn units for the enemy
	}

	private Vector2 FindStartingLocation(StartingPosition.LocationTeam Team) {
		foreach (var s in StartingPositions) {
			if (false == s.bUsed && s.Team == Team) {
				s.bUsed = true;
				return s.Location;
			}
		}
		return Vector2.zero;
	}

// 	void OnDrawGizmos() {
// 		Gizmos.color = Color.red;
// 		foreach (var Spot in StartingPositions) {
// 			Gizmos.DrawSphere(new Vector3(Spot.Location.x, Spot.Location.y, 0.0f), 0.5f);
// 		}
// 	}
}