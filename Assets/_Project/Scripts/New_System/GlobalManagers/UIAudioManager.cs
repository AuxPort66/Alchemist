using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager Instance;

    public AudioSource audioSource;
    public List<AudioClip> bottleUpClip;

    private float lastTimePlayed = 0f;
    private float cooldown = 0.05f;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayBottleUpClip()
    {
        if(Time.time - lastTimePlayed < cooldown)
        {
            return;
        }

        lastTimePlayed = Time.time;
        
        audioSource.pitch = Random.Range(0.97f, 1.03f);
        audioSource.volume = Random.Range(0.85f, 1f);
        audioSource.PlayOneShot(bottleUpClip[Random.Range(0,bottleUpClip.Count)]);
    }
}
