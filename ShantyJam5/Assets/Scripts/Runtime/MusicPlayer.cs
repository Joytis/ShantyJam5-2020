using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MusicPlayer : ScriptableObject
{
    public class CurrentMusic
    {
        GameObject _prefab { get; set; }
        AudioClip _music { get; set; }
        float _fadeTime { get; set; }
        AnimationCurve _fadeCurve { get; set; }

        GameObject _current { get; set; }
        AudioSource _source { get; set; }
        DummyBinding _binding { get; set; }

        Coroutine _currentCoroutine = null;

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
            yield return _source.DOFade(1f, _fadeTime).SetEase(_fadeCurve).WaitForCompletion();
        }

        IEnumerator FadeAndDestroyRoutine()
        {
            yield return _source.DOFade(0f, _fadeTime).SetEase(_fadeCurve).WaitForCompletion();
            // Destroy()
        }
    }

    
    public void PlayMusic(AudioClip clip, float volume)
    {
        
    }
}
