using UnityEngine;
using System.Collections;

public class ForwardMoveController : MonoBehaviour {

    public float maxSpeed = 5;

	void Update () {

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);


        transform.position += transform.rotation * velocity;
    }
}
