using UnityEngine;
using DG.Tweening;
using System.Collections;

[CreateAssetMenu(menuName = "Game/MusicPlayer", fileName = "MusicPlayer")]
public class MusicPlayer : ScriptableObject
{
    public class CurrentMusic
    {
        readonly GameObject _prefab = default;
        readonly AudioClip _music = default;
        readonly float _fadeTime = default;
        readonly float _volume = default;
        readonly AnimationCurve _fadeCurve = default;

        GameObject _current  = default;
        AudioSource _source  = default;
        DummyBinding _binding  = default;

        Coroutine _currentCoroutine = null;

        public AudioClip Music => _music;

        public CurrentMusic(GameObject prefab, AudioClip music, float fadeTime, float volume, AnimationCurve fadeCurve)
        {
            _prefab = prefab;
            _music = music;
            _fadeTime = fadeTime;
            _volume = volume;
            _fadeCurve = fadeCurve;

            _current = GameObject.Instantiate(prefab);
            
            // Configure audio source. 
            _source = _current.GetComponent<AudioSource>();
            _source.clip = music;
            _source.volume = volume;

            _binding = _current.AddComponent<DummyBinding>();
            _source.Play();
            DontDestroyOnLoad(_current);
        }

        void PlayThing(IEnumerator coroutine)
        {
            if(_currentCoroutine != null)
            {
                _binding.StopCoroutine(_currentCoroutine);
            }

            IEnumerator Wrapper(IEnumerator operation)
            {
                _currentCoroutine = _binding.StartCoroutine(operation);
                yield return _currentCoroutine;
                _currentCoroutine = null;
            }

            _binding.StartCoroutine(Wrapper(coroutine));
        }

        public void FadeIn() => PlayThing(FadeInRoutine());
        public void FadeAndDestroy() => PlayThing(FadeAndDestroyRoutine());

        IEnumerator FadeInRoutine()
        {
            _source.volume = 0;
            yield return _source.DOFade(_volume, _fadeTime).SetEase(_fadeCurve).WaitForCompletion();
        }

        IEnumerator FadeAndDestroyRoutine()
        {
            yield return _source.DOFade(0f, _fadeTime).SetEase(_fadeCurve).WaitForCompletion();
            GameObject.Destroy(_current);
        }
    }

    [SerializeField] GameObject _prefab = default;
    [SerializeField] float _fadeTime = default;
    [SerializeField] AnimationCurve _curve = default;

    CurrentMusic _music = null;

    void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
    
    public void PlayMusic(AudioClip music, float volume)
    {
        if(_music?.Music == music) return;
        if(_music != null) _music.FadeAndDestroy();

        _music = new CurrentMusic(_prefab, music, _fadeTime, volume, _curve);
        _music.FadeIn();
    }
}
