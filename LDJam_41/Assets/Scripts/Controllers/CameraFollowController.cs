using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour {

	public static CameraFollowController instance {get; protected set;}
	Transform target;
	float camZ;
	private void Awake() {
		instance = this;
	}
	private void Start() {
		camZ = Camera.main.transform.position.z;
	}
	public void SetTarget(Transform newTarget){
		target = newTarget;
	}
	private void Update() {
		if (target == null)
			return;
		
		transform.position = new Vector3(target.position.x, target.position.y + Camera.main.orthographicSize / 2, camZ);
	}

}
