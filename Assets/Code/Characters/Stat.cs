using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Stat {

	public float FinalValue { get; protected set; }
	public float BaseValue { get; protected set; }
	Dictionary<string, float> AddModifiers;
	Dictionary<string, float> MultiModifiers;

	public Stat() {
		BaseValue = 0.0f;
		FinalValue = BaseValue;
		AddModifiers.Clear();
		MultiModifiers.Clear();
	}

	public Stat(float StartingValue, bool HasMax) {
		BaseValue = StartingValue;
		FinalValue = BaseValue;
		AddModifiers.Clear();
		MultiModifiers.Clear();
	}

	void SetValue(float NewBase) {
		BaseValue = NewBase;
		Recalculate();
	}

	void ChangeValue(float Amount) {
		BaseValue += Amount;
		Recalculate();
	}

	void CreatedMod(string Ident, float Value, bool IsMulti) {
		Dictionary<string, float> WorkingDict = IsMulti ? MultiModifiers : AddModifiers;

		if (WorkingDict.ContainsKey(Ident)) {
			WorkingDict[Ident] = Value;
			return;
		}

		WorkingDict.Add(Ident, Value);
	}

	void RemoveMod(string Ident, bool IsMulti) {
		Dictionary<string, float> WorkingDict = IsMulti ? MultiModifiers : AddModifiers;

		if (WorkingDict.ContainsKey(Ident)) {
			WorkingDict.Remove(Ident);
		}
	}

	void Recalculate() {
		FinalValue = BaseValue;

		foreach (var f in AddModifiers) {
			FinalValue += f.Value;
		}

		float TotalMulti = 1.0f;
		foreach (var f in MultiModifiers) {
			TotalMulti += f.Value;
		}

		FinalValue *= TotalMulti < 0.0f ? 0.0f : TotalMulti;
	}
}
