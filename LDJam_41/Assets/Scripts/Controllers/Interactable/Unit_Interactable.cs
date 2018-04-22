using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Interactable : Interactable {

	Unit_Controller unit_Controller;
	private void OnEnable() {
		unit_Controller = GetComponentInParent<Unit_Controller>();
	}
	public override void Interact(){
		Debug.Log("Interacting with " + unit_Controller.unit.name);
		unit_Controller.OnPlayerInteract();
	}
	
}
