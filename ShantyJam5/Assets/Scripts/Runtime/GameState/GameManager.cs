using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Static Variables
    public static GameManager instance;
    // // Event delegates
    // public delegate void GameOverEvent ();
    // public delegate void GameStartEvent ();    
    // public static GameOverEvent gameOverEvent;
    // public static GameStartEvent gameStartEvent;
    // NOTE(clark): Hey Ran! I noticed you were using some olden-days C# syntax for events. Try this out!:
    //              It's the same thing (Action is just a delegate that takes no arguments and returns no values. 
    //              Action<T> will accept generic arguments), but you have a more constrained API (you can only
    //              subscribe and ubsubscribe publically and invoke privately). I'd usually slap this in code review
    //              or something, but I'm probably just going to forget otherwise lol. 
    public event Action gameOverEvent;
    public event Action gameStartEvent;

    private void Awake()
    {
        // NOTE(clark): :'c
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
        // NOTE(clark): null game events will throw excepetions! Null-coalescing will check for that before calling. 
        gameOverEvent?.Invoke();
    }
    public void GameStart()
    {
        // NOTE(clark): null game events will throw excepetions! Null-coalescing will check for that before calling. 
        gameStartEvent?.Invoke();
    }
}
