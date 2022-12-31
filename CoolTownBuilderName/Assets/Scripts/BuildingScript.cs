using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public Resource exploits;
    public bool placed;
    GridSquareScript sq;
    GridMaker gm;

    // Start is called before the first frame update
    void Start()
    {
        sq = transform.parent.GetComponent<GridSquareScript>();
        gm = transform.parent.parent.GetComponent<GridMaker>();
        placed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (placed && sq.resource == exploits) {
            gm.AddResource(exploits, 1);
        }
    }
}
