using UnityEngine;
using Meta.XR.MRUtilityKit;

/// <summary>
/// Add this script to the SAME GameObject that has FindSpawnPositions component
/// This will handle persistent spawning by disabling FindSpawnPositions when a saved position exists
/// </summary>
[RequireComponent(typeof(FindSpawnPositions))]
public class PersistentFindSpawnPositions : MonoBehaviour
{
    //[Header("Persistence Settings")]
    //[SerializeField] private bool usePersistentPosition = true;
    //[SerializeField] private string saveKey = "MRSpawnPos";

    //[Header("Debug")]
    //[SerializeField] private bool showDebugLogs = true;

    //private FindSpawnPositions findSpawnPositions;
    //private GameObject spawnedObject;
    //private bool positionWasSaved = false;

    //void Awake()
    //{
    //    findSpawnPositions = GetComponent<FindSpawnPositions>();

    //    if (usePersistentPosition && HasSavedPosition())
    //    {
    //        // Disable FindSpawnPositions to prevent it from spawning
    //        findSpawnPositions.enabled = false;

    //        if (showDebugLogs)
    //            Debug.Log("[Persistent Spawn] Found saved position, disabling FindSpawnPositions");
    //    }
    //}

    //void Start()
    //{
    //    if (usePersistentPosition && HasSavedPosition())
    //    {
    //        SpawnAtSavedPosition();
    //    }
    //    else
    //    {
    //        // Let FindSpawnPositions do its work, then save the position
    //        StartCoroutine(WaitAndSaveSpawnedPosition());
    //    }
    //}

    //bool HasSavedPosition()
    //{
    //    return PlayerPrefs.HasKey(saveKey + "_X");
    //}

    //void SpawnAtSavedPosition()
    //{
    //    Vector3 position = new Vector3(
    //        PlayerPrefs.GetFloat(saveKey + "_X"),
    //        PlayerPrefs.GetFloat(saveKey + "_Y"),
    //        PlayerPrefs.GetFloat(saveKey + "_Z")
    //    );

    //    Quaternion rotation = new Quaternion(
    //        PlayerPrefs.GetFloat(saveKey + "_RotX"),
    //        PlayerPrefs.GetFloat(saveKey + "_RotY"),
    //        PlayerPrefs.GetFloat(saveKey + "_RotZ"),
    //        PlayerPrefs.GetFloat(saveKey + "_RotW")
    //    );

    //    // Access the spawn object from FindSpawnPositions
    //    // Note: You might need to make the spawnObject field public in FindSpawnPositions
    //    // or use reflection to access it
    //    GameObject prefabToSpawn = GetSpawnPrefab();

    //    if (prefabToSpawn != null)
    //    {
    //        spawnedObject = Instantiate(prefabToSpawn, position, rotation);
    //        positionWasSaved = true;

    //        if (showDebugLogs)
    //            Debug.Log($"[Persistent Spawn] Spawned at saved position: {position}");
    //    }
    //    else
    //    {
    //        Debug.LogError("[Persistent Spawn] Could not find spawn prefab!");
    //    }
    //}

    //System.Collections.IEnumerator WaitAndSaveSpawnedPosition()
    //{
    //    // Wait for FindSpawnPositions to complete
    //    yield return new WaitForSeconds(1f);

    //    // Find the spawned object in the scene
    //    GameObject spawnPrefab = GetSpawnPrefab();
    //    if (spawnPrefab != null)
    //    {
    //        // Look for instances of the prefab
    //        string prefabName = spawnPrefab.name;
    //        GameObject[] allObjects = FindObjectsOfType<GameObject>();

    //        foreach (GameObject obj in allObjects)
    //        {
    //            if (obj.name.Contains(prefabName) && obj != spawnPrefab)
    //            {
    //                spawnedObject = obj;
    //                SavePosition(obj.transform);

    //                if (showDebugLogs)
    //                    Debug.Log($"[Persistent Spawn] Saved new position: {obj.transform.position}");
    //                break;
    //            }
    //        }
    //    }
    //}

    //GameObject GetSpawnPrefab()
    //{
    //    // Try to get the spawn object from FindSpawnPositions using reflection
    //    var field = typeof(FindSpawnPositions).GetField("_spawnObject",
    //        System.Reflection.BindingFlags.NonPublic |
    //        System.Reflection.BindingFlags.Instance);

    //    if (field != null)
    //    {
    //        return field.GetValue(findSpawnPositions) as GameObject;
    //    }

    //    Debug.LogWarning("[Persistent Spawn] Could not access spawn object field");
    //    return null;
    //}

    //void SavePosition(Transform transform)
    //{
    //    if (!usePersistentPosition || positionWasSaved) return;

    //    Vector3 pos = transform.position;
    //    Quaternion rot = transform.rotation;

    //    PlayerPrefs.SetFloat(saveKey + "_X", pos.x);
    //    PlayerPrefs.SetFloat(saveKey + "_Y", pos.y);
    //    PlayerPrefs.SetFloat(saveKey + "_Z", pos.z);

    //    PlayerPrefs.SetFloat(saveKey + "_RotX", rot.x);
    //    PlayerPrefs.SetFloat(saveKey + "_RotY", rot.y);
    //    PlayerPrefs.SetFloat(saveKey + "_RotZ", rot.z);
    //    PlayerPrefs.SetFloat(saveKey + "_RotW", rot.w);

    //    PlayerPrefs.Save();
    //    positionWasSaved = true;
    //}

    //[ContextMenu("Clear Saved Position")]
    //public void ResetSavedPosition()
    //{
    //    PlayerPrefs.DeleteKey(saveKey + "_X");
    //    PlayerPrefs.DeleteKey(saveKey + "_Y");
    //    PlayerPrefs.DeleteKey(saveKey + "_Z");
    //    PlayerPrefs.DeleteKey(saveKey + "_RotX");
    //    PlayerPrefs.DeleteKey(saveKey + "_RotY");
    //    PlayerPrefs.DeleteKey(saveKey + "_RotZ");
    //    PlayerPrefs.DeleteKey(saveKey + "_RotW");
    //    PlayerPrefs.Save();
    //    positionWasSaved = false;

    //    if (showDebugLogs)
    //        Debug.Log("[Persistent Spawn] Saved position cleared!");
    //}
}