using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    [SerializeField] BirdGirth _girth = null;
    [SerializeField] SceneReference _winScene = null;
    [SerializeField] SceneReference _loseScene = null;
    [SerializeField] SceneFaderAsset _fader = null;

    bool _hasLoaded = false;

    void Update()
    {
        if(_hasLoaded) return;

        if(_girth.gameState_Lose) 
        {
            _hasLoaded = true;
            _fader.LoadScene(_loseScene);
        }
        else if(_girth.gameState_win)
        {
            _hasLoaded = true;
            _fader.LoadScene(_winScene);
        }
    }
}