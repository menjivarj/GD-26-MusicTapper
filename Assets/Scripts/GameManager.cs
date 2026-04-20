using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public GameObject track;
    public GameObject trackArea;
    public int trackNum;
    private GameObject[] tracks;
    public Key[] keys;
    public bool songMaker;

    private float startTime;
    public float startDelay;

    public int[] trackNote;

    public int score;
    public TMP_Text scoreText;
    public int streak;
    public TMP_Text streakText;
    public int mult;
    public TMP_Text multText;

    [System.Serializable]
    public class TrackNotes
    {
        public List<float> noteTimes = new List<float>();

        public TrackNotes(List<float> notetimes)
        {
            noteTimes = notetimes;
        }

    }

    public List<TrackNotes> song;

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
        trackNote = new int[trackNum];

        if (songMaker)
        {
            song = new List<TrackNotes>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (songMaker)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                print("Creating Song");
                for (int i = 0; i < trackNum; i++)
                {
                    song.Add(new TrackNotes(tracks[i].GetComponentInChildren<ActivatorBehaviour>().noteTimes));
                }
            }
        }
        else
        {
            float timeThusFar = Time.time - startTime;
            for (int i = 0; i < song.Count; i++)
            {
                if (song[i].noteTimes.Count > trackNote[i])
                {
                    if (song[i].noteTimes[trackNote[i]] < timeThusFar)
                    {
                        tracks[i].GetComponent<TrackBehaviour>().CreateNote();
                        trackNote[i]++;
                    }
                }
            }
        }
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
