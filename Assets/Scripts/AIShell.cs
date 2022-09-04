using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShell : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
