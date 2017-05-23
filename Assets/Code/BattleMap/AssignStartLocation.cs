using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Battle_Tile))]
public class AssignStartLocation : MonoBehaviour {

	public StartingPosition.LocationTeam TileTeam;

	// Use this for initialization
	void Awake () {
		Battle_Tile bt = GetComponent<Battle_Tile>();
		if (null == bt) return;

		BattleController bc = FindObjectOfType<BattleController>();
		if (null == bc) return;

		StartingPosition StartingStats = new StartingPosition();
		StartingStats.Location = bt.transform.position;
		StartingStats.Team = TileTeam;
		StartingStats.bUsed = false;

		bc.StartingPositions.Add(StartingStats);
	}

	// Update is called once per frame
	void Update() {
	}
}
