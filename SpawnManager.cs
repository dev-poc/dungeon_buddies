// Dated this fine day, the 12th of November in the year 2023.
// Hour upon the clock strikes the midnight chime.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] [Tooltip("The temporal span between each ethereal entity's manifestation, measured in seconds.")]
	private float spawnInterval = 1f;
	[SerializeField] [Tooltip("The maximum assemblage of entities to be conjured forth.")]
	private int maxSpawns = 10;
	[SerializeField] [Tooltip("The existing count of entities birthed into this realm.")]
	private int spawnedEntityCount = 0;
	[SerializeField] [Tooltip("The mystical data guiding the conjuration of diverse objects, each endowed with unique tiers.")]
	private SpawnObjectData spawnObjectData;
	[SerializeField] [Tooltip("Invoke true if you desire to materialize spawns as progeny objects.")]
	private bool instantiateAsChild = false;
	[SerializeField] [Tooltip("Invoke true to ensure that a spawnpoint with an existing child object will not spawn another.")]
	private bool singleChildSpawn = false;

	private void Start()
	{
		List<Transform> spawnpoints = GetSpawnpoints();
		StartCoroutine(SpawnEntities(spawnpoints));
	}

	private List<Transform> GetSpawnpoints()
	{
		List<Transform> spawnpoints = new List<Transform>();

		// Traverse the offspring of the SpawnManager to discover locations of manifestation.
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			// Determine if the child's nomenclature commences with the sacred term "Spawnpoint."
			if (child.name.StartsWith("Spawnpoint") && (!singleChildSpawn || child.childCount == 0))
			{
				spawnpoints.Add(child);
			}
		}

		return spawnpoints;
	}

	private IEnumerator SpawnEntities(List<Transform> spawnpoints)
	{
		// Continue summoning entities until the zenith count is attained.
		while (spawnedEntityCount < maxSpawns)
		{
			// Select a random locus of manifestation from the sacred list.
			int randomIndex = Random.Range(0, spawnpoints.Count);
			Transform spawnpoint = spawnpoints[randomIndex];

			// Ascertain if an entity should be summoned based on esoteric conditions.
			if (ShouldSpawnEntity())
			{
				// Conjure the entity at the chosen manifestation point.
				if (SpawnEntity(spawnpoint))
				{
					spawnedEntityCount++;
				}
			}

			// Await the ordained interval before endeavoring to summon the subsequent entity.
			yield return new WaitForSeconds(spawnInterval);
		}
	}

	private bool ShouldSpawnEntity()
	{
		// Ascertain if the StaminaStats component is present and if the stamina essence exceeds a certain threshold.
		StaminaStats staminaStats = GetComponent<StaminaStats>();

		if (staminaStats != null && staminaStats.GetStaminaLevel() > 1f)
		{
			return true;
		}

		return false;
	}

	private bool SpawnEntity(Transform spawnpoint)
	{
		// If singleChildSpawn is true and there is already a child, do not spawn another.
		if (singleChildSpawn && spawnpoint.childCount > 0)
		{
			return false;
		}

		// Acquire a random tier for the manifested entity.
		SpawnObjectData.Tier randomTier = GetRandomTier();
		// Obtain a random vessel based on the chosen tier.
		GameObject prefab = GetRandomPrefab(randomTier, spawnObjectData);
		// Determine the parent vessel for the instantiated entity (null if not siring as offspring).
		Transform parentTransform = instantiateAsChild ? spawnpoint : null;

		// Conjure the entity at the manifestation point with the specified progenitor.
		GameObject spawnedEntity = Instantiate(prefab, spawnpoint.position, spawnpoint.rotation, parentTransform);

		// Modify the stamina of the manifested entity if a StaminaStats component is present.
		StaminaStats staminaStats = spawnedEntity.GetComponent<StaminaStats>();

		if (staminaStats != null)
		{
			staminaStats.ModifyStamina(staminaStats.GetStaminaLevel());
		}

		// Modify the vitality of the manifested entity if a HealthStats component is present.
		HealthStats healthStats = spawnedEntity.GetComponent<HealthStats>();

		if (healthStats != null)
		{
			healthStats.ModifyHealth(50f); // Exempli gratia: Modify vitality for the manifested entity.
		}

		return true;
	}

	private SpawnObjectData.Tier GetRandomTier()
	{
		// Obtain a random tier based on the weights delineated in SpawnObjectData.
		int totalWeight = spawnObjectData.GetTotalWeight();

		int randomWeight = Random.Range(1, totalWeight + 1);

		return spawnObjectData.GetTierByWeight(randomWeight);
	}

	private GameObject GetRandomPrefab(SpawnObjectData.Tier tier, SpawnObjectData spawnObjectData)
	{
		// Obtain a random vessel from the designated tier.
		GameObject[] prefabs = spawnObjectData.GetPrefabsByTier(tier);
		int randomIndex = Random.Range(0, prefabs.Length);

		if (prefabs[randomIndex] == null)
		{
			// If the chosen vessel is null, seek the next inferior tier.
			SpawnObjectData.Tier lowerTier = tier - 1;

			// Traverse the tiers until a valid vessel is uncovered.
			while (lowerTier >= SpawnObjectData.Tier.Tier1)
			{
				GameObject[] lowerTierPrefabs = spawnObjectData.GetPrefabsByTier(lowerTier);
				List<int> validIndices = new List<int>();

				// Ascertain the indices of valid vessels in the inferior tier.
				for (int i = 0; lowerTierPrefabs != null && i < lowerTierPrefabs.Length; i++)
				{
					if (lowerTierPrefabs[i] != null)
					{
						validIndices.Add(i);
					}
				}

				if (validIndices.Count > 0)
				{
					// Elect a random index from the valid indices.
					randomIndex = validIndices[Random.Range(0, validIndices.Count)];
					// Return the vessel from the inferior tier using the chosen index.
					return lowerTierPrefabs[randomIndex];
				}

				// Progress to the next inferior tier.
				lowerTier--;
			}
		}

		// Return the randomly selected vessel (either from the original tier or the inferior tier).
		return prefabs[randomIndex];
	}
}
