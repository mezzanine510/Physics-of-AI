using UnityEngine;

public class FireShell : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform turretBase;
    private float speed = 15f;
    private float rotSpeed = 2f;

    void Update()
    {
        Vector3 direction = (enemy.transform.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * rotSpeed);

        RotateTurret();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
        }
    }

    void RotateTurret()
    {
        float? angle = CalculateAngle(true);
        if (angle != null)
        {
            turretBase.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }
    }

    void CreateBullet()
    {
        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

    float? CalculateAngle(bool low)
    {
        Vector3 targetDir = enemy.transform.position - this.transform.position;
        float y = targetDir.y;
        targetDir.y = 0;
        float x = targetDir.magnitude;
        float gravity = 9.8f;
        float speedSqr = speed * speed;
        float underTheSqrRoot = (speedSqr * speedSqr) - gravity * (gravity * x * x + 2 * y * speedSqr);

        if (underTheSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = speedSqr + root;
            float lowAngle = speedSqr - root;
            
            if(low) return (Mathf.Atan2(lowAngle,gravity * x) * Mathf.Rad2Deg);
            else return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
        }
        else return null;
    }
}
