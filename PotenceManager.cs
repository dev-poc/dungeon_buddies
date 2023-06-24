using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotenceManager : MonoBehaviour
{
	public float PotenceRating { get; private set; } = 1f; // Default value of 1f
	[SerializeField]
	private float potenceRating = -1;

	private void Start()
	{
		// Generate a random potence rating between 0.5 and 1
		potenceRating = Random.Range(0.5f, 1f);
	}

	public void SetPotenceRating(float rating)
	{
		potenceRating = rating;
	}

	public float GetPotenceRating()
	{
		return potenceRating;
	}
}