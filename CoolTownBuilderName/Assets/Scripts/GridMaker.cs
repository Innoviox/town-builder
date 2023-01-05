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

    private Dictionary<Resource, int> res; 

    public TMP_Text foodText, woodText;
    public Transform person;
    public int startingPopulation;
    private List<PersonScript> people;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>();
        
        res = new Dictionary<Resource, int>();
        foreach(Resource type in System.Enum.GetValues(typeof(Resource)))
        {
            res.Add(type, 50);   
        }

        foodText.text = res[Resource.Food].ToString();
        woodText.text = res[Resource.Wood].ToString();
        
        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Transform t = Instantiate(gridSquare, new Vector3(y, 0, x), Quaternion.identity);
                t.parent = this.transform;
                children.Add(t);
            }
        }

        people = new List<PersonScript>();
        for (int i = 0; i < startingPopulation; i++) {
            var t = Instantiate(person, new Vector3(i, 0.5f, 0), Quaternion.identity);
            t.parent = this.transform;
            people.Add(t.GetComponent<PersonScript>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = res[Resource.Food].ToString();
        woodText.text = res[Resource.Wood].ToString();

        if (Input.GetKey(KeyCode.Escape)) {
            SetBuilding(null);
        }
    }

    public void SetBuilding(Transform building) {
        currentBuilding = building;
    }

    public Transform GetCurrentBuilding() {
        return currentBuilding;
    }

    public void AddResource(Resource r, int n) {
        res[r] += n;
    }

    public bool CanBuildBuilding(Dictionary<Resource, int> cost) {
        foreach (Resource r in cost.Keys) {
            if (res[r] < cost[r]) {
                return false;
            }
        }
        return true;
    }

    public void Pay(Dictionary<Resource, int> cost) {
        foreach (Resource r in cost.Keys) {
            res[r] -= cost[r];
        }
    }
}
