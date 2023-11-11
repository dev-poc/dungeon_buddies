using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] [Tooltip("The time interval, in seconds, between each entity spawn.")]
	private float spawnInterval = 1f;
	[SerializeField] [Tooltip("The maximum number of entities to be spawned.")]
	private int maxSpawns = 10;
	[SerializeField] [Tooltip("The current count of spawned entities.")]
	private int spawnedEntityCount = 0;
	[SerializeField] [Tooltip("The data for spawning different objects with varying tiers.")]
	private SpawnObjectData spawnObjectData;
	[SerializeField] [Tooltip("Set to true if you want to instantiate spawns as child objects.")]
	private bool instantiateAsChild = false;

	private void Start()
	{
		List<Transform> spawnpoints = GetSpawnpoints();
		StartCoroutine(SpawnEntities(spawnpoints));
	}

	private List<Transform> GetSpawnpoints()
	{
		List<Transform> spawnpoints = new List<Transform>();

		// Iterate through the children of the SpawnManager to find spawnpoints
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			// Check if the child's name starts with "Spawnpoint"
			if (child.name.StartsWith("Spawnpoint"))
			{
				spawnpoints.Add(child);
			}
		}

		return spawnpoints;
	}

	private IEnumerator SpawnEntities(List<Transform> spawnpoints)
	{
		// Continue spawning entities until the maximum count is reached
		while (spawnedEntityCount < maxSpawns)
		{
			// Choose a random spawnpoint from the list
			int randomIndex = Random.Range(0, spawnpoints.Count);
			Transform spawnpoint = spawnpoints[randomIndex];

			// Check if an entity should be spawned based on certain conditions
			if (ShouldSpawnEntity())
			{
				// Spawn the entity at the selected spawnpoint
				SpawnEntity(spawnpoint);
				spawnedEntityCount++;
			}

			// Wait for the specified interval before attempting to spawn the next entity
			yield return new WaitForSeconds(spawnInterval);
		}
	}

	private bool ShouldSpawnEntity()
	{
		// Check if the StaminaStats component is present and stamina level is above a threshold
		StaminaStats staminaStats = GetComponent<StaminaStats>();

		if (staminaStats != null && staminaStats.GetStaminaLevel() > 1f)
		{
			return true;
		}

		return false;
	}

	private void SpawnEntity(Transform spawnpoint)
	{
		// Get a random tier for the spawned entity
		SpawnObjectData.Tier randomTier = GetRandomTier();
		// Get a random prefab based on the selected tier
		GameObject prefab = GetRandomPrefab(randomTier, spawnObjectData);
		// Determine the parent transform for the instantiated entity (null if not instantiating as child)
		Transform parentTransform = instantiateAsChild ? spawnpoint : null;

		// Instantiate the entity at the spawnpoint with the specified parent
		GameObject spawnedEntity = Instantiate(prefab, spawnpoint.position, spawnpoint.rotation, parentTransform);

		// Modify the stamina of the spawned entity if a StaminaStats component is present
		StaminaStats staminaStats = spawnedEntity.GetComponent<StaminaStats>();

		if (staminaStats != null)
		{
			staminaStats.ModifyStamina(staminaStats.GetStaminaLevel());
		}

		// Modify the health of the spawned entity if a HealthStats component is present
		HealthStats healthStats = spawnedEntity.GetComponent<HealthStats>();

		if (healthStats != null)
		{
			healthStats.ModifyHealth(50f); // Example: Modify health for the spawned entity
		}

		// Increment the count of spawned entities
		spawnedEntityCount++;
	}

	private SpawnObjectData.Tier GetRandomTier()
	{
		// Get a random tier based on the weights defined in SpawnObjectData
		int totalWeight = spawnObjectData.GetTotalWeight();

		int randomWeight = Random.Range(1, totalWeight + 1);

		return spawnObjectData.GetTierByWeight(randomWeight);
	}

	private GameObject GetRandomPrefab(SpawnObjectData.Tier tier, SpawnObjectData spawnObjectData)
	{
		// Get a random prefab from the specified tier
		GameObject[] prefabs = spawnObjectData.GetPrefabsByTier(tier);
		int randomIndex = Random.Range(0, prefabs.Length);

		if (prefabs[randomIndex] == null)
		{
			// If the randomly chosen prefab is null, find the next lowest tier
			SpawnObjectData.Tier lowerTier = tier - 1;

			// Loop through the tiers until a valid prefab is found
			while (lowerTier >= SpawnObjectData.Tier.Tier1)
			{
				GameObject[] lowerTierPrefabs = spawnObjectData.GetPrefabsByTier(lowerTier);
				List<int> validIndices = new List<int>();

				// Find the indices of valid prefabs in the lower tier
				for (int i = 0; i < lowerTierPrefabs.Length; i++)
				{
					if (lowerTierPrefabs[i] != null)
					{
						validIndices.Add(i);
					}
				}

				if (validIndices.Count > 0)
				{
					// Choose a random index from the valid indices
					randomIndex = validIndices[Random.Range(0, validIndices.Count)];
					// Return the prefab from the lower tier using the selected index
					return lowerTierPrefabs[randomIndex];
				}

				// Move to the next lower tier
				lowerTier--;
			}
		}

		// Return the randomly chosen prefab (either from the original tier or the lower tier)
		return prefabs[randomIndex];
	}
}
