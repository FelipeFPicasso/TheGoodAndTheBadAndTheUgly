using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    [TextArea]
    public string newMissionText; // Texto da nova miss�o a ser exibida

    public float missionStartDelay = 0f; // Tempo de atraso para iniciar a miss�o (em segundos)
    public SoundSpawner soundSpawner; // Refer�ncia ao script SoundSpawner

    public MissionTrigger[] otherMissionTriggers; // Lista de outras miss�es para parar o som

    private bool missionStarted = false; // Verifica se a miss�o j� foi iniciada

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou no trigger
        if (other.CompareTag("Player") && !missionStarted)
        {
            missionStarted = true; // Marca a miss�o como iniciada

            // Para sons de outras miss�es
            StopOtherMissionSounds();

            if (missionStartDelay > 0f)
            {
                StartCoroutine(StartMissionWithDelay());
            }
            else
            {
                StartMission();
            }
        }
    }

    private void StartMission()
    {
        // Atualiza o texto da miss�o na UI
        UI.instance.UpdateMissionText(newMissionText);

        // Toca o som, se o SoundSpawner estiver configurado
        if (soundSpawner != null)
        {
            soundSpawner.TriggerSound();
        }

        // Desativa o gatilho para evitar repeti��o
        gameObject.SetActive(false);
    }

    private void StopOtherMissionSounds()
    {
        foreach (MissionTrigger mission in otherMissionTriggers)
        {
            if (mission.soundSpawner != null)
            {
                mission.soundSpawner.StopSound();
            }
        }
    }

    private System.Collections.IEnumerator StartMissionWithDelay()
    {
        yield return new WaitForSeconds(missionStartDelay);
        StartMission();
    }
}
