using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameManager : MonoBehaviour
{

    public GameObject track;
    public GameObject trackArea;
    public int trackNum;
    private GameObject[] tracks;
    public Key[] keys;

    private float startTime;

    public int score;
    public TMP_Text scoreText;
    public int streak;
    public TMP_Text streakText;
    public int mult;
    public TMP_Text multText;

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
            tracks[i].GetComponentInChildren<ActivatorBehaviour>().key = keys[i];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Miss()
    {
        streak = 0;
        updateStreak();
    }

    public void Hit(int points)
    {
        streak++;
        updateStreak();
        score += mult * points;
        scoreText.SetText(score.ToString());
    }

    public void updateStreak()
    {
        streakText.SetText(streak.ToString());
        mult = Math.Clamp(1 + (streak / 10), 1, 6);
        multText.SetText("x" + mult.ToString());
    }
}
