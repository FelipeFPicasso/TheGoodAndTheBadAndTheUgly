using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public string mainMenu; // Nome da cena do menu principal

    // M�todo para retomar o jogo
    public void Resume()
    {
        // Chama o m�todo de pausa do GameManager para alternar entre pausar/despausar
        GameManager.instance.PauseUnpause();
    }

    // M�todo para voltar ao menu principal
    public void MainMenu()
    {
        // Carrega a cena do menu principal
        SceneManager.LoadScene(mainMenu);
    }

    // M�todo para sair do jogo
    public void QuitGame()
    {
        // Fecha a aplica��o
        Application.Quit();
    }
}
