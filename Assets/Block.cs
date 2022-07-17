using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] float blockBreakDelay = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject, blockBreakDelay);    
    }
}
