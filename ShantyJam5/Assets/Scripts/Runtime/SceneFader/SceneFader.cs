using System.Collections;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    [SerializeField] ImageMaterialFloatDriver _fadeDriver = null;
    [SerializeField] ImageMaterialFloatDriver _flipDriver = null;
    [SerializeField] float _fadeTime = 0.5f;

    public IEnumerator FadeSceneOut()
    {
        _flipDriver.SetFloat(1f);
        yield return _fadeDriver.SetFloatAsync(1f, _fadeTime); 
    }

    public IEnumerator FadeSceneIn()
    {
        _flipDriver.SetFloat(0f);
        yield return _fadeDriver.SetFloatAsync(0f, _fadeTime); 
    }
}