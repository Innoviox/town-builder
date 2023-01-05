using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour
{
    public Job job = Job.None;
    private Dictionary<Job, float> skills;

    // Start is called before the first frame update
    void Start()
    {
        skills = new Dictionary<Job, float>();
        foreach(Job j in System.Enum.GetValues(typeof(Job)))
        {
            skills.Add(j, 1.0f);   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
