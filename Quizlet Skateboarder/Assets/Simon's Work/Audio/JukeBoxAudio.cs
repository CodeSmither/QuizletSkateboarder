using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class JukeBoxAudio : MonoBehaviour
{
    [SerializeField]AudioSource Jukebox;
    [SerializeField] AudioClip[] Audioclips;
    [SerializeField] private static float Volume = 0.5f;


    private void Start()
    {

    }

    public void SwapTrack()
    {
            int RandomNumber = Random.Range(0, Audioclips.Length);
            AudioClip Thisclip = Audioclips[RandomNumber];
            Jukebox.clip = Thisclip;
            Jukebox.Play();
            NowPlaying();
    }

    public void FixedUpdate()
    {
        if (Jukebox.isPlaying == false)
        {
            SwapTrack();
        }
        Jukebox.volume = Volume;
    }
    private void NowPlaying()
    {

    }
}
