using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [SerializeField] Transform[] _locations = null;

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
    private SpawnState state = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, _locations.Length);
        Transform randomTransform = _locations[randomIndex];
        Debug.Log(randomTransform.name);

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
                Debug.Log("Wave completed!");
                return;
            } else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //START SPAWMING WAVE
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    bool wormIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Consumable").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave");
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
        Instantiate(_worm, transform.position, transform.rotation);
        Debug.Log("Spawning an enemy!!");
    }
}