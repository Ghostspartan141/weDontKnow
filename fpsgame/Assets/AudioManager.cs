using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private int _sfxSourceLength;

    private AudioSource _bgm;
    private AudioSource[] _sfxSources;
    private int _curSFXIndex = 0;
    
    private void Awake()
    {
        if(AudioManager.instance == null)
        {
            AudioManager.instance = this;
        }
        else if(AudioManager.instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _bgm = gameObject.AddComponent<AudioSource>();
        _sfxSources = new AudioSource[_sfxSourceLength];

        for (int i = 0; i < _sfxSourceLength; i++)
        {
            _sfxSources[i] = gameObject.AddComponent<AudioSource>();
            _sfxSources[i].spatialBlend = 0;
        }
    }

    public void PlaySFX(AudioClip clipToPlay)
    {
        _sfxSources[_curSFXIndex].clip = clipToPlay;
        _sfxSources[_curSFXIndex].Play();

        _curSFXIndex++;
        if(_curSFXIndex > _sfxSourceLength-1)
        {
            _curSFXIndex = 0;
        }
    }

    public void PlaySFX(AudioClip clipToPlay, Transform origin, float spacialBlend)
    {
        AudioSource temp = origin.gameObject.AddComponent<AudioSource>();
        temp.clip = clipToPlay;
        temp.spatialBlend = spacialBlend;
        temp.Play();
        StartCoroutine(DestroySourceAfterDuration(temp, clipToPlay.length));
    }

    private IEnumerator DestroySourceAfterDuration(AudioSource sourceToDestroy, float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(sourceToDestroy);
    }

    public void PlayBGM(AudioClip musicToPlay, float fadeDuration)
    {
        StartCoroutine(PlayBGMCo(musicToPlay, fadeDuration));
    }

    private IEnumerator PlayBGMCo(AudioClip musicToPlay, float fadeDuration)
    {
        float t = 0;

        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.clip = musicToPlay;

        while(t < fadeDuration)
        {
            t += Time.deltaTime;
            _bgm.volume = Mathf.Lerp(1, 0, t / fadeDuration);
            newSource.volume = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }
        Destroy(_bgm);
        _bgm = newSource;
    }
}
