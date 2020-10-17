using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ImageMaterialBinding : MonoBehaviour
{
    Material _material = null;
    Image _image = null;

    public Material Material => _material;

    void Awake() 
    {
        _image = GetComponent<Image>();
        _material = new Material(_image.material);
        _image.material = _material;
    }

    void OnDestroy()
    {
        Destroy(_material);
    }
}
