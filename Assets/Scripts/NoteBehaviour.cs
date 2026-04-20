using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public float speedMult;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocityY = -speed * speedMult;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
