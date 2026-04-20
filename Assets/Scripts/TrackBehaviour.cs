using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackBehaviour : MonoBehaviour
{

    public GameObject note;
    public GameObject slider;
    public GameObject release;
    public Queue<GameObject> trackObjects = new Queue<GameObject>();
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObject(string type)
    {
        trackObjects.Enqueue(Instantiate(note, new Vector2(transform.position.x, rectTransform.rect.height / 2), Quaternion.identity, transform));
    }

    public void KeyHit()
    {
        float nextObjectPos = trackObjects.Peek().transform.position.y;
        if (nextObjectPos < 0)
        {
            if (true)
            {

            }
        }
    }


}
