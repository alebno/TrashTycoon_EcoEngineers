using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Objetivo")]
    [SerializeField] private Transform target;

    [Header("Configuracion de Suavizado")]
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 1f, -10f);

    [Header("Zona Muerta (Dead Zone)")]
    [SerializeField] private float deadZoneX = 1.5f;

    [Header("Limites del Escenario (Clamping)")]
    [SerializeField] private bool useLimits = false; // Desactivado por ahora para que no te frene
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 50f;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = transform.position;
        float deltaX = target.position.x - transform.position.x;

        // Zona muerta horizontal
        if (Mathf.Abs(deltaX) > deadZoneX)
        {
            targetPosition.x = target.position.x - (Mathf.Sign(deltaX) * deadZoneX);
        }

        targetPosition.y = target.position.y + offset.y;
        targetPosition.z = offset.z;

        if (useLimits)
        {
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}