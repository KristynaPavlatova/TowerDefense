using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class AbstractEnemy : MonoBehaviour, IMortal
{
    [SerializeField]
    protected int health;
    protected int carriedMoney;

    protected NavMeshAgent agent;
    public void InitializeEnemy(int pHealth, int pCarriedMoney, float pMovingSpeed, float pStoppingDistance)
    {
        agent = this.GetComponent<NavMeshAgent>();
        Debug.Assert(agent, $"{this.name} NavMeshAgent could not be found!");

        health = pHealth;
        carriedMoney = pCarriedMoney;
        agent.speed = pMovingSpeed;
        agent.stoppingDistance = pStoppingDistance;
    }

    public void OnDeath()
    {
        Debug.Log($"{this.name}: DIED!");
        Destroy(this.gameObject);
    }

    public void TakeDamage(int pAmount)
    {
        if (health - pAmount > 0)
        {
            health -= pAmount;
        }
        else OnDeath();
    }
}
