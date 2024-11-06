using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed, distanceToStop; // Velocidade de movimento e dist�ncia de parada do inimigo
    public NavMeshAgent agent; // Componente NavMeshAgent para navega��o autom�tica
    public Transform firePoint; // Ponto de onde o inimigo atira
    public float fireRate; // Taxa de tiros
    private float fireCount; // Contador para controlar o tempo entre tiros
    public float fireDelay; // Atraso entre a anima��o e o tiro
    public GameObject bullet; // Prefab da bala que o inimigo dispara
    public Animator animator; // Componente Animator para controlar anima��es do inimigo
    public GameObject MuzzleFlash; // Efeito visual do disparo

    void Start()
    {
        if (MuzzleFlash != null)
        {
            MuzzleFlash.SetActive(false); // Desativa o efeito de MuzzleFlash no in�cio
        }
    }

    void Update()
    {
        // Define o alvo do inimigo como a posi��o do jogador
        Vector3 target = PlayerMove.instance.transform.position;

        // Se o inimigo est� longe o suficiente, move-se em dire��o ao alvo
        if (Vector3.Distance(transform.position, target) > distanceToStop)
        {
            agent.destination = target;
        }
        else
        {
            agent.destination = transform.position; // Para o movimento quando est� pr�ximo o suficiente
        }

        // Controla o tempo entre tiros
        fireCount -= Time.deltaTime;
        if (fireCount <= 0)
        {
            fireCount = fireRate + fireDelay; // Reinicia o contador de tiros com um atraso
            firePoint.LookAt(PlayerMove.instance.transform.position + new Vector3(0f, 1f, 0f)); // Aponta o ponto de tiro para o jogador

            // Verifica o �ngulo para determinar se o inimigo pode atirar
            Vector3 targetDirection = PlayerMove.instance.transform.position - transform.position;
            float angle = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);

            if (Mathf.Abs(angle) < 15f)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation); // Cria a bala
                animator.SetTrigger("Fire"); // Dispara a anima��o de tiro
                StartCoroutine(WaitAndSetActiveFalse()); // Ativa o efeito de MuzzleFlash
            }
        }

        // Define anima��o de movimento com base na proximidade do alvo
        animator.SetBool("IsMoving", agent.remainingDistance >= 0.3f);
    }

    IEnumerator WaitAndSetActiveFalse()
    {
        if (MuzzleFlash != null && !MuzzleFlash.activeSelf)
        {
            MuzzleFlash.SetActive(true); // Ativa o efeito de MuzzleFlash temporariamente
            yield return new WaitForSeconds(0.03f); // Exibe o efeito por um curto per�odo
            MuzzleFlash.SetActive(false);
        }
    }
}
