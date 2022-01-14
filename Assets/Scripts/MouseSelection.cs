using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    private Camera _mainCamera;
    private GameObject _lastSelectedObject;
    private GameObject _currentlySelectedObj;

    void Awake()
    {
        _mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectSelectableObject();
        }
    }

    //SELECTING ONLY SELECTABLE OBJECTS
    private void SelectSelectableObject()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Selecting any object for the first time
            if (_lastSelectedObject == null)
            {
                //define vars for entering and exiting selection methods later
                _lastSelectedObject = hit.collider.gameObject;
                _currentlySelectedObj = _lastSelectedObject;

                enterSelection(_currentlySelectedObj);
            }
            else
            {
                //Not selecting (clicking at) the same object that is now selected
                if (_lastSelectedObject != hit.collider.gameObject)
                {
                    _lastSelectedObject = _currentlySelectedObj;//switch current to old so current can change
                    _currentlySelectedObj = hit.collider.gameObject;//assign new selected obj

                    enterSelection(_currentlySelectedObj);
                    exitSelection(_lastSelectedObject);
                }
                else
                {
                    exitSelection(_lastSelectedObject);
                    //nothing selected now
                    _lastSelectedObject = null;
                    _currentlySelectedObj = null;
                }
            }
        }
    }
    //Observer pattern? Since this MouseSelection only knows a selected object implements
    //an interface but doesn't know/care about the implementation
    private void enterSelection(GameObject pObj)
    {
        if (pObj.GetComponent(typeof(ISelectable)))//Object is implementing interface
        {
            pObj.GetComponent<Parcel>().SelectionEnter();
        }
    }
    private void exitSelection(GameObject pObj)
    {
        if (pObj.GetComponent(typeof(ISelectable)))
        {
            pObj.GetComponent<Parcel>().SelectionExit();
        }
    }
}
