using UnityEngine;

public class AceroInoxidable : MonoBehaviour
{
    public QuestManager1 questManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            questManager.AgregarIron();

            Destroy(gameObject);
        }
    }
}
