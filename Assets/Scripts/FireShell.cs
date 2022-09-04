using UnityEngine;

public class FireShell : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject enemy;
    private float rotSpeed = 2f;

    void Update()
    {
        Vector3 direction = (enemy.transform.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

}
