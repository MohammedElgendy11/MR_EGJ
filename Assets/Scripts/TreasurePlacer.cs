using UnityEngine;
using Meta.XR.MRUtilityKit;
using System.Linq; // ضروري جداً لاستخدام دالة FirstOrDefault

public class TreasurePlacer : MonoBehaviour
{
    public GameObject treasureBox;

    // اربط هذه الدالة بحدث Scene Loaded في مكون الـ MRUK
    public void PositionBoxOnTable(MRUKRoom room)
    {
        // الطريقة الصحيحة للبحث عن الطاولة في الإصدار الجديد
        var tableAnchor = room.Anchors.FirstOrDefault(a => a.Label == MRUKAnchor.SceneLabels.TABLE);

        if (tableAnchor != null && treasureBox != null)
        {
            // ربط الصندوق بالطاولة لضمان بقائه في نفس المكان (Persistence)
            treasureBox.transform.SetParent(tableAnchor.transform);

            // وضع الصندوق فوق الطاولة (صفر يعني في مركز سطح الطاولة)
            treasureBox.transform.localPosition = Vector3.zero;
            treasureBox.transform.localRotation = Quaternion.identity;

            Debug.Log("تم وضع الكنز بنجاح على الطاولة!");
        }
        else
        {
            Debug.LogWarning("لم يتم العثور على طاولة! هل قمت بتعريفها في الـ Space Setup؟");
        }
    }
}