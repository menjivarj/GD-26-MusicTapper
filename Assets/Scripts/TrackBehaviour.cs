using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackBehaviour : MonoBehaviour
{

    public GameObject button;
    public GameObject slider;
    public GameObject release;
    public Queue<GameObject> trackObjects = new Queue<GameObject>();
    private RectTransform rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObject(string type)
    {
        trackObjects.Enqueue(Instantiate(button, new Vector2(transform.position.x, rectTransform.rect.height / 2), Quaternion.identity, transform));
    }

}
