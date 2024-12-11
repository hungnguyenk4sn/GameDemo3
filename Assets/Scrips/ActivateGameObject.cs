using UnityEngine;
using UnityEngine.UI; // Cần thiết để thao tác với UI

public class ActivateGameObject : MonoBehaviour
{
    public Button activateButton; // Gán Button từ Editor
    public GameObject targetObject1; // Gán GameObject từ Editor
    public GameObject targetObject2;
    void Start()
    {
        if (activateButton != null)
        {
            // Đăng ký sự kiện click
            activateButton.onClick.AddListener(ActivateTargetObject);
        }
    }

    void ActivateTargetObject()
    {
        if (targetObject1 != null && targetObject2 != null  )
        {
            // Kích hoạt GameObject
            targetObject1.SetActive(true);
            targetObject2.SetActive(true);
            /*Debug.Log($"{targetObject.name} đã được kích hoạt!");*/
        }
    }
}
