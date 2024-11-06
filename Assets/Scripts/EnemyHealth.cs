using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth; // Vida atual do inimigo
    public Animator animator; // Refer�ncia ao Animator para anima��es

    public void DamageEnemy(int damage)
    {
        // Reduz a vida do inimigo
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Aciona anima��o de morte e agenda destrui��o do objeto
            animator.SetBool("Dead", true);
            Invoke("DestroyAfterDelay", 3f);
            GameManager.instance.killedEnemies++;
            UI.instance.killedEnemiesText.text = "Kills:........................ " + GameManager.instance.killedEnemies;
        }
    }

    void DestroyAfterDelay()
    {
        // Destroi o objeto inimigo
        Destroy(gameObject);
    }
}
