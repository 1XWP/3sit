using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Grid : MonoBehaviour {

    public enum GridType {XbyY}
    public GridType gridType;
    public enum Orientation {TopLeft}
    public Orientation orientation;
    public bool createGrid = false;
    public bool clearGrid = false;
    public List<GameObject> slots = new List<GameObject>();
    public int XCoords;
    public int YCoords;
    public int XSpacing;
    public int YSpacing;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ClearGrid();
        CreateGrid();
    }

    void ClearGrid()
    {
        if (clearGrid)
        {
            clearGrid = false;
            for(int i = 0; i<slots.Count; i++)
            {
                DestroyImmediate(slots[i]);
            }
            slots.Clear();
        }

    }

    void CreateGrid()
    {
        if (createGrid)
        {
            createGrid = false;
            int index = 0;
            for (int y = 0; y < YCoords; y++)
            {
                for (int x = 0; x < XCoords; x++)
                {
                    GameObject gameObject = new GameObject("Slot" + index.ToString());
                    index++;
                    gameObject.transform.position = new Vector3;
                    slots.Add(gameObject);
                }
            }
        }
    }
}
