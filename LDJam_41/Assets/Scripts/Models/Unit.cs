using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Faction {Humans, Animals, Cursed, Raiders}
public class Unit  {

	public string name {get; protected set;}
	public Faction faction {get; protected set;}
	public float speed {get; protected set;}

	public Unit(string _name, Faction _faction, float moveSpeed){
		name = _name;
		faction = _faction;
		speed = moveSpeed;
	}
}
