using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    private float speed = 0f;
    private float ySpeed = 0f;
    private float mass = 1f;
    private float force = 4f;
    private float drag = 1f;
    private float gravity = -9.8f;
    private float gravityAcceleration;
    private float acceleration;

    void Start()
    {
        acceleration = force / mass;
        speed += acceleration * 1f;
        gravityAcceleration = gravity / mass;
    }

    void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * drag);
        ySpeed += gravityAcceleration * Time.deltaTime;
        this.transform.Translate(0, Time.deltaTime * ySpeed, Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "tank") return;
        if (col.gameObject.tag != "ground") return;

        GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(exp, 0.5f);
        Destroy(this.gameObject);
    }

}
