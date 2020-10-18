using System;
using UnityEngine;
using Cinemachine;

public class Consumable : MonoBehaviour
{
    public static event Action<Consumable> ThingConsumed;

    [SerializeField] CinemachineImpulseSource _impulse = default;
    [SerializeField] GameObject _particlePrefab = default;
    [SerializeField] float girthValue = 5;
    [SerializeField] float requiredGirthToConsume = 0;
    public float GrithValue => girthValue;
    public float RequiredGirthToConsume => requiredGirthToConsume;

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            if (requiredGirthToConsume < coll.gameObject.GetComponent<BirdGirth>().currentHealth)
            {
                _impulse.GenerateImpulse();
                ThingConsumed?.Invoke(this);
                var newParticle = Instantiate(_particlePrefab, transform.position, transform.rotation);
                Destroy(newParticle, 3f);
                Destroy(gameObject);
            }
        }
    }
}
