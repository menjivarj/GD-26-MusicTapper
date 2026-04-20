using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActivatorBehaviour : MonoBehaviour
{

    public Key key;
    public bool active;

    public bool songMaker;
    public GameObject noteObject;
    private float musicStart;
    private Queue<float> noteTimes;

    private GameObject note;
    private Color colour;
    private Image image;
    private GameManager gameManager;

    private void Awake()
    {
        image = GetComponent<Image>();
        colour = image.color;
        GetComponent<Collider2D>().enabled = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        active = false;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        musicStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (songMaker)
        {
            if (Keyboard.current[key].wasPressedThisFrame)
            {
                Instantiate(noteObject, transform.position, Quaternion.identity);
                noteTimes.Enqueue(Time.time - musicStart);
            }
        }
        else
        {
            image.color = colour;
            if (Keyboard.current[key].wasPressedThisFrame)
            {
                print("Key Pressed");
                image.color = Color.white;
                if (active)
                {
                    print("Hit");
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Hit(10);
                    Destroy(note);
                    active = false;
                }
                else
                {
                    print("Miss");
                    gameManager.Miss();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        print("Active");

        if (collision.gameObject.CompareTag("Note"))
        {
            print("Found Note");
            //GetComponentInParent<TrackBehaviour>().KeyHit();
            note = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("Inactive");
        active = false;
    }

}
