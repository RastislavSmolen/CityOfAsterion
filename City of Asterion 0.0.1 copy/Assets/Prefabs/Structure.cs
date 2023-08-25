using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public bool occupied;

    private void OnTriggerEnter(Collider other)
    {
        occupied = true;
    }
    private void OnTriggerExit(Collider other)
    {
        occupied = false;
    }
   
}
