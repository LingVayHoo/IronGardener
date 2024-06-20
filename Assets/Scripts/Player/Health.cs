using UnityEngine;

public class Health : MonoBehaviour
{
    public bool isAlive => currentHealth > 0;

    [SerializeField] private float maxHealth;
    private float currentHealth ;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
