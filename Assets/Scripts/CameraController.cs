using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    private readonly float panSpeed = 10f;
    private readonly float panBorderThicknes = 10f;

    private readonly float scrollSpeed = 5f;

    private readonly float minZ = -12f;
    private readonly float maxZ = -4f;

    private readonly float minXY = -5f;
    private readonly float maxXY = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { doMovement = !doMovement; }

        if (!doMovement) { return; }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThicknes)
        {
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThicknes)
        {
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThicknes)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThicknes)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.z -= scroll * -100 * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, minXY, maxXY);
        pos.y = Mathf.Clamp(pos.y, minXY, maxXY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
