using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    Scrollbar Volumebar;
    private void FixedUpdate()
    {
        if (Volumebar == null)
        {
            Volumebar = GameObject.Find("VolumeBar").GetComponent<Scrollbar>();
        }
        
    }
    public void VolumeFix()
    {
        JukeBoxAudio.Volume = Volumebar.value;
    }
}
