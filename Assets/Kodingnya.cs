using UnityEngine;

public class Kodingnya : MonoBehaviour
{
    public Rigidbody rb;
    public float doronganKedepan = 100f;
    public float gayaSamping = 500f;
    public float gayaVertikal = 500f;
    public Transform kamera; // Tambahkan referensi ke kamera

    void Start()
    {
        Debug.Log("Hello Tayo");
    }

    void FixedUpdate()
    {
        // Mendapatkan arah kamera
        Vector3 arahKamera = kamera.forward;
        Vector3 arahSampingKamera = kamera.right;

        // Mengatur gaya maju-mundur sesuai dengan arah kamera
        if (Input.GetKey("w"))
        {
            rb.AddForce(arahKamera * doronganKedepan * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(-arahKamera * doronganKedepan * Time.deltaTime, ForceMode.VelocityChange);
        }

        // Mengatur gaya kiri-kanan sesuai dengan arah kamera
        if (Input.GetKey("a"))
        {
            rb.AddForce(-arahSampingKamera * gayaSamping * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(arahSampingKamera * gayaSamping * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}




//using UnityEngine;
//
//public class Kodingnya : MonoBehaviour
//{
//    public Rigidbody rb;
//    public float swipeSensitivity = 0.5f;
//    private Vector2 startTouchPosition, endTouchPosition;
//
//    void Start()
//    {
//        Debug.Log("Hello Tayo");
//    }
//
//    void FixedUpdate()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//
//            if (touch.phase == TouchPhase.Began)
//            {
//                startTouchPosition = touch.position;
//            }
//            else if (touch.phase == TouchPhase.Ended)
//            {
//                endTouchPosition = touch.position;
//
//                Vector2 swipeDirection = endTouchPosition - startTouchPosition;
//
//                if (swipeDirection.x > swipeSensitivity)
//                {
//                    rb.AddForce(500 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
//                }
//                else if (swipeDirection.x < -swipeSensitivity)
//                {
//                    rb.AddForce(-500 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
//                }
//                if (swipeDirection.y > swipeSensitivity)
//                {
//                    rb.AddForce(0, 500 * Time.deltaTime, 0, ForceMode.VelocityChange);
//                }
//                else if (swipeDirection.y < -swipeSensitivity)
//                {
//                    rb.AddForce(0, -500 * Time.deltaTime, 0, ForceMode.VelocityChange);
//                }
//            }
//        }
//    }
//}
