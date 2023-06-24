using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonamiCode : MonoBehaviour
{
	private KeyCode[] konamiCode = { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A };
	private int currentIndex = 0;

	private void Update()
	{
		if (Input.anyKeyDown)
		{
			if (Input.GetKeyDown(konamiCode[currentIndex]))
			{
				currentIndex++;

				if (currentIndex == konamiCode.Length)
				{
					Debug.Log("CHEATCODE: Konami entered");
					PerformDesiredActionOnAllHealthStats();

					currentIndex = 0; // Reset the current index for future inputs
				}
			}
			else
			{
				currentIndex = 0; // Reset the current index if the input doesn't match the Konami code sequence
			}
		}
	}

	private void PerformDesiredActionOnAllHealthStats()
	{
		StaminaStats[] staminaStatsArray = FindObjectsOfType<StaminaStats>();

		foreach (StaminaStats staminaStats in staminaStatsArray)
		{
			staminaStats.ModifyStamina(-100f);
			
		}
		
		
		
		
		
		HealthStats[] healthStatsArray = FindObjectsOfType<HealthStats>();

		foreach (HealthStats healthStats in healthStatsArray)
		{
			healthStats.ModifyHealth(-100f);
			Debug.Log("kon" + healthStats.transform.name);
		}
	}
}