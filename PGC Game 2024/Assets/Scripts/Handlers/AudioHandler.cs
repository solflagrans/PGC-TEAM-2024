using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

    public static AudioHandler Instance;

    public AudioSource _moveStateSource;
    public AudioSource _jumpSource;
    public AudioSource _swordSource;
    public AudioSource _healthSource;
    public AudioSource _gameStateSource;
    public List<AudioSource> _puzzleSources;
    public List<AudioSource> _menuSources;

    public AudioClip _walkSound;
    public AudioClip _jumpSound;
    public AudioClip _swingSound;
    public AudioClip _hitSound;
    public AudioClip _deathSound;
    public AudioClip _winSound;
    public AudioClip _heavyButtonOn;
    public AudioClip _heavyButtonOff;
    public AudioClip _buttonPress;
    public AudioClip _menuPress;

    private void Awake() {

        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);

    }

    public void StopPlayerSounds() {

        _moveStateSource.Stop();
        _jumpSource.Stop();
        _swordSource.Stop();

    }

    public void MuteForMenu() {
        
        _moveStateSource.volume = 0;
        _jumpSource.volume = 0;
        _swordSource.volume = 0;
        _healthSource.volume = 0;
        _gameStateSource.volume = 0;

    }

    public void Mute() {

        _moveStateSource.volume = 0;
        _jumpSource.volume = 0;
        _swordSource.volume = 0;
        _healthSource.volume = 0;
        _gameStateSource.volume = 0;

        foreach(AudioSource source in _puzzleSources) {
            source.volume = 0;
        }

        foreach(AudioSource source in _menuSources) {
            source.volume = 0;
        }

    }

    public void Unmute() {

        _moveStateSource.volume = 1;
        _jumpSource.volume = 1;
        _swordSource.volume = 1;
        _healthSource.volume = 1;
        _gameStateSource.volume = 1;

        foreach(AudioSource source in _puzzleSources) {
            source.volume = 1;
        }

        foreach(AudioSource source in _menuSources) {
            source.volume = 1;
        }

    }

}
