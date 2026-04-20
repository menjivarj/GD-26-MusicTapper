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
    public float noteDelay;

    public int score;
    public TMP_Text scoreText;
    public int streak;
    public TMP_Text streakText;
    public int mult;
    public TMP_Text multText;
    public TMP_Text hitOrMissText;

    public List<AudioClip> songAudios = new List<AudioClip>();
    public List<Song> songList;

    [System.Serializable]
    public class TrackNotes
    {
        public List<float> noteTimes = new List<float>();

        public TrackNotes(List<float> notetimes)
        {
            noteTimes = notetimes;
        }

    }

    [System.Serializable]
    public class Song {
        public List<TrackNotes> song = new List<TrackNotes>();
    }

    public int currentSongNum;
    public int[] trackNoteIndexes;
    public Song currentSong;

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
            ActivatorBehaviour activator = tracks[i].GetComponentInChildren<ActivatorBehaviour>();
            activator.key = keys[i];
            activator.songMaker = songMaker;
        }
        trackNoteIndexes = new int[trackNum];

        if (songMaker)
        {
            currentSong.song = new List<TrackNotes>();
        } else
        {
            currentSong = songList[currentSongNum];
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = songAudios[currentSongNum];
        audioSource.PlayDelayed(startDelay);
        startTime = Time.time;
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
                    currentSong.song.Add(new TrackNotes(tracks[i].GetComponentInChildren<ActivatorBehaviour>().noteTimes));
                }
            }
        }
        else
        {
            float timeThusFar = Time.time - startTime;
            for (int i = 0; i < currentSong.song.Count; i++)
            {
                if (currentSong.song[i].noteTimes.Count > trackNoteIndexes[i])
                {
                    if ((currentSong.song[i].noteTimes[trackNoteIndexes[i]] - noteDelay) < timeThusFar)
                    {
                        tracks[i].GetComponent<TrackBehaviour>().CreateNote();
                        trackNoteIndexes[i]++;
                    }
                }
            }
        }
    }
    
    public void Miss()
    {
        streak = 0;
        updateStreak();
        hitOrMissText.SetText("Miss!");
    }

    public void Hit(int points)
    {
        streak++;
        updateStreak();
        score += mult * points;
        scoreText.SetText(score.ToString());
        hitOrMissText.SetText("Hit!");
    }

    public void updateStreak()
    {
        streakText.SetText(streak.ToString());
        mult = Math.Clamp(1 + (streak / 10), 1, 6);
        multText.SetText("x" + mult.ToString());
    }

}
