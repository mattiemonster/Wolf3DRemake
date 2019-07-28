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

    [HideInInspector]
    public bool hasPlacedPlayer = false;
    [HideInInspector]
    public Vector3 playerPosition;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
            editor.SelectTile(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            editor.SelectTile(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            editor.SelectTile(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            editor.SelectTile(4);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            editor.SelectTile(5);
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            editor.SelectTile(6);
        else if (Input.GetKeyDown(KeyCode.Alpha7))
            editor.SelectTile(7);
        else if (Input.GetKeyDown(KeyCode.Alpha8))
            editor.SelectTile(8);
        else if (Input.GetKeyDown(KeyCode.Alpha9))
            editor.SelectTile(9);
        else if (Input.GetKeyDown(KeyCode.Alpha0))
            editor.SelectTile(0);
    }

    public void Place(Vector3 location, string prefabName)
    {
        if (editor.mouseOverButton) return;

        if (location == defaultPoint) return;

        if (Physics.CheckSphere(location, 0.2f))
            return;

        if (string.IsNullOrEmpty(editor.GetCurrentPrefab()))
            return;

        string prefab = editor.GetCurrentPrefab();

        if (prefab == "Player")
        {
            if (hasPlacedPlayer)
                Remove(playerPosition);

            prefab = "EditorPlayer";
            playerPosition = location;
            hasPlacedPlayer = true;
        }
        GameObject newObject = Instantiate(Resources.Load(prefab, typeof(GameObject)), location, Quaternion.identity) as GameObject;
        newObject.name = prefab;
        TileInfo tile;
        if (prefab == "EditorPlayer")
        {
            tile = new TileInfo(location, "Player", newObject);
        } else
        {
            tile = new TileInfo(location, prefabName, newObject);
        }
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
                if (playerPosition == location)
                    hasPlacedPlayer = false;
                Destroy(collider.gameObject);
            }
        }
        else return;
    }
}
