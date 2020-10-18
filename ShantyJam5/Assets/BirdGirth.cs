using UnityEngine;

public class BirdGirth : MonoBehaviour
{
    
    public int minGirth = 5;
    public int maxGirth = 100;
    public int currentHealth = 25;
    public bool gameState_Lose = false, gameState_win = false;    
    public HealthBar healthBar;    

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
        _particlesonThingConsumed.Play();
        AddGirth(Mathf.RoundToInt(consumable.GrithValue));
        AddSize();
    }   

    void AddSize()
    {
        this.scale += girthAddSize;
        UpdateSize();
    }
    void SubtractSize()
    {
        this.scale -= girthAddSize;
        UpdateSize();
    }
    void UpdateSize()
    {        
        scale = Mathf.Clamp(this.scale, .5f, 4);
        this.transform.localScale = new Vector3(this.scale, this.scale, this.scale);
    }

    void ChangeHealth(int change) => currentHealth = Mathf.Clamp(currentHealth + change, minGirth, maxGirth);
    void TakeDamage(int damage)
    {
        ChangeHealth(-damage);
        healthBar.SetHealth(currentHealth);
        SubtractSize();
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