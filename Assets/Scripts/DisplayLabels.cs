using Meta.XR.MRUtilityKit;
using TMPro;
using UnityEngine;

public class DisplayLabels : MonoBehaviour
{

    public Transform rayStartPoint;
    public float rayLength = 5f;
    public MRUKAnchor.SceneLabels labelFilters;

    public TextMeshPro debugText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        bool hasHit = room.Raycast(ray, rayLength, LabelFilter.FromEnum(labelFilters), out RaycastHit hit, out MRUKAnchor anchor);

        if (hasHit)
        {
            Vector3 hitPoint = hit.point;
            Vector3 hitNormal = hit.normal;
            string label = anchor.AnchorLabels[0];
            debugText.transform.position = hitPoint;
            debugText.transform.rotation = Quaternion.LookRotation(-hitNormal);
            debugText.text = "ANCHOR : " + label;

        }
    }
}
