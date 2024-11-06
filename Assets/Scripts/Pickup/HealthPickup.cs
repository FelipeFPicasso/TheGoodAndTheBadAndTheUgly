using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int heal; // Quantidade de vida para curar o jogador ao coletar

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (other.tag == "Player")
        {
            // Cura o jogador chamando o m�todo HealPlayer no script PlayerHealth
            PlayerHealth.instance.HealPlayer(heal);
            // Destroi o item de cura ap�s a coleta
            Destroy(gameObject);
        }
    }
}
