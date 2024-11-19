using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public EnemySpawner spawner; // Refer�ncia ao script do EnemySpawner

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            if (spawner != null) // Garante que o spawner est� atribu�do
            {
                spawner.SpawnEnemy(); // Chama o m�todo de spawn no EnemySpawner
            }

            // Opcional: desativa o trigger ap�s ser ativado
            gameObject.SetActive(false);
        }
    }
}
