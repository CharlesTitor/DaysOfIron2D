using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour
{
   private bool isPlayerInRange;


    void Update()
    {
        
    }

    private void onTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange =true;
            Debug.Log("Se puede iniciar un dialogo");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
             isPlayerInRange =false;
             Debug.Log("No se puede inicia un dialogo");
        }

    }
}
