using UnityEngine;

public class BirdGirth : MonoBehaviour
{
    public int currentHealth = 25;

    public HealthBar healthBar;
    public Consumable wormAte;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     TakeDamage(5);
        // }
        // if (Input.GetKeyDown(KeyCode.Backspace))
        // {
        //     AddGirth(5);
        // }
    }

    void OnEnable() 
    {
        Consumable.ThingConsumed += OnThingConsumed;
    }
    void OnDisable() 
    {
        Consumable.ThingConsumed -= OnThingConsumed;
    }

    void OnThingConsumed(Consumable consumable)
    {
        AddGirth(Mathf.RoundToInt(consumable.GrithValue));
    }    

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void AddGirth(int gain)
    {
        currentHealth += gain;
        healthBar.SetHealth(currentHealth);
    }
}
