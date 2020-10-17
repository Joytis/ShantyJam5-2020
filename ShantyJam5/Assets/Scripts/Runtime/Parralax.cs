using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    [SerializeField] GameObject _camera = null;
    [SerializeField] float _parralaxEffect = 0f;
    float _length;
    float _startpos;

    // Start is called before the first frame update
    void Start()
    {
        _startpos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float camPosition = _camera.transform.position.x;
        float temp = (camPosition * (1 - _parralaxEffect));
        float dist = (camPosition * _parralaxEffect);

        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);

        if(temp > _startpos + _length) _startpos += _length;
        else if(temp < _startpos - _length) _startpos -= _length;
    }
}
