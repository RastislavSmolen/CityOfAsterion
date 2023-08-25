using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInformation : MonoBehaviour
{

    private void Start()
    {
        transform.gameObject.SetActive(false);

    }

    public void ShowUI()
    {
        transform.gameObject.SetActive(true);
    }
    public void HideUI()
    {
        transform.gameObject.SetActive(false);

    }
}
