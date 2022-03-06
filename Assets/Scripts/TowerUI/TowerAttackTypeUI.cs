using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackTypeUI : MonoBehaviour
{
    public bool debugOn;

    [SerializeField] private GameObject _regularAttackButton;
    [SerializeField] private GameObject _areaOfAttackButton;
    [SerializeField] private GameObject _debuffAttackButton;

    [SerializeField] private Tower _tower;//tower on selected parcel

    private void Awake()
    {
        Parcel.OnParcelSelected += displayUI;
        Parcel.OnParcelUnselected += hideUI;
    }

    private void displayUI(GameObject pParcel)
    {
        //parcel -> tower
        if (!pParcel.GetComponent<Parcel>().isParcelEmpty)
        {
            showButtons(true, true, true);

            _tower = pParcel.GetComponent<Parcel>().GetTower;
            Debug.Assert(_tower, $"{this.name}: 'Tower' script from a tower located on the currently selected parcel could not be found! Perhaps the tower obj does not exist on the parcel ");
        }
    }
    private void hideUI()
    {
        showButtons(false, false, false);
    }
    public void ChangeAttackToRegular()
    {
        _tower.ChangeTowerAttackType(Tower.AttackType.Regular);
    }
    public void ChangeAttackToAreaOf()
    {
        _tower.ChangeTowerAttackType(Tower.AttackType.AreaOf);
    }
    public void ChangeAttackToDebuff()
    {
        _tower.ChangeTowerAttackType(Tower.AttackType.Debuff);
    }

    void Start()
    {
        showButtons(false, false, false);
    }
    private void showButtons(bool pRegular, bool pAreaOf, bool pDestroy)
    {
        if (debugOn) Debug.Log($"{this.name}: ShowButtons build {pRegular}, upgrade {pAreaOf}, destroy {pDestroy}");
        _regularAttackButton.SetActive(pRegular);
        _areaOfAttackButton.SetActive(pAreaOf);
        _debuffAttackButton.SetActive(pDestroy);
    }
}
