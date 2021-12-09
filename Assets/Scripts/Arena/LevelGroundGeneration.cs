using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGroundGeneration : MonoBehaviour
{
    public GameObject groundSquarePrefab;
    [Space(10)]
    [SerializeField] private int mapRows;
    [SerializeField] private int mapColumns;

    private Vector3 thisPos;
    
    void Awake()
    {
        thisPos = this.transform.position;
    }
    
    void Update()
    {
        if (this.transform.childCount <= 0)
        {
            for (int i = 0; i < mapRows; i++)
            {
                for (int j = 0; j < mapColumns; j++)
                {
                    Instantiate(groundSquarePrefab, new Vector3(thisPos.x + i, thisPos.y, thisPos.z + j),
                        this.transform.rotation, this.transform);
                }
            }
        }
    }
}
