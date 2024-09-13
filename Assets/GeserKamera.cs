using UnityEngine;

public class GeserKamera : MonoBehaviour
{
    public Transform Cube;
    public Vector3 offset = new Vector3(0, 5, -10); // Offset dari Cube
    public float mouseSensitivity = 100f; // Sensitivitas rotasi mouse
    public float maxVertikalAngle = 80f; // Maksimal sudut rotasi vertikal
    public float jarakMinimumKeTanah = 1f; // Jarak minimum kamera ke tanah
    public LayerMask lapisanTanah; // Layer untuk mendeteksi tanah

    private float rotasiY = 0f; // Rotasi horizontal (kiri-kanan)
    private float rotasiX = 0f; // Rotasi vertikal (atas-bawah)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Mengunci kursor ke tengah layar
        Cursor.visible = false; // Menyembunyikan kursor
    }

    void LateUpdate()
    {
        // Mengambil input mouse untuk rotasi horizontal dan vertikal
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Menambahkan rotasi berdasarkan input mouse
        rotasiY += mouseX;
        rotasiX -= mouseY; // Mengubah arah karena pergeseran mouse ke atas harus mengurangi rotasi vertikal

        // Mengatur batas rotasi vertikal
        rotasiX = Mathf.Clamp(rotasiX, -maxVertikalAngle, maxVertikalAngle);

        // Mengatur posisi kamera dengan offset dari Cube
        Vector3 posisiKameraIdeal = Cube.position + Quaternion.Euler(rotasiX -20, rotasiY, 0) * offset;

        // Cek jarak kamera ke tanah
        Ray ray = new Ray(posisiKameraIdeal, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, lapisanTanah))
        {
            // Jika jarak kamera ke tanah kurang dari jarak minimum, atur posisi kamera
            if (hit.distance < jarakMinimumKeTanah)
            {
                posisiKameraIdeal = Cube.position + Quaternion.Euler(rotasiX -20, rotasiY, 0) * offset;
                posisiKameraIdeal.y = hit.point.y + jarakMinimumKeTanah;
            }
        }

        // Mengatur posisi dan rotasi kamera
        transform.position = posisiKameraIdeal;
        transform.rotation = Quaternion.Euler(rotasiX, rotasiY, 0f);
    }
}
