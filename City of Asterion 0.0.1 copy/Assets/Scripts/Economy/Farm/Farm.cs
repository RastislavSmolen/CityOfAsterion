using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{
    public int cost;

    public Farm(int cost) : base(cost)
    {
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class  Building
{
    public int Cost { get; set; }

    public Building(int cost)
    {
        Cost = cost;
    }
}