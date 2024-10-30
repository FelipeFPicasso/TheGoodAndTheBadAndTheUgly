using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount; // Quantidade de muni��o para recarregar

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMove.instance.reserveAmmo += ammoAmount;
            Debug.Log("Muni��o coletada: " + ammoAmount + ", Muni��o em reserva: " + PlayerMove.instance.reserveAmmo);
            Destroy(gameObject);
        }
    }
}
