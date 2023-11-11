using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPopulator : MonoBehaviour
{
	// Kapow! Let's set up some parameters for our dynamic grid!
	public int rowCount = 5; // Number of rows in our fantastic grid
	public int columnCount = 5; // Number of columns in our marvelous grid
	public float tileSize = 1f; // Size of each magnificent tile
	public List<GameObject> tilePrefabs; // Different types of incredible tile prefabs

	private void Start()
	{
		// Time to unleash the creativity and populate the grid!
		PopulateGrid();
	}

	private void OnDrawGizmos()
	{
		// Drawing a vibrant wireframe rectangle around the grid for extra pizzazz
		Vector3 gridSize = new Vector3(columnCount * tileSize, 0, rowCount * tileSize);
		Vector3 startPosition = transform.position - gridSize / 2f + new Vector3(tileSize / 2f, 0, tileSize / 2f);
		Gizmos.color = Color.cyan; // Let's make it pop with a cool color

		// Draw the wire cube with the corrected offset
		Gizmos.DrawWireCube(startPosition + gridSize / 2f - new Vector3(tileSize / 2f, 0, tileSize / 2f), gridSize);
	}

	private void PopulateGrid()
	{
		// Oh no! Did we forget to bring the tile prefabs to the party?
		if (tilePrefabs.Count == 0)
		{
			Debug.LogWarning("No tile prefabs assigned to the GridPopulator. Let the tile celebration begin!");
			return;
		}

		// Time to shine and fill the grid with incredible tiles!
		Vector3 gridSize = new Vector3(columnCount * tileSize, 0, rowCount * tileSize);
		Vector3 startPosition = transform.position - gridSize / 2f + new Vector3(tileSize / 2f, 0, tileSize / 2f);

		for (int row = 0; row < rowCount; row++)
		{
			for (int col = 0; col < columnCount; col++)
			{
				// Choosing a random tile prefab from our stash of wonders
				int randomIndex = Random.Range(0, tilePrefabs.Count);
				GameObject tilePrefab = tilePrefabs[randomIndex];

				// Finding the perfect spot to place the tile and let the magic happen
				Vector3 spawnPosition = startPosition + new Vector3(col * tileSize, 0, row * tileSize);

				// Time to bring our creation to life and make it a part of the grand tile assembly!
				GameObject spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);

				// Making the tile a part of our creative endeavor by parenting it to the grid
				spawnedTile.transform.parent = transform;
			}
		}
	}
}
