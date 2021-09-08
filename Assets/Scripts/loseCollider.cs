using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loseCollider : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D other) 
  {
 Destroy(other.gameObject);
  SceneManager.LoadScene("zGameOver");
  print("Game Over");
  }
}
