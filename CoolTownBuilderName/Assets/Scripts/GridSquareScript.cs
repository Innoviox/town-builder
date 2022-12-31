using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquareScript : MonoBehaviour
{
    public Material farmMaterial, woodsMaterial;
    HighlightSquare highlightSquare;
    Renderer renderer;
    GridMaker grid;
    Transform buildingImage;
    bool isBuilt = false;
    public Resource resource;

    // Start is called before the first frame update
    void Start()
    {
        double prob = Random.Range(0.0f, 1.0f);
        highlightSquare = GetComponent<HighlightSquare>();
        if (prob < 0.2) {
            highlightSquare.defaultMaterial = woodsMaterial;
            resource = Resource.Wood;
        } else if (prob < 0.3) {
            highlightSquare.defaultMaterial = farmMaterial;
            resource = Resource.Food;
        } else {
            resource = Resource.None;
        }

        renderer = GetComponent<Renderer>();
        renderer.material = highlightSquare.defaultMaterial;

        grid = transform.parent.GetComponent<GridMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
