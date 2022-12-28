using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridMaker : MonoBehaviour
{
    public int width, length;
    public Transform gridSquare;
    private List<Transform> children;
    private Transform currentBuilding;

    private Dictionary<ResourceItems.gameResources, int> res; 

    public TMP_Text foodText, woodText;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>();
        
        res = new Dictionary<ResourceItems.gameResources, int>();
        foreach(ResourceItems.gameResources type in System.Enum.GetValues(typeof(ResourceItems.gameResources)))
        {
            res.Add(type, 50);
            
        }

        foodText.text = res[ResourceItems.gameResources.Food].ToString();
        woodText.text = res[ResourceItems.gameResources.Wood].ToString();
        

        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Transform t = Instantiate(gridSquare, new Vector3(y, 0, x), Quaternion.identity);
                t.parent = this.transform;
                children.Add(t);
            }
        }    

    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = res[ResourceItems.gameResources.Food].ToString();
        woodText.text = res[ResourceItems.gameResources.Wood].ToString();
    }

    public void SetBuilding(Transform building) {
        currentBuilding = building;
        
    }

    public Transform GetCurrentBuilding() {
        return currentBuilding;
    }
}
