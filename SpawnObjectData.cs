using UnityEngine;

[CreateAssetMenu(fileName = "SpawnsData", menuName = "Custom/Spawn Object Data")]
public class SpawnObjectData : ScriptableObject
{
	public enum Tier
	{
		Tier1,
		Tier2,
		Tier3,
		Tier4
	}

	[SerializeField] private int tier1Weight = 1000;
	[SerializeField] private int tier2Weight = 100;
	[SerializeField] private int tier3Weight = 10;
	[SerializeField] private int tier4Weight = 1;

	public int GetWeight(Tier tier)
	{
		switch (tier)
		{
		case Tier.Tier1:
			return tier1Weight;
		case Tier.Tier2:
			return tier2Weight;
		case Tier.Tier3:
			return tier3Weight;
		case Tier.Tier4:
			return tier4Weight;
		default:
			return tier1Weight;
		}
	}

	[SerializeField] private GameObject[] tier1Spawns;
	[SerializeField] private GameObject[] tier2Spawns;
	[SerializeField] private GameObject[] tier3Spawns;
	[SerializeField] private GameObject[] tier4Spawns;

	public GameObject[] GetSpawns(Tier tier)
	{
		switch (tier)
		{
		case Tier.Tier1:
			return tier1Spawns;
		case Tier.Tier2:
			return tier2Spawns;
		case Tier.Tier3:
			return tier3Spawns;
		case Tier.Tier4:
			return tier4Spawns;
		default:
			return tier1Spawns;
		}
	}

	[SerializeField] private GameObject[] tier1DeathDrops;
	[SerializeField] private GameObject[] tier2DeathDrops;
	[SerializeField] private GameObject[] tier3DeathDrops;
	[SerializeField] private GameObject[] tier4DeathDrops;

	public GameObject[] GetDeathDrops(Tier tier)
	{
		switch (tier)
		{
		case Tier.Tier1:
			return tier1DeathDrops;
		case Tier.Tier2:
			return tier2DeathDrops;
		case Tier.Tier3:
			return tier3DeathDrops;
		case Tier.Tier4:
			return tier4DeathDrops;
		default:
			return tier1DeathDrops;
		}
	}

	public int GetTotalWeight()
	{
		return tier1Weight + tier2Weight + tier3Weight + tier4Weight;
	}

	public Tier GetTierByWeight(int weight)
	{
		if (weight <= tier1Weight)
			return Tier.Tier1;
		else if (weight <= tier1Weight + tier2Weight)
			return Tier.Tier2;
		else if (weight <= tier1Weight + tier2Weight + tier3Weight)
			return Tier.Tier3;
		else
			return Tier.Tier4;
	}

	public GameObject[] GetPrefabsByTier(Tier tier)
	{
		switch (tier)
		{
		case Tier.Tier1:
			return tier1Spawns;
		case Tier.Tier2:
			return tier2Spawns;
		case Tier.Tier3:
			return tier3Spawns;
		case Tier.Tier4:
			return tier4Spawns;
		default:
			return tier1Spawns;
		}
	}
}