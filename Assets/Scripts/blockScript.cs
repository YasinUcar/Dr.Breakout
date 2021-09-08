using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScript : MonoBehaviour
{
    [SerializeField] GameObject blockVFX;
    [SerializeField] int blockCount;
    [SerializeField] Sprite[] blockSprites;
    [SerializeField] AudioClip blockClip;
    levelScript level;
    int timesHit;

    private void Start()
    {
        countBreakbleBlocks();
       
    }

    private void countBreakbleBlocks()
    {
         level = FindObjectOfType<levelScript>();
        if (this.tag == "Breakable")
        {
            level.countBreakbleBlock();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        int maxHits = blockSprites.Length + 1;
        if (this.tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                destroyBlock();
            }
            else
            {
                showNextHitSprite();
            }
        }


    }
    private void showNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(blockSprites[spriteIndex]!=null)
        {
            GetComponent<SpriteRenderer>().sprite=blockSprites[spriteIndex];

        }
        else
        {
            print("Block sprites is missing"+this.gameObject.name);
        }
    }
    private void destroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockClip, Camera.main.transform.position, 100f);
        Destroy(this.gameObject);
        level.blockDestroyer();
        FindObjectOfType<GameManager>().AddPoint();
        triggerVFX();
    }
    private void triggerVFX()
    {
        GameObject sparkles = Instantiate(blockVFX, transform.position, transform.rotation);
        Destroy(sparkles.gameObject, 1.5f);
    }

}
