using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GroundSquareModelSelection : MonoBehaviour
{
    public GameObject squareModelPrefab;
    public ModelRotation modelRotation;
    
    private MeshRenderer rend;
    private bool _wasFirstModelInstantiated;
    
    public enum ModelRotation
    {
        ZERO = 0,
        NINETY = 90,
        ONE_HUNDRED_EIGHTY = 180,
        TWO_HUNDRED_SEVENTY = 270
    }
    void Awake()
    {
        rend = this.GetComponent<MeshRenderer>();
        _wasFirstModelInstantiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (squareModelPrefab != null)
        {
            if (!_wasFirstModelInstantiated)
            {
                rend.enabled = false;;//Hide the square
                Quaternion q = Quaternion.Euler(this.transform.rotation.x, (int) modelRotation,
                    this.transform.rotation.z);
                Instantiate(squareModelPrefab, this.transform.position, q, this.transform);
                _wasFirstModelInstantiated = true;
            }
            else
            {
                //delete children to get rid of the previous model that was created on the square
                if (this.transform.childCount > 0)
                {
                    foreach (Transform child in transform) {
                        GameObject.DestroyImmediate(child.gameObject);
                    }
                }
                Quaternion q = Quaternion.Euler(this.transform.rotation.x, (int) modelRotation,
                    this.transform.rotation.z);
                //create the new model onto the square
                Instantiate(squareModelPrefab, this.transform.position, q, this.transform);
            }
            
        }
    }
}
