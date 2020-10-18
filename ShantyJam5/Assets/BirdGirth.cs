using UnityEngine;

public class BirdGirth : MonoBehaviour
{
    
    public int currentHealth = 25;
    public bool gameState_Lose = false;
    public bool gameState_win = false;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetHealth(currentHealth);
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void AddGirth(int gain)
    {
        currentHealth += gain;
        healthBar.SetHealth(currentHealth);
        if (currentHealth >= 100)
        {
            gameState_win = true;
        }
        if (currentHealth <= 0)
        {
            gameState_Lose = true;
        }
    }
}