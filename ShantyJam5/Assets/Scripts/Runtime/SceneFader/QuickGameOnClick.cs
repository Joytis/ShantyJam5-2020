using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuickGameOnClick : MonoBehaviour {
    Button _button = null;
    void Awake() => _button = GetComponent<Button>();
    void OnEnable() => _button.onClick.AddListener(Quit);
    void OnDisable() => _button.onClick.RemoveListener(Quit);

#if UNITY_EDITOR
    void Quit() => UnityEditor.EditorApplication.isPlaying = false;
#else
    void Quit() => Application.Quit();
#endif
}