using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount; // Quantidade de muni��o para recarregar

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (other.tag == "Player")
        {
            // Adiciona muni��o � reserva do jogador acessando o script PlayerMove
            PlayerMove.instance.reserveAmmo += ammoAmount;
            Debug.Log("Muni��o coletada: " + ammoAmount + ", Muni��o em reserva: " + PlayerMove.instance.reserveAmmo);
            // Destroi o item de muni��o ap�s a coleta
            Destroy(gameObject);
        }
    }
}
