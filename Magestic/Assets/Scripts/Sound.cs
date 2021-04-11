using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public AudioClip clip;

    public string name;

    [Range(0f,1f)]
    public float volume;
    [Range(.5f, 1f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
