using System;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public static event Action<Consumable> ThingConsumed;
    public bool consumed;

    [SerializeField] float girthValue = 5;
    public float GrithValue => girthValue;

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Consumable Consumed :)");
            wormConsumed();
            ThingConsumed?.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void wormConsumed()
    {
        consumed = true;
    }
}
