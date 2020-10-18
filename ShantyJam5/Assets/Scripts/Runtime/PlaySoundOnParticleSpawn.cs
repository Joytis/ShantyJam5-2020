using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnParticleSpawn : MonoBehaviour
{
    [SerializeField] ParticleSystem _particles;
    [SerializeField] AudioSource _particleSpawnSound;
    int _numberOfParticles = 0;
    
    void Update()
    { 
        var count = _particles.particleCount;
        if (count > _numberOfParticles)
        { 
            _particleSpawnSound.Play(); 
        }
        _numberOfParticles = count; 
    }
}

