using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config parameters
    [SerializeField] float blockDestroyDelay = 0.5f;
    [SerializeField] float breakSoundVolume = 1f;
    [SerializeField] float particleDestroyDelay = 1f;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;

    // State variables
    [SerializeField] int timesHit; // TODO: Serialized for debug purposes


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }
        
    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else 
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
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
