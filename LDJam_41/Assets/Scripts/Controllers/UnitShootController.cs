using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShootController : MonoBehaviour {
 	public float fireRate = 0.25f;
    float coolDown = 0;
	 public void Shoot()
    {
        if (coolDown <= 0)
        {
            // Shoot
            GameObject projectile = ObjectPool.instance.GetObjectForType("Projectile", true, transform.position + (transform.rotation * new Vector3(0, 0.5f, 0)));
            if (projectile != null)
                projectile.transform.eulerAngles = this.transform.eulerAngles;

           // Camera_Controller.instance.Shake(0.0025f, 0.10f);

            coolDown = fireRate;
        }

        coolDown -= Time.deltaTime;
    }
	public void RotateWpnTo(Vector2 targetPos)
    {
        float z = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);
    }
}
