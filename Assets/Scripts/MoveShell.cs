using UnityEngine;

public class MoveShell : MonoBehaviour
{
    [SerializeField] public float speed = 1.0f;

    void Start()
    {

    }

    void LateUpdate()
    {
        this.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
