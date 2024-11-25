using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    [TextArea]
    public string newMissionText; // Texto da nova miss�o a ser exibida

    public float missionStartDelay = 0f; // Tempo de atraso para iniciar a miss�o (em segundos)

    private bool missionStarted = false; // Verifica se a miss�o j� foi iniciada

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou no trigger
        if (other.CompareTag("Player") && !missionStarted)
        {
            missionStarted = true; // Marca a miss�o como iniciada

            if (missionStartDelay > 0f)
            {
                // Aguarda o tempo especificado antes de iniciar a miss�o
                StartCoroutine(StartMissionWithDelay());
            }
            else
            {
                // Inicia a miss�o imediatamente
                StartMission();
            }
        }
    }

    private void StartMission()
    {
        // Atualiza o texto da miss�o na UI
        UI.instance.UpdateMissionText(newMissionText);

        // Desativa o gatilho para evitar repeti��o
        gameObject.SetActive(false);
    }

    private System.Collections.IEnumerator StartMissionWithDelay()
    {
        // Aguarda o tempo especificado antes de iniciar a miss�o
        yield return new WaitForSeconds(missionStartDelay);
        StartMission();
    }
}
