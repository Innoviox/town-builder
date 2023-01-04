using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public Resource exploits;
    public int woodCost;
    public bool placed;
    GridSquareScript sq;
    GridMaker gm;
    private Dictionary<Resource, int> cost;

    // Start is called before the first frame update
    void Start()
    {
        sq = transform.parent.GetComponent<GridSquareScript>();
        gm = transform.parent.parent.GetComponent<GridMaker>();
        placed = false;

        cost = new Dictionary<Resource, int>();
        cost[Resource.Wood] = woodCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (placed && sq.resource == exploits) {
            gm.AddResource(exploits, 1);
        }
    }

    public Dictionary<Resource, int> GetCost() {
        return cost;
    }
}
