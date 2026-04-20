using UnityEngine;

public class MissBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note"))
        {
            print("Missed Note");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Miss();
            Destroy(collision.gameObject);
        }
    }
}
