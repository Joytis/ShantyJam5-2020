using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadSceneOnClick : MonoBehaviour {
    [SerializeField] SceneReference _scene = null;
    [SerializeField] SceneFaderAsset _fader = null;

    Button _button = null;
    void Awake() => _button = GetComponent<Button>();
    void OnEnable() => _button.onClick.AddListener(LoadScene);
    void OnDisable() => _button.onClick.RemoveListener(LoadScene);
    void LoadScene() => _fader.LoadScene(_scene);
}