using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start was called");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update was called");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate was called");
    }
}
