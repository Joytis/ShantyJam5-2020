using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WaitForSomeTime : MonoBehaviour {
    [SerializeField] SceneReference _scene = null;
    [SerializeField] SceneFaderAsset _fader = null;

    IEnumerator Start() 
    {
        yield return new WaitForSeconds(2f);
        _fader.LoadScene(_scene);
    }
}