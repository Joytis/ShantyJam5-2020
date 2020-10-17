using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public float girthValue = 5;
    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Consumable Consumed :)");
            Girthodometer.instance.AddGirth(girthValue);
            Destroy(gameObject);
        }
    }
}
