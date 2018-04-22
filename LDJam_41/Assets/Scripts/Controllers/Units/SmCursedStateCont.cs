using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmCursedStateCont : UnitState_Controller
{
    public SmCursedStateCont(Unit_Controller controller) : base(controller)
    {
		State[] states = new State[3];
		states[0] = new UnitIdle(controller);
		states[1] = new UnitWander(controller);
		states[2] = new UnitShootAndFlee(controller);
		base.SetStates(states);
    }
}
