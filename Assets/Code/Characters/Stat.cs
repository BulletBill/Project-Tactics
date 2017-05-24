using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Stat {

	public float FinalValue;    // The maximum value of the stat
	public float BaseValue;     // The base unmodified value of the state
	public float Value;  // value that can slide between 0 and the Max value. Used for resources like health, mana, xp, etc
	Dictionary<string, float> AddModifiers;
	Dictionary<string, float> MultiModifiers;

	public Stat() {
		BaseValue = 0.0f;
		FinalValue = BaseValue;
		Value = BaseValue;

		AddModifiers = new Dictionary<string, float>();
		MultiModifiers = new Dictionary<string, float>();
	}

	public Stat(float StartingValue) {
		BaseValue = StartingValue;
		FinalValue = StartingValue;
		Value = StartingValue;

		AddModifiers = new Dictionary<string, float>();
		MultiModifiers = new Dictionary<string, float>();
	}

	// Sets the BASE value
	public void SetValue(float NewBase) {
		BaseValue = NewBase;
		Recalculate();
	}

	// Changes the BASE value by an amount
	public void ChangeValue(float Amount) {
		BaseValue += Amount;
		Recalculate();
	}

	// Adds a new MODIFIER or replaces an existing one with the same name
	public void CreateMod(string Ident, float Value, bool IsMulti) {
		Dictionary<string, float> WorkingDict = IsMulti ? MultiModifiers : AddModifiers;

		if (WorkingDict.ContainsKey(Ident)) {
			WorkingDict[Ident] = Value;
			return;
		}

		WorkingDict.Add(Ident, Value);
		Recalculate();
	}

	// Removes a MODIFIER of a given name
	public void RemoveMod(string Ident, bool IsMulti) {
		Dictionary<string, float> WorkingDict = IsMulti ? MultiModifiers : AddModifiers;

		if (WorkingDict.ContainsKey(Ident)) {
			WorkingDict.Remove(Ident);
		}
		Recalculate();
	}

	// Removes all MODIFIERs
	public void ClearMods() {
		AddModifiers.Clear();
		MultiModifiers.Clear();
		Recalculate();
	}

	// Calculates a FINAL maximum value by applying MODIFIERs to the BASE value
	public void Recalculate() {
		FinalValue = BaseValue;

		foreach (var f in AddModifiers) {
			FinalValue += f.Value;
		}

		float TotalMulti = 1.0f;
		foreach (var f in MultiModifiers) {
			TotalMulti += f.Value;
		}

		FinalValue *= TotalMulti < 0.0f ? 0.0f : TotalMulti;

		Value = Mathf.Clamp(Value, 0.0f, FinalValue);
	}

	// Sets the SLIDING value to the FINAL value
	public void ResetSlidingValue() {
		Value = FinalValue;
	}

	// Adds the given amount to the SLIDING value, returns the new SLIDING value
	public float AddSlidingValue(float Adjustment) {
		Value += Adjustment;
		Value = Mathf.Clamp(Value, 0.0f, FinalValue);

		return Value;
	}

	public float MultiplySlidingValue(float Adjustment) {
		Value *= Adjustment;
		Value = Mathf.Clamp(Value, 0.0f, FinalValue);

		return Value;
	}
}