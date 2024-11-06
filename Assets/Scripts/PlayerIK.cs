using UnityEngine;

public class PlayerIK : MonoBehaviour
{
    public Animator animator; // Refer�ncia ao Animator do personagem
    public Transform aimTarget; // Alvo de mira para onde o personagem deve apontar
    public Transform rightHandTarget; // Alvo para a m�o direita, onde ela deve se posicionar
    public Transform leftHandTarget; // Alvo para a m�o esquerda (opcional)
    public float ikWeight = 1.0f; // Peso para o IK, geralmente entre 0 e 1

    void OnAnimatorIK(int layerIndex)
    {
        if (animator != null)
        {
            // Se o jogador est� mirando (segurando o bot�o direito do mouse)
            if (Input.GetMouseButton(1))
            {
                // Configura o IK para a m�o direita
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, ikWeight);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);

                // Configura o IK para a m�o esquerda (caso haja alvo)
                if (leftHandTarget != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, ikWeight);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
                }

                // Configura para olhar na dire��o do alvo
                animator.SetLookAtWeight(ikWeight);
                animator.SetLookAtPosition(aimTarget.position);
            }
            else
            {
                // Desativa o IK quando n�o estiver mirando
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                if (leftHandTarget != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                }
                animator.SetLookAtWeight(0);
            }
        }
    }
}
