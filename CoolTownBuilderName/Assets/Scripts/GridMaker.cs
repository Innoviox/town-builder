using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public int width, length;
    public Transform gridSquare;
    private List<Transform> children;
    private Transform currentBuilding;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>();
        
        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Transform t = Instantiate(gridSquare, new Vector3(y, 0, x), Quaternion.identity);
                t.parent = this.transform;
                children.Add(t);
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBuilding(Transform building) {
        currentBuilding = building;
    }

    public Transform GetCurrentBuilding() {
        return currentBuilding;
    }
}
