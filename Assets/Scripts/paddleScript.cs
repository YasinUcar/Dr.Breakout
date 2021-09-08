using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour
{
   
    void Start()
    {

    }

 
    void Update()
    {
  float mousePos=Input.mousePosition.x/Screen.width*16f;
  var paddlePos=new Vector2(transform.position.x,transform.position.y);
  paddlePos.x=Mathf.Clamp(mousePos,-6.50f,6.50f);
  transform.position=paddlePos;

    }
}
