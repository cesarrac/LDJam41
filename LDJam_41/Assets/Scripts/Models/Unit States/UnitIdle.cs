using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitIdle : State {

	Unit_Controller controller;
	float timeToWait = 3;
	CountdownHelper countdown;
	public UnitIdle(Unit_Controller _controller) : base (StateType.Idle){
		controller = _controller;
		countdown = new CountdownHelper(timeToWait);
	}
	public override void Enter(){
		countdown.Reset();
	}
    public override void Update(float deltaTime)
    {
		if (controller == null || countdown == null)
			return;

		countdown.UpdateCountdown();
		if(countdown.isDone){
			Finished();
		}
    }
	public override void Finished(){
		controller.state_Controller.ReplaceState(StateType.Wander);
	}
}