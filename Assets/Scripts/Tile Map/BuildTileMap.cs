using UnityEngine;
using UnityTileMap;

public class BuildTileMap : MonoBehaviour
{
	public Sprite grass;
	public Sprite water;
	public Sprite coal;
	public Sprite sand;
	public Sprite forest;
	public int xLimit = 100;
	public int yLimit = 100;
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
			TilesX = xLimit,
            // The number of tiles on the y axis
            TilesY = yLimit,
            // The number of pixels along each axis on a tile
            TileResolution = 16,
            // The size of one tile in Unity units
            TileSize = 1f
        };

        // Apply settings, resizing the TileMap
        m_tileMapBehaviour.MeshSettings = meshSettings;
		DrawTileMap();
        // Draw a checker pattern
    }

	private void DrawTileMap()
	{
		for (var x = 0; x < xLimit; x++)
		{
			for (var y = 0; y < yLimit; y++)
			{
				m_tileMapBehaviour.PaintTile(x, y, grass);
			}
		}
	}
}
