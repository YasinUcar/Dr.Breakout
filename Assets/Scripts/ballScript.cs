using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    [SerializeField] float xPush = 2.5f;
    [SerializeField] float yPush = 12f;
    [SerializeField] GameObject paddle1;
    [SerializeField] AudioClip[] blockClip;
    bool isPlaying = false;
    Vector2 paddleToBallDifference;
    Rigidbody2D myRig2D;
    AudioSource myAudioSource;
    void Start()
    {
        paddleToBallDifference = transform.position - paddle1.transform.position;
        myRig2D = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

private void Awake() {
    int currentGameStatus=FindObjectsOfType<GameManager>().Length;
    if(currentGameStatus>1)
    {
        Destroy(this.gameObject);
    }
    else
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

    void Update()
    {
        if (!isPlaying)
        {

            lockToBall();
            shotToBall();
        }


    }

    private void lockToBall()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallDifference + paddlePos;
        isPlaying = false;
    }

    private void shotToBall()
    {
        if (Input.GetMouseButtonDown(0))
        {

            myRig2D.velocity = new Vector2(xPush, yPush);

            isPlaying = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isPlaying)
        {

            AudioClip soundClips = blockClip[(Random.Range(0, blockClip.Length))];
            myAudioSource.PlayOneShot(soundClips);
            
        }
    }


}
