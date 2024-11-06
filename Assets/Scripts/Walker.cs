using UnityEngine;

public class Walker : MonoBehaviour
{
    public Transform LeftFootTarget; // Alvo para a posi��o do p� esquerdo
    public Transform RightFootTarget; // Alvo para a posi��o do p� direito

    public AnimationCurve horizontalCurve; // Curva de movimento horizontal dos p�s
    public AnimationCurve verticalCurve; // Curva de movimento vertical dos p�s

    private Vector3 LeftTargetOffset, RightTargetOffset; // Posi��es iniciais dos p�s
    private float LeftLegLast = 0, RightLegLast = 0; // �ltimas posi��es dos p�s

    void Start()
    {
        // Define as posi��es iniciais dos p�s
        LeftTargetOffset = LeftFootTarget.localPosition;
        RightTargetOffset = RightFootTarget.localPosition;
    }

    void Update()
    {
        // Movimento para o p� esquerdo
        float leftLegForwardMovement = horizontalCurve.Evaluate(Time.time);
        float rightLegForwardMovement = horizontalCurve.Evaluate(Time.time - 1);

        LeftFootTarget.localPosition = LeftTargetOffset
            + this.transform.InverseTransformVector(LeftFootTarget.forward) * leftLegForwardMovement
            + this.transform.InverseTransformVector(LeftFootTarget.up) * verticalCurve.Evaluate(Time.time + 0.5f);

        RightFootTarget.localPosition = RightTargetOffset
            + this.transform.InverseTransformVector(RightFootTarget.forward) * rightLegForwardMovement
            + this.transform.InverseTransformVector(RightFootTarget.up) * verticalCurve.Evaluate(Time.time - 0.5f);

        // Detec��o de contato com o solo e avan�o do personagem
        RaycastHit hit;
        if (leftLegForwardMovement - LeftLegLast < 0 && Physics.Raycast(LeftFootTarget.position + LeftFootTarget.up, -LeftFootTarget.up, out hit, Mathf.Infinity))
        {
            LeftFootTarget.position = hit.point;
            this.transform.position += this.transform.forward * Mathf.Abs(leftLegForwardMovement - LeftLegLast);
        }

        if (rightLegForwardMovement - RightLegLast < 0 && Physics.Raycast(RightFootTarget.position + RightFootTarget.up, -RightFootTarget.up, out hit, Mathf.Infinity))
        {
            RightFootTarget.position = hit.point;
            this.transform.position += this.transform.forward * Mathf.Abs(rightLegForwardMovement - RightLegLast);
        }

        // Atualiza as �ltimas posi��es dos p�s
        LeftLegLast = leftLegForwardMovement;
        RightLegLast = rightLegForwardMovement;
    }
}
