using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
   [SerializeField] [Range(0f,10f)] float gameSpeed=1f;
   [SerializeField] TextMeshProUGUI scoreText;
   [SerializeField] int currentPoint=0;
   [SerializeField] int addPoint=10;
  
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
   private void Start() 
   {
  
  scoreText.text=currentPoint.ToString();

  
   }
    public  void AddPoint()
   {
currentPoint+=addPoint;
scoreText.text=currentPoint.ToString();
   }

   private void Update() {
      Time.timeScale=gameSpeed;
   }
   public void resetScore()
   {
      Destroy(this.gameObject);
   }
}
