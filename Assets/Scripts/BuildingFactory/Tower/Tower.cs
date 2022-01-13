using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private int _currentLevel;

    public int GetTowerLevel => _currentLevel;
    public void SetTowerLevel(int pLevel)
    {
        _currentLevel = pLevel;
    }

    private void initializeTower()
    {
        //This method is called on its own to set all neccessary properties
        //for behaviour of the tower based on its current level.
        //It check with Tower scriptable object for guidelines on how it should be set up
    }

    //TOWER BEHAVIOUR
}
