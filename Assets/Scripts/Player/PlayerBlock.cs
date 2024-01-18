using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public bool isBlocking = false;
    public GameObject aura;
    private void Start()
    {
        aura.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aura.SetActive(true);
            isBlocking = true;

        }
        else if (!Input.GetMouseButton(1))
        {
            aura.SetActive(false);
            isBlocking = false;
        }
    }
}
