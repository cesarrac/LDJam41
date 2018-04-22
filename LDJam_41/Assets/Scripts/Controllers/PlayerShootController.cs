using UnityEngine;
using System.Collections;

public class PlayerShootController : MonoBehaviour {

    Vector3 mousePosition;

    public float fireRate = 0.25f;
    float coolDown = 0;

    void Update()
    {
        UpdateMousePos();

        RotateToMouse();

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
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

    void UpdateMousePos()
    {
        Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m.z = 0;
        mousePosition = m;
    }

    void RotateToMouse()
    {
        float z = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);
    }
}
