using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPopulator : MonoBehaviour
{
	public int rowCount = 5;
	public int columnCount = 5;
	public float tileSize = 1f;
	public List<GameObject> tilePrefabs;

	private void Start()
	{
		PopulateGrid();
	}

	private void PopulateGrid()
	{
		if (tilePrefabs.Count == 0)
		{
			Debug.LogWarning("No tile prefabs assigned to the GridPopulator.");
			return;
		}

		Vector3 gridSize = new Vector3(columnCount * tileSize, 0, rowCount * tileSize);
		Vector3 startPosition = transform.position - gridSize / 2f + new Vector3(tileSize / 2f, 0, tileSize / 2f);

		for (int row = 0; row < rowCount; row++)
		{
			for (int col = 0; col < columnCount; col++)
			{
				int randomIndex = Random.Range(0, tilePrefabs.Count);
				GameObject tilePrefab = tilePrefabs[randomIndex];

				Vector3 spawnPosition = startPosition + new Vector3(col * tileSize, 0, row * tileSize);
				GameObject spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);

				spawnedTile.transform.parent = transform;
			}
		}
	}
}