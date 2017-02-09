using UnityEngine;
using UnityTileMap;

public class BuildWorldMap : MonoBehaviour
{
	public Sprite grass;
	public GameObject water;
	public GameObject coal;
	public GameObject sand;
	public GameObject trees;
	public GameObject forestParent;
	public GameObject hut;
	public GameObject villageParent;
	public int xLimit = 1;
	public int yLimit = 1;
    private TileMapBehaviour m_tileMapBehaviour;

	private float elapsedTime = 0;
	private bool villageDrawn = false;

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
            TileSize = 4f
        };

        // Apply settings, resizing the TileMap
        m_tileMapBehaviour.MeshSettings = meshSettings;
		DrawTileMap();
        DrawForestatPoint(16f,16f);
        DrawForestatPoint(5f, 5f);
        DrawForestatPoint(2f, 16f);

        // Draw a checker pattern
    }

	private void Update()
	{
		if (elapsedTime < 5f || villageDrawn) 
		{
			elapsedTime += Time.deltaTime;
		} else 
		{
            DrawSmallVillageatPoint(22f,22f);
			villageDrawn = true;
			elapsedTime += Time.deltaTime;
		}
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

	private void DrawForestatPoint(float x, float y)
	{
		var forest = Instantiate(forestParent);
		forest.transform.position = new Vector3(x, y);

		for (float j = -1f; j < 3f; j+= (2f / 3)) 
		{
			for (float i = 0f; i < 3f; i += (2f / 3)) {
				Vector3 target = new Vector3(x + i, y + j);
				target.z = 0;
				var tree = Instantiate(trees);
				tree.transform.position = target;
				tree.transform.parent = forest.transform;
                tree.transform.localScale = new Vector3(4f, 4f);
			}
		}
	}

	private void DrawSmallVillageatPoint(float x, float y)
	{
		var village = Instantiate(villageParent);
		village.transform.position = new Vector3(x, y);

		for (float j = 0f; j < 1f; j+= (2f / 3)) 
		{
			for (float i = 0f; i < 1f; i += (2f / 3)) {
				Vector3 target = new Vector3(x + i, y + j);
				target.z = 0;
				var newHut = Instantiate(hut);
				newHut.transform.position = target;
				newHut.transform.parent = village.transform;
                newHut.transform.localScale = new Vector3(3f, 3f);
			}
		}
	}
}
