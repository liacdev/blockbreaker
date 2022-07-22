using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config parameters
    [SerializeField] float blockDestroyDelay = 0.5f;
    [SerializeField] AudioClip breakSound;
    [SerializeField] float breakSoundVolume = 1f;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] float particleDestroyDelay = 1f;

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
        PlayBlockDestroySFX();
        Destroy(gameObject, blockDestroyDelay); 
        level.BlockDestroyed();    
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();  
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, breakSoundVolume);
    }


    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);   
        Destroy(sparkles, particleDestroyDelay); 
    }


}
