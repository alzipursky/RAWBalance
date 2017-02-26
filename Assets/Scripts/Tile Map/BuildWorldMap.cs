using UnityEngine;
using UnityTileMap;
using System.Collections;
using System.Collections.Generic;

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
    public GameObject lake;
    public GameObject mountainParent;
    public int xLimit = 1;
	public int yLimit = 1;
    private TileMapBehaviour m_tileMapBehaviour;

	private float elapsedTime = 0f;
	private float timeLimit = 7f;
	private bool villageDrawn = false;

	public List<string> names = new List<string>();

	private int indexOfName = 0;

    private void Awake()
    {
        m_tileMapBehaviour = GetComponent<TileMapBehaviour>();
        if (m_tileMapBehaviour == null)
            Debug.LogError("TileMapBehaviour not found");
    }

    // Use this for initialization
    private void Start()
    {
		names.Add ("Curvy");
		names.Add ("Angry");
		names.Add ("Bed");
		names.Add ("Acoustics");
		names.Add ("Breathe");
		names.Add ("Blush");
		names.Add ("Cruel");
		names.Add ("Auspicious");
		names.Add ("Glove");
		names.Add ("Ossified");
		names.Add ("Scorch");
		names.Add ("Hook");
		names.Add ("Toy");
		names.Add ("Freezing");
		names.Add ("Spotted");
		names.Add ("Quick");
		names.Add ("Sticky");
		names.Add ("Madly");
		names.Add ("Bewildered");
		names.Add ("Lively");
		//TODO: Error handling. This won't crash for 60 days of game play

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
        DrawForestatPoint(10f,16f);
        DrawForestatPoint(25f, 25f);
        DrawForestatPoint(2f, 36f);
        DrawLakeatPoint(10f, 10f);
        DrawLakeatPoint(2f, 8f);
        DrawCoalatPoint(35f, 35f);
        DrawCoalatPoint(10f, 47f);
        DrawCoalatPoint(20f, 55f);

		DrawSmallVillageatPoint(22f,22f);

        // Draw a checker pattern
    }

	private void Update()
	{
		if (elapsedTime < timeLimit) 
		{
			elapsedTime += Time.deltaTime;
		} else 
		{
            var point = new Vector3(Random.Range(0, xLimit * 4), Random.Range(0, yLimit * 4));
            var pointOK = false;

			while (!pointOK) 
			{
				foreach (var obj in GameObject.FindObjectsOfType<GameObject>()) {
                    if (obj.activeInHierarchy && obj.GetComponent<Collider>() != null) {


                        var colli = obj.GetComponent<Collider>();

                        var colli_list = obj.GetComponentInParent<Collider>();

                        var bounds = colli_list.bounds;

                        if (bounds.Contains(point))

                        {

                           // int threshold = 5;
                            point = new Vector3(Random.Range(0, xLimit * 3), Random.Range(0, yLimit * 3));
                            //point.x += bounds.max.x + threshold;
                            //point.y += bounds.max.y + threshold;

                            pointOK = false;
                            break;
                        }

						//pointOK = false;

                

                       // break;


                    }
					pointOK = true;
				}
			}

			DrawSmallVillageatPoint(point.x,point.y);
            VillageGrowth();
            //villageDrawn = true;
            elapsedTime = 0f;
			timeLimit *= 2.5f;


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

    private void DrawLakeatPoint(float x, float y)
    {
        var pond = Instantiate(lake);
        pond.transform.position = new Vector3(x, y);

        for (float j = -1f; j < 3f; j += (2f / 3))
        {
            for (float i = 0f; i < 3f; i += (2f / 3))
            {
                Vector3 target = new Vector3(x + i, y + j);
                target.z = 0;
                pond.transform.position = target;
                pond.transform.parent = pond.transform;
                pond.transform.localScale = new Vector3(4f, 4f);
            }
        }


    }

	private void DrawSmallVillageatPoint(float x, float y)
	{
		var village = Instantiate(villageParent);
		village.transform.position = new Vector3(x, y);
		village.GetComponent<Village> ().name = names [indexOfName];
		indexOfName += 1;

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

    private void DrawCoalatPoint(float x, float y)
    {
        var mtn = Instantiate(mountainParent);
        mtn.transform.position = new Vector3(x, y);

        for (float j = 0f; j < 1f; j += (2f / 3))
        {
            for (float i = 0f; i < 1f; i += (2f / 3))
            {
                Vector3 target = new Vector3(x + i, y + j);
                target.z = 0;
                var newCoal = Instantiate(coal);
                newCoal.transform.position = target;
                newCoal.transform.parent = mtn.transform;
                newCoal.transform.localScale = new Vector3(3f, 3f);
            }
        }

    }

    //insert prefab instationtion for coal -> mountain here as forest above

    private void VillageGrowth()
    {
        GameObject[] huts;
        huts = GameObject.FindGameObjectsWithTag("Settlement");

        if (huts.Length >= 60)
        {
            return;
        }

        foreach (var hutter in huts)
        {
            if (hutter.transform.parent != null)
            {
                Vector3 target = new Vector3(hutter.transform.parent.position.x + Random.Range(-3f, 3f), hutter.transform.parent.position.y + Random.Range(-3f, 3f));
                target.z = 0;
                var newhut = Instantiate(hut);
                newhut.transform.position = target;
                newhut.transform.parent = hutter.transform.parent;
                newhut.transform.localScale = new Vector3(3f, 3f);
  
            }
        }
    }
}
