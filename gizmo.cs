using UnityEngine;
// Sphere gizmo to get attention.
public class SphericalGizmo : MonoBehaviour
{
	[Header("Gizmo Settings")]
	public Color gizmoColor = Color.white;
	public float gizmoRadius = 0.5f;

	void OnDrawGizmos()
	{
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere(transform.position, gizmoRadius);
		
	}
}
