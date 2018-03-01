using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    void Start()
    {
        m_Offset = transform.position - m_Target.position;
    }

    public void Move(Vector3 movement)
    {
        //Vector3 target_pos = m_Target.position + m_Offset;
        transform.position += movement;//Vector3.Lerp(transform.position, target_pos, m_Smoothness * Time.deltaTime);

        var rotation = Quaternion.LookRotation(m_Target.position - transform.position);
        transform.rotation = rotation;
    }

    public void Promote()
    {
        // promote camera to display the result of your run(compare with standard)
        m_Promote = true;
    }

    private void Update()
    {
        if (m_Promote)
        {
            transform.position = Vector3.SmoothDamp(transform.position, m_FinalTarget.position, ref m_Velocity, m_Smoothness);
            var rotation = Quaternion.LookRotation(Vector3.zero - transform.position);
            transform.rotation = rotation;
        }
    }

    //
    public Transform m_Target;

    private bool m_Promote = false;
    private Vector3 m_Offset;

    public Transform m_FinalTarget;
    public float m_Smoothness = 0.3f;

    private Vector3 m_Velocity = Vector3.zero;
}
