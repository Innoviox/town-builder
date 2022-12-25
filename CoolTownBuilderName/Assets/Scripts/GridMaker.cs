using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public int width, length;
    public Transform gridSquare;

    // Start is called before the first frame update
    void Start()
    {
        for (int y=0; y<length; y++)
       {
           for (int x=0; x<width; x++)
           {
               Transform t = Instantiate(gridSquare, new Vector3(y,0,x), Quaternion.identity);
               t.parent = this.transform;
           }
       }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
