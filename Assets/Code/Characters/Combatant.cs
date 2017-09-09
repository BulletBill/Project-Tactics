using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Combatant {

	static int[] SpeedToAP = new int[19] { 5, 5, 5, 5, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 10, 11 };

	public string Name;

	// Action stuff
	bool HasActed;
	List<Ability> Abilities = new List<Ability>();

	// Stat levels go here
	[Header("Base Stats")]
	public Stat Endurance = new Stat(3);
	public Stat Stamina = new Stat(3);
	public Stat Might = new Stat(3);
	public Stat Mind = new Stat(3);
	public Stat Skill = new Stat(3);
	public Stat Speed = new Stat(3);
	public Stat Insight = new Stat(3);

	// Derived Stats
	[Header("Derived Values")]
	public Stat EndurancePoints = new Stat();
	public Stat StaminaPoints = new Stat();
	public Stat ActionPoints = new Stat();
	public int ManaPoints;
	public int FaithPoints;

	public Stat Armor = new Stat();

	// Battle visuals
	GameObject PawnObject;

	// Use this for initialization
	public virtual void Start () {
		UpdateStats();
	}

	public void UpdateStats() {
		EndurancePoints.SetValue((10 * Endurance.Value) + (Endurance.Value * 2));
		EndurancePoints.ResetSlidingValue();

		StaminaPoints.SetValue((3 * Stamina.Value) + (Stamina.Value));
		StaminaPoints.ResetSlidingValue();

		if (Speed.Value < SpeedToAP.Length) {
			ActionPoints.SetValue(SpeedToAP[(int)Speed.Value]);
			ActionPoints.ResetSlidingValue();
        }
	}

	public void SetPawn(GameObject NewPawn) {
		if (PawnObject) {
			GameObject.Destroy(PawnObject);
		}

		PawnObject = NewPawn;
	}

	public void OnValidate() {
		Endurance.Recalculate();
		Endurance.ResetSlidingValue();

		Stamina.Recalculate();
		Stamina.ResetSlidingValue();

		Might.Recalculate();
		Might.ResetSlidingValue();

		Mind.Recalculate();
		Mind.ResetSlidingValue();

		Skill.Recalculate();
		Skill.ResetSlidingValue();

		Speed.Recalculate();
		Speed.ResetSlidingValue();

		Insight.Recalculate();
		Insight.ResetSlidingValue();

		UpdateStats();
	}
}
