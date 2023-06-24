using UnityEngine;

public class StaminaStats : MonoBehaviour
{
	public float maxStamina = 100f;

	[SerializeField]private float currentStamina=1;
	private HealthStats healthStats; // Reference to the HealthStats script
	private PotenceManager potenceManager; // Reference to the PotenceManager script

	private void Start()
	{
		potenceManager = GetComponent<PotenceManager>(); // Get the PotenceManager component from the same GameObject
		currentStamina = maxStamina * potenceManager.PotenceRating;
		healthStats = GetComponent<HealthStats>(); // Get the HealthStats component from the same GameObject
	}

	private void Update()
	{
		// You can add stamina regeneration logic here if desired
	}

	public void ModifyStamina(float amount)
	{
		currentStamina += amount;
		currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

		if (currentStamina <= 0f)
		{
			Debug.Log(transform.name + "exhaustion action in Stamina Stats");
			PerformExhaustionAction();
		}
	}

	private void PerformExhaustionAction()
	{
		Debug.Log(gameObject.transform.name + " Stamina reached or fell below zero - Perform exhaustion action here");
		healthStats.ModifyHealth(-healthStats.GetHealthLevel()); // Modify health to zero
		Destroy(gameObject);
	}

	public float GetStaminaLevel()
	{
		return currentStamina;
	}
}

