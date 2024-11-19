using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth; // Vida atual do inimigo
    public Animator animator; // Refer�ncia ao Animator para anima��es
    private EnemyMove enemyMove; // Refer�ncia ao script de movimento

    void Start()
    {
        enemyMove = GetComponent<EnemyMove>(); // Obt�m a refer�ncia ao script EnemyMove
    }

    public void DamageEnemy(int damage)
    {
        currentHealth -= damage; // Reduz a vida do inimigo

        if (currentHealth <= 0)
        {
            if (enemyMove != null)
            {
                enemyMove.Die(); // Desativa o movimento e ataque do inimigo
            }
            Invoke("DestroyAfterDelay", 3f); // Agende a destrui��o do objeto
            GameManager.instance.killedEnemies++;
            UI.instance.killedEnemiesText.text = "Kills:........................ " + GameManager.instance.killedEnemies;
        }
    }

    void DestroyAfterDelay()
    {
        Destroy(gameObject); // Destroi o objeto inimigo
    }
}
