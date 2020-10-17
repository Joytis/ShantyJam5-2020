using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] _locations = null;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, _locations.Length);
        Transform randomTransform = _locations[randomIndex];
        Debug.Log(randomTransform.name);
        
    }
}
