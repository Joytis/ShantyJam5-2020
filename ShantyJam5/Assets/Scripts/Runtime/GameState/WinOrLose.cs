using System.Linq;
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

        bool gameWon = EnemyBehavior.CurrentEnemies.Count() == 0;
        if(_girth.gameState_Lose) 
        {
            _hasLoaded = true;
            _fader.LoadScene(_loseScene);
        }
        else if(gameWon)
        {
            _hasLoaded = true;
            _fader.LoadScene(_winScene);
        }
    }
}