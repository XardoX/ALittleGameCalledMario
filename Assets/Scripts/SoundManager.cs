using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioClip onFireBall,
        onJump,
        onLand;

    private AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
        source = GetComponent<AudioSource>();
    }

    public static void OnFireBall()
    {
        instance.Play(instance.onFireBall);
    }

    public static void OnJump() => instance.Play(instance.onJump, 0.75f);

    public static void OnLand() => instance.Play(instance.onLand, 1.25f);

    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void Play(AudioClip clip, float volume)
    {
        source.PlayOneShot(clip, volume);
    }
}
