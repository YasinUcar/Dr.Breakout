using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelScript : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    sceneLoader scene;

    // Start is called before the first frame update
    void Start()
    {
    scene=FindObjectOfType<sceneLoader>();    
    }

    // Update is called once per frame
    public void countBreakbleBlock()
    {
        breakableBlocks++;
    }
    public void blockDestroyer()
    {
        breakableBlocks--;
        if(breakableBlocks<=0)
{
    scene.LoadNextScene();
}

    }
}
