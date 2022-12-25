using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSquare : MonoBehaviour
{

    public Material defaultMaterial, highlightedMaterial;
    Renderer renderer;
    GridMaker grid;
    Transform buildingImage;
    bool saveBuilding = false;

    // Start is called before the first frame update
    void Start()
    {
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
        if (buildingImage != null) {
            saveBuilding = true;
        }
    }
}
