using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;

    public bool isOpen = false;
    public float smoth = 0.1f;

    void Update()
    {
        if(isOpen)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, endPosition, smoth);
        }else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, smoth);
        }
    }
}
