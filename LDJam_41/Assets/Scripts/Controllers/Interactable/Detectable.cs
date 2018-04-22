using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(CircleCollider2D))]
public class Detectable : MonoBehaviour {

	Interactable interactable;
	private void OnEnable() {
		interactable = GetComponent<Interactable>();
	}
	private void OnTriggerEnter2D(Collider2D other) {
		interactable.Interact();
	}
}
