using UnityEngine;

public class BirdGirth : MonoBehaviour
{
    
    public int currentHealth = 25;
    public bool gameState_Lose = false, gameState_win = false;    
    public HealthBar healthBar;    
    public float girthAddSize = 2, scale;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetHealth(currentHealth);
        Consumable.ThingConsumed += ConsumableConsumed;
    }

    void ConsumableConsumed(Consumable c) 
    {
        this.scale *= girthAddSize;
        this.transform.localScale = new Vector3(this.scale, this.scale, this.scale);
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