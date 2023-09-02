using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    #region Variaveis
    // Componentes
    [SerializeField] private Transform platformPosition;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed = 0.5f;

    // Atributos
    private int direction = 1;
    #endregion

    #region Funcoes Unity
    private void Update()
    {
        MovePlatform();
    }
    #endregion

    #region Metodos Gerais
    private void MovePlatform()
    {
        // Move a plataforma de acordo com o destino atual
        Vector2 target = currentTargetLocation();
        platformPosition.position = Vector2.Lerp(platformPosition.position, target, speed * Time.deltaTime);

        // Muda a dire��o da plataforma
        float distance = (target - (Vector2)platformPosition.position).magnitude; // Distancia recebe a diferen�a do target com a posi��o atual
        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }

    // Define o destino atual da plataforma
    private Vector2 currentTargetLocation()
    {
        if (direction == 1)
        {
            return endPoint.position;
        }
        else
        {
            return startPoint.position;
        }
    }

    // Apenas para debug
    private void OnDrawGizmos()
    {
        if (platformPosition != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platformPosition.transform.position, startPoint.position);
            Gizmos.DrawLine(platformPosition.transform.position, endPoint.position);
        }
    }
    #endregion
}
