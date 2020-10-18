using UnityEngine;

public class BirdGirth : MonoBehaviour
{
    
    public int minGirth = 5;
    public int maxGirth = 100;
    public int currentHealth = 25;
    public bool gameState_Lose = false, gameState_win = false;    
    public HealthBar healthBar;    
    public float girthAddSize = 2;
    public float scale = 1;

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

    void ChangeHealth(int change) => currentHealth = Mathf.Clamp(currentHealth + change, minGirth, maxGirth);
    void TakeDamage(int damage)
    {
        ChangeHealth(-damage);
        healthBar.SetHealth(currentHealth);
    }

    void AddGirth(int gain)
    {
        ChangeHealth(gain);
        healthBar.SetHealth(currentHealth);
        if (currentHealth >= maxGirth)
        {
            gameState_win = true;
        }
        if (currentHealth <= minGirth)
        {
            gameState_Lose = true;
        }
    }
}