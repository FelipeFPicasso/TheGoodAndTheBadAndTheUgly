using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel; // Nome da cena do primeiro n�vel a ser carregada ao iniciar o jogo

    // M�todo para iniciar o jogo
    public void PlayGame()
    {
        // Carrega a cena especificada em "firstLevel"
        SceneManager.LoadScene(firstLevel);
    }

    // M�todo para sair do jogo
    public void QuitGame()
    {
        // Fecha a aplica��o (n�o funcionar� no Editor da Unity)
        Application.Quit();
    }
}
