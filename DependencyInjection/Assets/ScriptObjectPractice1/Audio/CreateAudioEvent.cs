using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class CreateAudioEvent : AudioEvent {

    public AudioClip[] clips;
    [Range(0, 10)]
    public float volume;
    [Range(0, 2)]
    public float pitch;

    public override void Play(AudioSource source) {
        if (clips.Length == 0)
            return;

        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}
