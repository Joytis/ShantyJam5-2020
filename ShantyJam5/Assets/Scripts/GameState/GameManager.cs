using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    
    // Event delegates
    public delegate void GameOverEvent ();
    
    public delegate void GameStartEvent ();    

    // Static Variables
    public static GameManager instance;
    public static GameOverEvent gameOverEvent;
    public static GameStartEvent gameStartEvent;
    private void Awake()
    {
        /* Sry Clark I had to do it to em        
                         ⣠⣦⣤⣀
                    ⠀⠀⠀⠀⢡⣤⣿⣿
                    ⠀⠀⠀⠀⠠⠜⢾⡟
                    ⠀⠀⠀⠀⠀⠹⠿⠃⠄
                    ⠀⠀⠈⠀⠉⠉⠑⠀⠀⠠⢈⣆
                    ⠀⠀⣄⠀⠀⠀⠀⠀⢶⣷⠃⢵
                    ⠐⠰⣷⠀⠀⠀⠀⢀⢟⣽⣆⠀⢃
                    ⠰⣾⣶⣤⡼⢳⣦⣤⣴⣾⣿⣿⠞
                    ⠀⠈⠉⠉⠛⠛⠉⠉⠉⠙⠁
                    ⠀⠀⡐⠘⣿⣿⣯⠿⠛⣿⡄
                    ⠀⠀⠁⢀⣄⣄⣠⡥⠔⣻⡇
                    ⠀⠀⠀⠘⣛⣿⣟⣖⢭⣿⡇
                    ⠀⠀⢀⣿⣿⣿⣿⣷⣿⣽⡇
                    ⠀⠀⢸⣿⣿⣿⡇⣿⣿⣿⣇
                    ⠀⠀⠀⢹⣿⣿⡀⠸⣿⣿⡏
                    ⠀⠀⠀⢸⣿⣿⠇⠀⣿⣿⣿
                    ⠀⠀⠀⠈⣿⣿⠀⠀⢸⣿⡿
                    ⠀⠀⠀⠀⣿⣿⠀⠀⢀⣿⡇
                    ⠀⣠⣴⣿⡿⠟⠀⠀⢸⣿⣷
                    ⠀⠉⠉⠁⠀⠀⠀⠀⢸⣿⣿⠁
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈
        */
        if (instance == null)  
            instance = this;
        else if (instance != this)
        {
            Destroy(instance);
            instance = this;
        }        
    }
    
    // Event Envokers
    public void GameOver()
    {
        gameOverEvent ();
    }
    public void GameStart()
    {
        gameStartEvent ();
    }
}
