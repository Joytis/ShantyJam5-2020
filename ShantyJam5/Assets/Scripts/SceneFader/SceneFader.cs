using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/SceneFader")]
public class SceneFader : ScriptableObject
{
    public IEnumerator FadeSceneOut()
    {
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator FadeSceneIn()
    {
        yield return new WaitForSeconds(1f);
    }
}