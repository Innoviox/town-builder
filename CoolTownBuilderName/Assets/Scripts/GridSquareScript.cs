using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquareScript : MonoBehaviour
{
    public Material farmMaterial, woodsMaterial;
    Renderer renderer;
    GridMaker grid;
    Transform buildingImage;
    bool isBuilt = false;
    ResourceItems.gameResources resource;

    // Start is called before the first frame update
    void Start()
    {
        double prob = Random.Range(0.0f, 1.0f);
        renderer = GetComponent<Renderer>();
        if (prob < 0.2) {
            renderer.material = woodsMaterial;
            resource = ResourceItems.gameResources.Wood;
        } else if (prob < 0.3) {
            renderer.material = farmMaterial;
            resource = ResourceItems.gameResources.Food;
        }
        grid = transform.parent.GetComponent<GridMaker>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
