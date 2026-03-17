using System.Collections;
using System.Collections.Generic;   
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameController gameController;
    ScoreSave scoreSave;
    void Start(){
            gameController = FindObjectOfType<GameController>();
            scoreSave = FindObjectOfType<ScoreSave>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            scoreSave.IncrementScore();
            Destroy(gameObject);
            collision.gameObject.GetComponent<Line>().PlaySound();
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Finish") && gameController != null)
        {
            gameController.IsGameOver = true;
            collider.gameObject.GetComponent<LineLoseGame>().PlaySound();
        }

    }
    
}
