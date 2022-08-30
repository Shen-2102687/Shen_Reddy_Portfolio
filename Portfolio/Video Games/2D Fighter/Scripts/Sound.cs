using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;


    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;    //making a custom adjustable volume

    [Range(0.1f, 3f)]
    public float pitch;    //making a custom adjustable pitch

    public bool loop;     //option to loop a sound

    [HideInInspector]
    public AudioSource source;

}
