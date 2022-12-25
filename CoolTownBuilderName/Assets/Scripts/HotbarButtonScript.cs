using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HotbarButtonScript : MonoBehaviour
{
    public TMP_Text text;
    public Transform grid;
    public Transform building;

    // Start is called before the first frame update
    void Start()
    {
        text.text = transform.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(string message) {
        grid.GetComponent<GridMaker>().SetBuilding(building);
    }
}
