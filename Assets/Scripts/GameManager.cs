using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject track;
    public GameObject trackArea;
    public int trackNum;
    private GameObject[] tracks;

    private float startTime;

    public int points;
    public int streak;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RectTransform trackAreaRect = trackArea.GetComponent<RectTransform>();
        RectTransform trackRect = track.GetComponent<RectTransform>();
        trackAreaRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, trackRect.rect.width * trackNum);
        tracks = new GameObject[trackNum];
        for (int i = 0; i < trackNum; i++) {
            tracks[i] = Instantiate(track, new Vector2((trackRect.rect.width * (i + 0.5f)) - (trackAreaRect.rect.width / 2), 0.0f), Quaternion.identity);
            tracks[i].transform.SetParent(trackArea.transform, false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Strike()
    {

    }

    public void Miss()
    {

    }

    public void Hit()
    {

    }

}
