using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    public TextMeshProUGUI currentAmmoText; // Texto para exibir muni��o atual e m�xima
    public TextMeshProUGUI reserveAmmoText; // Texto para exibir muni��o em reserva

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UpdateAmmoDisplay();
    }

    public void UpdateAmmoDisplay()
    {
        if (PlayerMove.instance != null)
        {
            int currentAmmo = PlayerMove.instance.currentAmmunition;
            int maxAmmo = PlayerMove.instance.maxLoadedAmmo;
            int reserveAmmo = PlayerMove.instance.reserveAmmo;

            // Exibir muni��o atual e m�xima
            currentAmmoText.text = $"{currentAmmo}/{maxAmmo}";

            // Exibir muni��o em reserva
            reserveAmmoText.text = $"{reserveAmmo}";
        }
    }
}
