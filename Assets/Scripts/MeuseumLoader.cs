using UnityEngine;
using System.Collections;

public class MeuseumLoader : MonoBehaviour {
	private int mazeRows, mazeColumns;
	public GameObject wall;
	public GameObject photoHolder;

	private float size;

	private MeuseumCell[,] mazeCells;

	private Texture2D[] tex2darr;

	// Use this for initialization
	void Start () {
		size = wall.transform.localScale.x;
		tex2darr = ImageLoader.initImages();
		mazeRows = 1; 
		mazeColumns = tex2darr.Length;
		initMeuseum();
		shapeMeuseum();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void initMeuseum()
	{

		mazeCells = new MeuseumCell[mazeRows, mazeColumns];

		for (int r = 0; r < mazeRows; r++)
		{
			for (int c = 0; c < mazeColumns; c++)
			{
				mazeCells[r, c] = new MeuseumCell();

				// For now, use the same wall object for the floor!
				mazeCells[r, c].floor = Instantiate(wall, new Vector3(r * size, -(size / 2f), c * size), Quaternion.identity) as GameObject;
				mazeCells[r, c].floor.name = "Floor " + r + "," + c;
				mazeCells[r, c].floor.transform.Rotate(Vector3.right, 90f);

				if (c == 0)
				{
					mazeCells[r, c].westWall = Instantiate(wall, new Vector3(r * size, 0, (c * size) - (size / 2f)), Quaternion.identity) as GameObject;
					mazeCells[r, c].westWall.name = "West Wall " + r + "," + c;
				}

				mazeCells[r, c].eastWall = Instantiate(wall, new Vector3(r * size, 0, (c * size) + (size / 2f)), Quaternion.identity) as GameObject;
				mazeCells[r, c].eastWall.name = "East Wall " + r + "," + c;

				if (r == 0)
				{
					mazeCells[r, c].northWall = Instantiate(wall, new Vector3((r * size) - (size / 2f), 0, c * size), Quaternion.identity) as GameObject;
					mazeCells[r, c].northWall.name = "North Wall " + r + "," + c;
					mazeCells[r, c].northWall.transform.Rotate(Vector3.up * 90f);
				}

				mazeCells[r, c].southWall = Instantiate(wall, new Vector3((r * size) + (size / 2f), 0, c * size), Quaternion.identity) as GameObject;
				mazeCells[r, c].southWall.name = "South Wall " + r + "," + c;
				mazeCells[r, c].southWall.transform.Rotate(Vector3.up * 90f);
			}
		}

		int row = 0, col = 0;

		foreach (Texture2D tex in tex2darr)
		{
			Material frontPlane = new Material(Shader.Find("Diffuse"));

			GameObject ImagePlane = Instantiate(photoHolder, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			ImagePlane.name = "ImageHolder"+col;
			frontPlane.mainTexture = tex;	
			ImagePlane.GetComponent<Renderer>().material = frontPlane;

			Wall wall = mazeCells[row, col].southWall.GetComponent(typeof(Wall)) as Wall;
			wall.AttachPicture(ImagePlane);
			col++;
		}
	}

	private void shapeMeuseum()
	{
		for (int cols = 0; cols < mazeColumns - 1; cols++)
		{
			mazeCells[0, cols].eastWall.SetActive(false);
		}
	}
}
