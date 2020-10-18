using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayMusicOnStart : MonoBehaviour
{
    [SerializeField] AudioClip _music = default;
    [SerializeField] MusicPlayer _player = default;
    [SerializeField] float _volume = default;

    void Start() => _player.PlayMusic(_music, _volume);
}
