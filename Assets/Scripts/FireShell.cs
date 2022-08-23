using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShell : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject enemy;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 aimAt = CalculateTrajectory();
            if (aimAt != Vector3.zero)
            {
                this.transform.forward = aimAt;
            }

            CreateBullet();
        }
    }

    private Vector3 CalculateTrajectory()
    {
        Vector3 position = enemy.transform.position - this.transform.position;
        Vector3 velocity = enemy.transform.forward * enemy.GetComponent<Drive>().speed;
        float bulletSpeed = bullet.GetComponent<MoveShell>().speed;

        float a = Vector3.Dot(velocity, velocity) - (bulletSpeed * bulletSpeed);
        float b = Vector3.Dot(position, velocity);
        float c = Vector3.Dot(position, position);
        float d = (b * b) - (a * c);

        if (d < 0.1f) return Vector3.zero;

        float sqrt = Mathf.Sqrt(d);
        float t1 = (-b - sqrt) / c;
        float t2 = (-b + sqrt) / c;

        float t = 0;

        if (t1 < 0 && t2 < 0) return Vector3.zero;
        else if (t1 < 0) t = t2;
        else if (t2 < 0) t = t1;
        else
        {
            t = Mathf.Max(new float[] { t1, t2 });
        }

        return t * position + velocity;
    }

    void CreateBullet()
    {
        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

}
