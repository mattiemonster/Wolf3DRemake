using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    [Header("Scene References")]
    public Camera editorCamera;
    public LevelEditor editor;

    [Header("Properties")]
    public bool acceptInput = true;

    private TileInfo previousObject;
    private Vector3 defaultPoint = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Input polling
    void Update()
    {
        if (!acceptInput) return;

        Ray ray = editorCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        Physics.Raycast(ray, out rayHit);

        Vector3 roundedLoc = new Vector3(Mathf.FloorToInt(rayHit.point.x + 0.5f), 1, Mathf.FloorToInt(rayHit.point.z + 0.5f));
        transform.position = roundedLoc;

        if (Input.GetMouseButton(0))
            Place(roundedLoc, "WallStone");

        if (Input.GetMouseButton(1))
            Remove(roundedLoc);

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            if (previousObject != null)
            {
                Destroy(previousObject.gameObject);
                editor.tiles.Remove(previousObject);
                previousObject = null;
            }
        }
    }

    public void Place(Vector3 location, string prefabName)
    {
        if (location == defaultPoint) return;

        if (Physics.CheckSphere(location, 0.2f))
            return;

        GameObject newObject = Instantiate(Resources.Load(prefabName, typeof(GameObject)), location, Quaternion.identity) as GameObject;
        newObject.name = prefabName;
        TileInfo tile = new TileInfo(location, prefabName, newObject);
        editor.tiles.Add(tile);

        previousObject = tile;
    }

    public void Remove(Vector3 location)
    {
        Collider[] colliders = Physics.OverlapSphere(location, 0.2f);
        if (colliders.Length != 0)
        {
            foreach (Collider collider in colliders)
            {
                editor.tiles.Remove(editor.tiles.Find(item => item.gameObject == collider.gameObject));
                Destroy(collider.gameObject);
            }
        }
        else return;
    }
}
