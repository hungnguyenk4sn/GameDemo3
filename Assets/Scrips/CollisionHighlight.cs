using UnityEngine;

public class CollisionHighlight : MonoBehaviour
{
    public Texture2D baseTexture;
    public Color highlightColor = Color.red;
    private Texture2D textureCopy;

    void Start()
    {
        // Tạo bản sao texture để chỉnh sửa
        textureCopy = Instantiate(baseTexture);
        GetComponent<Renderer>().material.mainTexture = textureCopy;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pushable"))
        {
            Debug.Log("ok");
            foreach (ContactPoint contact in collision.contacts)
            {
                Vector2 pixelUV = GetUVCoordinates(contact);
                PaintTexture(pixelUV, highlightColor);
            }
            textureCopy.Apply();
        }
    }

    Vector2 GetUVCoordinates(ContactPoint contact)
    {
        Renderer rend = contact.otherCollider.GetComponent<Renderer>();
        MeshCollider meshCollider = contact.otherCollider as MeshCollider;
        if (meshCollider == null || meshCollider.sharedMesh == null) return Vector2.zero;

        RaycastHit hit;
        if (Physics.Raycast(contact.point + contact.normal * 0.01f, -contact.normal, out hit))
        {
            if (hit.collider == contact.otherCollider)
            {
                return hit.textureCoord;
            }
        }
        return Vector2.zero;
    }

    void PaintTexture(Vector2 uv, Color color)
    {
        int x = Mathf.FloorToInt(uv.x * textureCopy.width);
        int y = Mathf.FloorToInt(uv.y * textureCopy.height);
        textureCopy.SetPixel(x, y, color);
    }
}
