using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolume : MonoBehaviour
{
    public void AdjustVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
    }
}
