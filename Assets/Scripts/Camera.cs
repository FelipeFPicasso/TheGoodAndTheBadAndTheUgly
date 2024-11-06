using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform cameraTarget; // O alvo que a c�mera seguir�

    void LateUpdate()
    {
        // Posiciona e rotaciona a c�mera para coincidir com o alvo
        transform.position = cameraTarget.position;
        transform.rotation = cameraTarget.rotation;
    }
}
