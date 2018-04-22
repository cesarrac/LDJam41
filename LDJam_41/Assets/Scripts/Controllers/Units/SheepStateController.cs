using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepStateController : UnitState_Controller {

	public SheepStateController(Unit_Controller controller) : base(controller) {
		State[] sheepStates = new State[3];
		sheepStates[0] = new UnitIdle(controller);
		sheepStates[1] = new UnitWander(controller);
		sheepStates[2] = new UnitFlee(controller);
		base.SetStates(sheepStates);
	}
}
