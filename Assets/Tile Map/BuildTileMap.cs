using UnityEngine;
using UnityTileMap;

public class BuildTileMap : MonoBehaviour
{
	public Sprite sprite;
    private TileMapBehaviour m_tileMapBehaviour;

    private void Awake()
    {
        m_tileMapBehaviour = GetComponent<TileMapBehaviour>();
        if (m_tileMapBehaviour == null)
            Debug.LogError("TileMapBehaviour not found");
    }

    // Use this for initialization
    private void Start()
    {
        // Create settings
        var meshSettings = new TileMeshSettings
        {
            // The number of tiles on the x axis
            TilesX = 100,
            // The number of tiles on the y axis
            TilesY = 100,
            // The number of pixels along each axis on a tile
            TileResolution = 16,
            // The size of one tile in Unity units
            TileSize = 1f
        };

        // Apply settings, resizing the TileMap
        m_tileMapBehaviour.MeshSettings = meshSettings;

        // Draw a checker pattern
        for (var i =0; i < 100; i++)
        {
            for (var j = 0; j < 100; j++)
            {
				m_tileMapBehaviour.PaintTile(i, j, sprite);
            }
        }
    }
}
