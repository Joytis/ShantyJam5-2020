using System;
using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("Girth Value is now: " + GrithValue);

            ThingConsumed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
