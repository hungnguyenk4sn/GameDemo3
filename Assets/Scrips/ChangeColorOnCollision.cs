using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
    public GameObject ground; // Nền
    public Color collisionColor = Color.red; // Màu khi va chạm
    private Texture2D texture;
    private Renderer groundRenderer;

    void Start()
    {
        if (ground == null)
        {
            Debug.LogError("Ground object is not assigned!");
            return;
        }

        // Lấy Renderer và khởi tạo texture
        groundRenderer = ground.GetComponent<Renderer>();
        if (groundRenderer != null)
        {
            texture = new Texture2D(256, 256);
            groundRenderer.material.mainTexture = texture;

            // Khởi tạo màu đen cho toàn bộ texture
            Color[] colors = new Color[texture.width * texture.height];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.black;
            }
            texture.SetPixels(colors);
            texture.Apply();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (texture == null || groundRenderer == null) return;

        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 collisionPoint = contact.point; // Điểm va chạm
            Debug.Log("Collision Point: " + collisionPoint);

            Vector2 pixelUV = GetTextureCoord(contact, groundRenderer);

            int x = Mathf.FloorToInt(pixelUV.x * texture.width);
            int y = Mathf.FloorToInt(pixelUV.y * texture.height);

            // Đổi màu vùng quanh điểm va chạm
            int radius = 5; // Bán kính đổi màu
            for (int dx = -radius; dx <= radius; dx++)
            {
                for (int dy = -radius; dy <= radius; dy++)
                {
                    int px = x + dx;
                    int py = y + dy;

                    if (px >= 0 && px < texture.width && py >= 0 && py < texture.height)
                    {
                        texture.SetPixel(px, py, collisionColor);
                    }
                }
            }
            texture.Apply(); // Áp dụng thay đổi
        }
    }

    private Vector2 GetTextureCoord(ContactPoint contact, Renderer renderer)
    {
        // Chuyển đổi điểm va chạm sang tọa độ UV
        Vector3 localPoint = renderer.transform.InverseTransformPoint(contact.point);
        Vector3 size = renderer.bounds.size;

        float u = (localPoint.x / size.x) + 0.5f; // Chuyển vị trí X sang UV
        float v = (localPoint.z / size.z) + 0.5f; // Chuyển vị trí Z sang UV (trường hợp nền phẳng)
        return new Vector2(u, v);
    }
}
