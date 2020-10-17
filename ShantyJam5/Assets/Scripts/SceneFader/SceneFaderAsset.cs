using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Game/SceneFader")]
public class SceneFaderAsset : ScriptableObject
{
    const float _fadeTime = 1f;
    [SerializeField] GameObject _fader = null;

    static bool _currentlyLoadingScene = false;

    public void LoadScene(string name) {
        if(_currentlyLoadingScene) return;

        var newFader = Instantiate(_fader);
        var dummy = newFader.AddComponent<DummyBinding>();
        dummy.StartCoroutine(InternalFadeScene(newFader, name));
    }

    IEnumerator InternalFadeScene(GameObject fader, string scene) {
        _currentlyLoadingScene = true;
        DontDestroyOnLoad(fader);
        var sceneFader = fader.GetComponent<SceneFader>();
        yield return sceneFader.FadeSceneOut();
        yield return SceneManager.LoadSceneAsync(scene);
        yield return sceneFader.FadeSceneIn();
        Destroy(fader);
        _currentlyLoadingScene = false;
    }

}