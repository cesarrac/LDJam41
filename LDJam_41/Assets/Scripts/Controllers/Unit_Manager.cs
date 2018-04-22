using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Manager : MonoBehaviour {
	public static Unit_Manager instance {get; protected set;}
	public BaseCollider[] unitColliders;
	Dictionary<Unit, GameObject> unitGobjMap;
	SurroundingPos[] surrPostions;
	public GameObject playerGobj;
	private void Awake() {
		instance = this;
		surrPostions = new SurroundingPos[8];
		surrPostions[0] = new SurroundingPos(Vector2.up, Direction.N);
		surrPostions[1] = new SurroundingPos(Vector2.up + Vector2.right, Direction.NE);
		surrPostions[2] = new SurroundingPos(Vector2.right, Direction.E);
		surrPostions[3] = new SurroundingPos(Vector2.right + Vector2.down, Direction.SE);
		surrPostions[4] = new SurroundingPos(Vector2.down, Direction.S);
		surrPostions[5] = new SurroundingPos(Vector2.down + Vector2.left, Direction.SW);
		surrPostions[6] = new SurroundingPos(Vector2.left, Direction.W);
		surrPostions[7] = new SurroundingPos(Vector2.left + Vector2.up, Direction.NW);
	}
	private void Start() {
		SpawnUnit("Small Cursed", new Vector2(6, 0));
	}
	public void SpawnUnit(string unitName, Vector2 pos){
		// Get prototype.. ** for now just making a new one
		Unit unit = new Unit(unitName, Faction.Animals, 3);
		GameObject unitGObj = ObjectPool.instance.GetObjectForType("Unit", true, pos);
		if (unitGObj == null)
			return;
		Unit_Controller unit_Controller = unitGObj.GetComponent<Unit_Controller>();
		unit_Controller.Initialize(unit, GetState_Controller(unitName, unit_Controller), surrPostions);
		PolygonCollider2D collider2D = unitGObj.GetComponentInChildren<PolygonCollider2D>();
		if (collider2D != null){
			Vector2[] points = GetColliderPoints(unit.name);
			if (points != null)
				collider2D.SetPath(0, points);
		}
	}
	UnitState_Controller GetState_Controller(string unitName, Unit_Controller controller){
		UnitState_Controller state_Controller = null;
		switch(unitName){
			case "Sheep":
				state_Controller = new SheepStateController(controller);
				break;
			case "Small Cursed":
				state_Controller = new SmCursedStateCont(controller);
				break;
		}
		return state_Controller;
	}
	Vector2[] GetColliderPoints(string unitName){
		foreach(BaseCollider baseColl in unitColliders){
			if (baseColl.unitName == unitName){
				return baseColl.collider.points;
			}
		}
		return null;
	}
}

[System.Serializable]
public struct BaseCollider{
	public string unitName;
	public PolygonCollider2D collider;
}
