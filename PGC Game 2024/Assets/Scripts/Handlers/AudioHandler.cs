using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

    public static AudioHandler Instance;

    [Header("Audio Sources")]
    public AudioSource moveStateSource;
    public AudioSource robotSource;
    public AudioSource jumpSource;
    public AudioSource swordSource;
    public AudioSource healthSource;
    public AudioSource gameStateSource;
    public List<AudioSource> puzzleSources;
    public List<AudioSource> menuSources;

    [Header("Audio Clips")]
    public AudioClip walkSound;
    public AudioClip helicopterSound;
    public AudioClip jumpSound;
    public AudioClip swingSound;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public AudioClip winSound;
    public AudioClip heavyButtonOn;
    public AudioClip heavyButtonOff;
    public AudioClip buttonPress;
    public AudioClip menuPress;
    public AudioClip doorOpening;

    private void Awake() {

        if(!Instance) Instance = this;

    }

    public void StopPlayerSounds() {

        moveStateSource.Stop();
        jumpSource.Stop();
        swordSource.Stop();

    }

    public void MuteForMenu() {
        
        moveStateSource.volume = 0;
        jumpSource.volume = 0;
        swordSource.volume = 0;
        healthSource.volume = 0;
        gameStateSource.volume = 0;

    }

    public void Mute() {

        moveStateSource.volume = 0;
        jumpSource.volume = 0;
        swordSource.volume = 0;
        healthSource.volume = 0;
        gameStateSource.volume = 0;

        foreach(AudioSource source in puzzleSources) {
            source.volume = 0;
        }

        foreach(AudioSource source in menuSources) {
            source.volume = 0;
        }

    }

    public void Unmute() {

        moveStateSource.volume = 1;
        jumpSource.volume = 1;
        swordSource.volume = 1;
        healthSource.volume = 1;
        gameStateSource.volume = 1;

        foreach(AudioSource source in puzzleSources) {
            source.volume = 1;
        }

        foreach(AudioSource source in menuSources) {
            source.volume = 1;
        }

    }

}
