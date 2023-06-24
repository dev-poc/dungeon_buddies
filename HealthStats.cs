using UnityEngine;

[DefaultExecutionOrder(200)]
public class HealthStats : MonoBehaviour
{
	public float maxHealth = 100f;

	[SerializeField]
	private float currentHealth;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	public void ModifyHealth(float amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

		if (currentHealth <= 0f)
		{
			PerformDeathAction();
		}
	}

	public float GetHealthLevel()
	{
		return currentHealth;
	}

	private void PerformDeathAction()
	{
		Debug.Log(gameObject.transform.name + " Health reached or fell below zero - Perform death action here");
		Destroy(gameObject);
	}
}