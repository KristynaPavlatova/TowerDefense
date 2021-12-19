using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    protected GameObject model;
    protected int health;
    protected int carriedMoney;
    protected float movingSpeed;
    public void InitializeEnemy(int pHealth, int pCarriedMoney, float pMovingSpeed)
    {
        health = pHealth;
        carriedMoney = pCarriedMoney;
        movingSpeed = pMovingSpeed;
    }

}
