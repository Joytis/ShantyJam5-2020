using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    //public Transform[] _locations = null;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform worm;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0f;
    private float searchCountdown = 1f;
    public Transform[] _locations = null;
    private SpawnState state = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        // int randomIndex = Random.Range(0, _locations.Length);
        //Transform randomTransform = _locations[randomIndex];
        //Debug.Log(randomTransform.name);

        waveCountdown = timeBetweenWaves;

    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //CHECK IF WORMS ARE ALIVE
            if (!wormIsAlive())
            {
                //BEGIN NEW WAVE
                waveCompleted();
            } else
            {
                return;
            }
        }

        if (waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                //START SPAWMING WAVE
                StartCoroutine(SpawnWave(waves[nextWave]));
                searchCountdown = timeBetweenWaves;
            }
        } else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void waveCompleted()
    {
        Debug.Log("Wave completed!");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves completed. Looping waves...");
        }
        else
        {
            nextWave++;
        }
    }

    bool wormIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Consumable") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.SPAWNING;
        //Spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnWorm(_wave.worm);
            yield return new WaitForSeconds(1 / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnWorm(Transform _worm)
    {
        //Spawn an enemy
        if (_locations.Length == 0)
        {
            Debug.Log("ERROR, NO SPAWN POINTS");
        }
        Transform _sp = _locations[Random.Range(0, _locations.Length)];
        Instantiate(_worm, _sp.position, _sp.rotation);
        Debug.Log("Spawning a worm!!");
    }
}