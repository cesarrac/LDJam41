using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFlee : State {
	Unit_Controller controller;
	
	float timeToWait = 2.5f;
	float minDist = 4, maxDist = 8;
	CountdownHelper countdown;
	public UnitFlee(Unit_Controller _controller) : base (StateType.OnInteract){
		controller = _controller;
		countdown = new CountdownHelper(timeToWait);
	}
	public override void Enter(){
		countdown.Reset();
		// Check for obstacles
		Vector2[] freePositions = controller.GetNoBlockedPos(Random.Range(minDist,maxDist));
		controller.SetDestination(freePositions[Random.Range(0, freePositions.Length)]);
	}

     public override void Update(float deltaTime)
    {
		if (controller == null || countdown == null)
			return;

        controller.Move();

		countdown.UpdateCountdown();
		if(countdown.isDone){
			Finished();
			return;
		}
		
		controller.FaceDestination();
    }
	public override void Finished(){
		controller.state_Controller.PopState();
	}
}
