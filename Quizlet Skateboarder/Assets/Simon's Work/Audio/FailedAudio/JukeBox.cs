using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class JukeBox : MonoBehaviour
{
    public static List<Track> trackList = new List<Track>();
    private bool isPlayingTrack;

    static public void AddTracks (int Tracknumbers, GameObject gameObj)
    {
        if(Tracknumbers != 0)
        {
            for(int i = 0; i < Tracknumbers; i++)
            {
                Track track = new Track { id = 1, audioSource = gameObj.AddComponent<AudioSource>() };
                trackList.Add (track);
            }
        }
    }

    static public void TrackSettings(int track,float trackVolume,bool loop = false)
    {

        trackList[track].trackVolume = trackVolume;
        trackList[track].loop = loop;

    }

    static public void StartMusic (int track, AudioClip audioClip)
    {
        trackList[track].audioSource.PlayOneShot(audioClip, trackList[track].trackVolume);
    }
}
