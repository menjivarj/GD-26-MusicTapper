using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackBehaviour : MonoBehaviour
{

    public GameObject note;
    private GameObject createdNote;
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

    public void CreateNote()
    {
        createdNote = Instantiate(note, new Vector2(transform.position.x, rectTransform.rect.height / 2), Quaternion.identity);
        createdNote.transform.SetParent(transform, false);
    }

}
