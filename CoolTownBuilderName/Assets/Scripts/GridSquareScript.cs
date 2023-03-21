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
        if (prob < 0.2)
        {
            defaultMaterial = woodsMaterial;
            resource = Resource.Wood;
        }
        else if (prob < 0.3)
        {
            defaultMaterial = farmMaterial;
            resource = Resource.Food;
        }
        else
        {
            resource = Resource.None;
        }

        renderer = GetComponent<Renderer>();
        renderer.material = defaultMaterial;

        grid = transform.parent.GetComponent<GridMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (buildingImage != null && !saveBuilding)
            {
                Destroy(buildingImage.gameObject);
                buildingImage = null;
            }
        }
    }

    void OnMouseOver()
    {
        renderer.material = highlightedMaterial;

        if (buildingImage == null)
        {
            var b = grid.GetCurrentBuilding();
            if (b != null)
            {
                buildingImage = Instantiate(b, transform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
                buildingImage.parent = transform;
            }
        }
    }

    void OnMouseExit()
    {
        renderer.material = defaultMaterial;
        if (buildingImage != null && !saveBuilding)
        {
            Destroy(buildingImage.gameObject);
            buildingImage = null;
        }
    }

    void OnMouseDown()
    {
        if (buildingImage != null)
        {
            var buildingScript = buildingImage.GetComponent<BuildingScript>();
            if (buildingScript.placed)
            {
                var infoPanel = Instantiate(grid.infoPanel, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                infoPanel.GetComponent<BuildingInfo>().SetBuilding(buildingScript);
                infoPanel.parent = grid.canvas.transform;
            }
            else
            {
                var cost = buildingScript.GetCost();
                if (buildingImage != null && grid.CanBuildBuilding(cost))
                {
                    saveBuilding = true;
                    buildingScript.placed = true;
                    grid.Pay(cost);
                }
            }
        }
    }
}
