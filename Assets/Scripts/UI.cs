using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance; // Singleton para acesso global � UI
    public Slider healthSlider; // Barra de vida do jogador
    public TextMeshProUGUI healthText; // Texto que exibe a vida do jogador
    public TextMeshProUGUI killedEnemiesText; // Texto que exibe a contagem de inimigos mortos

    public TextMeshProUGUI currentAmmoText; // Texto para exibir muni��o atual e m�xima
    public TextMeshProUGUI reserveAmmoText; // Texto para exibir muni��o em reserva

    public Image DamageEffect; // Efeito visual para indicar dano ao jogador
    public float damageAlpha = 0.3f, damageFadeSpeed = 3f; // Transpar�ncia e velocidade de desvanecimento do efeito de dano

    public GameObject pauseScreen; // Tela de pausa
    public int killedEnemies; // Contagem de inimigos mortos

    private void Awake()
    {
        instance = this; // Configura uma inst�ncia singleton para o UI
    }

    private void Update()
    {
        // Atualiza a exibi��o da muni��o e o efeito de dano, se necess�rio
        UpdateAmmoDisplay();
        if (DamageEffect.color.a != 0)
        {
            DamageEffect.color = new Color(DamageEffect.color.r, DamageEffect.color.g, DamageEffect.color.b,
                Mathf.MoveTowards(DamageEffect.color.a, 0f, damageFadeSpeed * Time.deltaTime));
        }
    }

    public void UpdateAmmoDisplay()
    {
        if (PlayerMove.instance != null)
        {
            int currentAmmo = PlayerMove.instance.currentAmmunition;
            int maxAmmo = PlayerMove.instance.maxLoadedAmmo;
            int reserveAmmo = PlayerMove.instance.reserveAmmo;

            // Exibe muni��o atual e m�xima
            currentAmmoText.text = $"{currentAmmo}/{maxAmmo}";
            // Exibe muni��o em reserva
            reserveAmmoText.text = $"{reserveAmmo}";
        }
    }

    public void ShowDamage()
    {
        // Ativa o efeito visual de dano
        DamageEffect.color = new Color(DamageEffect.color.r, DamageEffect.color.g, DamageEffect.color.b, damageAlpha);
    }
}
