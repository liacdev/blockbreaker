using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config parameters
    [SerializeField] float blockDestroyDelay = 0.5f;
    [SerializeField] AudioClip breakSound;
    [SerializeField] float breakSoundVolume = 1f;

    // Cached reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        DestroyBlock();
    }
        
    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();  
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, breakSoundVolume);
        Destroy(gameObject, blockDestroyDelay); 
        level.BlockDestroyed();    
    }
}
