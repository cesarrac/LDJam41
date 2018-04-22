using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Controller : MonoBehaviour {

	public Vector2 destination {get; protected set;}
	float speed;
	public Unit unit {get; protected set;}
	public UnitState_Controller state_Controller {get; protected set;}
	public LayerMask obstacleMask;
	public Transform unitEye;
	SurroundingPos[] surrPostions;
	public Vector2 homePos {get; protected set;}
	UnitShootController shootController;
	private void Awake() {
		shootController = GetComponentInChildren<UnitShootController>();
	}
	public void Initialize(Unit _unit, UnitState_Controller _stateCont, SurroundingPos[] _surrPos){
		unit = _unit;
		if (_stateCont == null){
			Debug.LogError("No state control found for " + unit.name);
			return;
		}
		state_Controller = _stateCont;
		surrPostions = _surrPos;
		homePos = transform.position;
		speed = unit.speed;
		
		state_Controller.PushState(StateType.Idle);
		Debug.Log(unit.name + " ready!");
	}
	private void Update()
	{
		state_Controller.SetCurrentState();
		if (state_Controller.currentState != null){
			state_Controller.currentState.Update(Time.deltaTime);
		} 
	}

	///////// 				UNIT ACTIONS
	public void SetDestination(Vector2 vector){
		destination = vector;
	}
	public void Move(){
		if (destination == Vector2.zero || destination == (Vector2)transform.position)
			return;
		
		transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
	}
	public void FaceDestination(){
		if (destination == Vector2.zero || destination == (Vector2)transform.position)
			return;
		float z = Mathf.Atan2(destination.y - transform.position.y, destination.x - transform.position.x) * Mathf.Rad2Deg + 90;
		transform.eulerAngles = new Vector3(0, 0, z);
	}
	public Vector2[] GetNoBlockedPos(float distance = 1){
		Vector2 curPos = transform.position;
		bool[] blocked = new bool[surrPostions.Length];
		List<Vector2> notBlocked = new List<Vector2>();
		for (int i = 0; i < surrPostions.Length; i++)
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, surrPostions[i].dirVector, distance, obstacleMask);
			if (hit.collider != null){
				blocked[i] = true;
			}
		}
		for (int i = 0; i < blocked.Length; i++)
		{
			if (blocked[i] == false){
				notBlocked.Add((Vector2)transform.position + (surrPostions[i].dirVector * distance));
			}	
		}
		
		return notBlocked.ToArray();
	}
	public void OnPlayerInteract(){
		state_Controller.PushState(StateType.OnInteract);
	}
	public void AimWpn(Vector2 targetPos){
		shootController.RotateWpnTo(targetPos);
	}
	public void Shoot(){
		shootController.Shoot();
	}
	private void OnDisable() {
		this.unit = null;
	}
}
public enum Direction {N, NE, E, SE, S, SW, W, NW}
public struct SurroundingPos{
	public Vector2 dirVector;
	public Direction direction;
	public SurroundingPos (Vector2 vector, Direction _dir){
		dirVector = vector;
		direction = _dir;
	}
}

