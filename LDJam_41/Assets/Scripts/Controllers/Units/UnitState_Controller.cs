using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitState_Controller  {

	public State[] unitStates {get; protected set;}
	public StackFSM stateMachine {get; protected set;}
	public State currentState {get; protected set;}

	public UnitState_Controller(Unit_Controller controller){
		stateMachine = new StackFSM();
	}
	public virtual void SetStates(){
		// Child class will initialize its unique states and 
		// call base SetStates with State[] param
	}
	public void SetStates(State[] states){
		unitStates = states;
	}
	public void SetCurrentState(){
		currentState = stateMachine.GetCurrentState();
	}
	public virtual void PushState(StateType stateType){
		if (unitStates == null)
			return;

		foreach(State state in unitStates){
			if (state.stateType == stateType){
				stateMachine.Push(state);
				break;
			}
		}
	}
	public virtual void ReplaceState(StateType stateType){
		if (unitStates == null)
			return;

		foreach(State state in unitStates){
			if (state.stateType == stateType){
				stateMachine.Replace(state);
				break;
			}
		}
	}
	public virtual void PopState(){
		stateMachine.Pop();
		if (stateMachine.GetCurrentState() == null)
			PushState(StateType.Idle);
	}
}
