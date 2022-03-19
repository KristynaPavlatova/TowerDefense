using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour
{
    private int _goldBallance;
    [SerializeField] private PlayerResources _playerResourcesScriptable;
    [SerializeField] private Text _goldUIText;

    public int GetPlayerGold => _goldBallance;
    public void IncreasePlayerGold(int pAmount)
    {
        _goldBallance += pAmount;
        updateUIText();
    }
    public bool DecreasePlayerGold(int pAmount)
    {
        if ((_goldBallance - pAmount) >= 0)
        {
            _goldBallance -= pAmount;
            updateUIText();
            return true;
        }
        else return false;
    }

    private void Start()
    {
        Debug.Assert(_playerResourcesScriptable, $"{this.name}: playerResource reference of the scriptable object is not set!");
        initializePlayerGold();

        Debug.Assert(_goldUIText, $"{this.name}: player gold UI reference is not set!");

    }
    private void initializePlayerGold()
    {
        _goldBallance = _playerResourcesScriptable.playerStarGold;
        updateUIText();
    }
    private void updateUIText()
    {
        _goldUIText.text = "Gold: " + _goldBallance.ToString();
    }
}