using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShootAndFlee : State {

	Unit_Controller controller;
	float timeToWait = 2.5f;
	float minDist = 1, maxDist = 4;
	CountdownHelper cd_toMove, cd_toEnd;
	bool rdyToMove = false;
	public UnitShootAndFlee(Unit_Controller _controller) : base (StateType.OnInteract){
		controller = _controller;
		cd_toMove = new CountdownHelper(timeToWait, true);
		cd_toEnd = new CountdownHelper(timeToWait * 2);
	}
	public override void Enter(){
		cd_toMove.Reset();
		cd_toEnd.Reset();
		rdyToMove = false;
		// Check for obstacles
		Vector2[] freePositions = controller.GetNoBlockedPos(Random.Range(minDist,maxDist));
		controller.SetDestination(freePositions[Random.Range(0, freePositions.Length)]);
	}
    public override void Update(float deltaTime)
    {
		if (controller == null)
			return;

		cd_toMove.UpdateCountdown();
		if (cd_toMove.isDone == true)
			rdyToMove = true;

		cd_toEnd.UpdateCountdown();
		if(cd_toEnd.isDone){
			Finished();
			return;
		}
		if (rdyToMove== true){
			controller.Move();
			controller.FaceDestination();
		}else{
			controller.AimWpn(Unit_Manager.instance.playerGobj.transform.position);
			controller.Shoot();
		}	
        
    }
	public override void Finished(){
		controller.state_Controller.PopState();
	}
}
