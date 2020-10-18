using System;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public static event Action<Consumable> ThingConsumed;

    [SerializeField] float girthValue = 5;
    public float GrithValue => girthValue;

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Consumable Consumed :)");
            ThingConsumed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
