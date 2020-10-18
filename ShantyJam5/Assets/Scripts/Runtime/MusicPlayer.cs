using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MusicPlayer : ScriptableObject
{
    public class CurrentMusic
    {
        public GameObject prefab { get; set; }
        public AudioClip music { get; set; }
        public float fadeTime { get; set; }
        public AnimationCurve fadeCurve { get; set; }
        GameObject current { get; set; }
        AudioSource source { get; set; }
        DummyBinding binding { get; set; }

        Coroutine _currentCoroutine = null;

        void PlayThing(IEnumerator coroutine)
        {
            if(_currentCoroutine != null)
            {
                binding.StopCoroutine(_currentCoroutine);
            }

            IEnumerator Wrapper(IEnumerator operation)
            {
                _currentCoroutine = binding.StartCoroutine(operation);
                yield return _currentCoroutine;
                _currentCoroutine = null;
            }

            binding.StartCoroutine(Wrapper(coroutine));
        }

        public void FadeIn() => PlayThing(FadeInRoutine());
        public void FadeAndDestroy() => PlayThing(FadeAndDestroyRoutine());

        IEnumerator FadeInRoutine()
        {
            yield return source.DOFade(1f, fadeTime).SetEase(fadeCurve).WaitForCompletion();
        }

        IEnumerator FadeAndDestroyRoutine()
        {
            yield return source.DOFade(0f, fadeTime).SetEase(fadeCurve).WaitForCompletion();
            // Destroy()
        }
    }

    
    
    public void PlayMusic(AudioClip clip, float volume)
    {
        
    }
}
