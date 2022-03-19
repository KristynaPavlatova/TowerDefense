using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _playerHealth;
    [SerializeField] private PlayerResources _playerResourcesScriptable;

    public int GetPlayerHealth => _playerHealth;
    public void ResetPlayerHealth()
    {
        //Each new wave start with max health.
        _playerHealth = _playerResourcesScriptable.playerMaxHealth;
    }
    public bool DecreasePlayerGold(int pAmount)
    {
        if ((_playerHealth - pAmount) > 0)
        {
            _playerHealth -= pAmount;
            return true;
        }
        else
        {
            //TRIGGER GAME OVER!!
            return false;
        }
    }

    private void Start()
    {
        Debug.Assert(_playerResourcesScriptable, $"{this.name}: playerResource reference of the scriptable object is not set!");
        initializePlayerHealth();
    }
    private void initializePlayerHealth()
    {
        _playerHealth = _playerResourcesScriptable.playerMaxHealth;
    }
}
