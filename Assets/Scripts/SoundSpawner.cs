using UnityEngine;

public class SoundSpawner : MonoBehaviour
{
    public GameObject audioSourceObject; // Objeto que cont�m o AudioSource
    public float spawnDelay = 0f; // Tempo de atraso para tocar o som (em segundos)
    private bool hasPlayed = false; // Garante que o som seja tocado apenas uma vez

    private AudioSource audioSource;

    private void Start()
    {
        if (audioSourceObject != null)
        {
            // Obt�m o componente AudioSource do objeto
            audioSource = audioSourceObject.GetComponent<AudioSource>();

            if (audioSource == null)
            {
                Debug.LogWarning("O objeto associado n�o cont�m um AudioSource.");
            }
            else
            {
                audioSource.enabled = false; // Desativa o AudioSource no in�cio
            }
        }
        else
        {
            Debug.LogWarning("Nenhum objeto de AudioSource foi associado ao SoundSpawner.");
        }
    }

    public void TriggerSound()
    {
        if (!hasPlayed && audioSource != null) // Verifica se j� foi tocado e se o AudioSource � v�lido
        {
            hasPlayed = true; // Marca como tocado

            if (spawnDelay > 0f)
            {
                // Aguarda o tempo especificado antes de tocar o som
                StartCoroutine(PlaySoundWithDelay());
            }
            else
            {
                // Toca o som imediatamente
                PlaySound();
            }
        }
    }

    private void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.enabled = true; // Ativa o AudioSource antes de tocar o som
            audioSource.Play(); // Toca o som no AudioSource associado
        }
    }

    public void StopSound()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Para o som
            audioSource.enabled = false; // Desativa o AudioSource
        }
    }

    private System.Collections.IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(spawnDelay); // Aguarda o tempo especificado
        PlaySound();
    }

    // M�todo para reiniciar o spawner caso necess�rio
    public void ResetSpawner()
    {
        hasPlayed = false;
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.enabled = false; // Desativa o AudioSource novamente
        }
    }
}
