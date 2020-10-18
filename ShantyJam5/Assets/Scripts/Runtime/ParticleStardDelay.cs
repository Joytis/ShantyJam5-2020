using UnityEngine;

public class ParticleStardDelay : MonoBehaviour
{
    [SerializeField] ParticleSystem[] _particles = null;
    [SerializeField] float _minDelay = 10f;
    [SerializeField] float _maxDelay = 20f;

    void OnEnable()
    {
        var randomThing = Random.Range(_minDelay, _maxDelay);
        foreach(var particles in _particles)
        {
            var mainModule = particles.main;
            mainModule.startDelay = randomThing;
            particles.Play();
        }

    }
}