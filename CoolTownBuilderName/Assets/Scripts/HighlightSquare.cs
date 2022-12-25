using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSquare : MonoBehaviour
{

    public Material defaultMaterial, highlightedMaterial;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = defaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        renderer.material = highlightedMaterial;
    }

    void OnMouseExit()
    {
        renderer.material = defaultMaterial;
    }
}
