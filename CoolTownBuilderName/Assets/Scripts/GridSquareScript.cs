using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquareScript : MonoBehaviour
{
    public Material farmMaterial, woodsMaterial;
    public Material highlightedMaterial;
    public Material defaultMaterial;
    public Resource resource;

    Renderer renderer;
    GridMaker grid;
    Transform buildingImage;
    bool isBuilt = false;
    bool saveBuilding = false;

    // Start is called before the first frame update
    void Start()
    {
        double prob = Random.Range(0.0f, 1.0f);
        if (prob < 0.2) {
            defaultMaterial = woodsMaterial;
            resource = Resource.Wood;
        } else if (prob < 0.3) {
            defaultMaterial = farmMaterial;
            resource = Resource.Food;
        } else {
            resource = Resource.None;
        }

        renderer = GetComponent<Renderer>();
        renderer.material = defaultMaterial;

        grid = transform.parent.GetComponent<GridMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        renderer.material = highlightedMaterial;

        if (buildingImage == null) {
            var b = grid.GetCurrentBuilding();
            if (b != null) {
                buildingImage = Instantiate(b, transform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
                buildingImage.parent = transform;
            }
        }
    }

    void OnMouseExit()
    {
        renderer.material = defaultMaterial;
        if (buildingImage != null && !saveBuilding) {
            Destroy(buildingImage.gameObject);
        }
    }

    void OnMouseDown()
    {
        var cost = buildingImage.GetComponent<BuildingScript>().GetCost();
        if (buildingImage != null && grid.CanBuildBuilding(cost)) {
            saveBuilding = true;
            buildingImage.GetComponent<BuildingScript>().placed = true;
            grid.Pay(cost);
        }
    }
}
