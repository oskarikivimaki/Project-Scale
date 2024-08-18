using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamZoom : MonoBehaviour
{
    private CinemachineFreeLook freelookCam;
    private CinemachineFreeLook.Orbit[] originalOrbits;

    [Range(-3.0f,2.0f)]
    public float minZoom = 1.0f;

    [Range(0.0f,2.0f)]
    public float maxZoom = 2.0f;

    [AxisStateProperty]
    public AxisState zAxis = new AxisState(0, 1, false, true, 50f, 0.1f, 0.1f, "Mouse ScrollWheel", false);

    // Start is called before the first frame update
    void Start()
    {
        freelookCam = GetComponentInChildren<CinemachineFreeLook>();
        if (freelookCam != null)
        {
            originalOrbits = new CinemachineFreeLook.Orbit[freelookCam.m_Orbits.Length];

            for (int i = 0; i < originalOrbits.Length; i++)
            {
                originalOrbits[i].m_Height = freelookCam.m_Orbits[i].m_Height;
                originalOrbits[i].m_Radius = freelookCam.m_Orbits[i].m_Radius;
                print(freelookCam.m_Orbits[i].m_Radius);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (originalOrbits != null)
        {
            zAxis.Update(Time.deltaTime);
            float zoomScale = Mathf.Lerp(minZoom, maxZoom, zAxis.Value);

            for (int i = 0;i < originalOrbits.Length; i++)
            {
                freelookCam.m_Orbits[i].m_Height = originalOrbits[i].m_Height * zoomScale;
                freelookCam.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius * zoomScale;
            }
        }
    }
}
