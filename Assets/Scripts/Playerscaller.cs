using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shrinkObject;
    public GameObject growObject;

    public float shrinkFactor = 0.5f; // Customizable shrink factor.
    public float growFactor = 2.0f;    // Customizable grow factor.

    private bool isShrunk = false;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other) //once it collides with Item shrink or grow
    {
        if (other.gameObject == shrinkObject)
        {
            Shrink();
        }
        else if (other.gameObject == growObject)
        {
            Grow();
        }
    }

    private void Shrink()
    {
        if (!isShrunk)
        {
            isShrunk = true;
            transform.localScale = originalScale * shrinkFactor;
        }
    }

    private void Grow()
    {
        if (isShrunk)
        {
            isShrunk = false;
            transform.localScale = originalScale * growFactor;
        }
    }
}
