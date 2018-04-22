using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AccelerateMode{ Idle, Accelerating }
public class CarMoveController : MonoBehaviour {

	Rigidbody2D rb;
	AccelerateMode accelerateMode = AccelerateMode.Idle;
	float accForce = -8f;
	float torqForce = -100f;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}
	private void Start() {
		CameraFollowController.instance.SetTarget(this.transform);
	}
	private void Update() {
		if (Input.GetButtonDown("Acceleration")){
			if(accelerateMode != AccelerateMode.Accelerating)
				accelerateMode = AccelerateMode.Accelerating;
		}
		if (Input.GetButtonUp("Acceleration")){
			accelerateMode = AccelerateMode.Idle;
		}
	}
	void FixedUpdate() {
		rb.velocity = ForwardVel() + RightVel() * 0.9f;

		if (accelerateMode == AccelerateMode.Accelerating){
			// Apply acceleration
			rb.AddForce(transform.up * accForce);
		}
		//rb.angularVelocity = Input.GetAxis("Horizontal") * torqForce;
		float tf = Mathf.Lerp(0, torqForce, rb.velocity.magnitude / 2);
		rb.angularVelocity = Input.GetAxis("Horizontal") * tf;
	}

	Vector2 ForwardVel(){
		return transform.up * Vector2.Dot(rb.velocity, transform.up);
	}
	Vector2 RightVel(){
		return transform.right * Vector2.Dot(rb.velocity, transform.right);
	}

}
