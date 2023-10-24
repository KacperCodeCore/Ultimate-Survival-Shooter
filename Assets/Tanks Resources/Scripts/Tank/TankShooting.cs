using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    public void Fire(float launchForce, float fireRate)
    {
        if (_timer >= fireRate)
        {
            _timer = 0;

            // Create an instance of the shell and store a reference to it's rigidbody.
            Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            // Set the shell's velocity to the launch force in the fire position's forward direction.
            shellInstance.velocity = launchForce * m_FireTransform.forward;
        }
    }
}
