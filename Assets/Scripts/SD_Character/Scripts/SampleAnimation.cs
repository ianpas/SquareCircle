using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAnimation : MonoBehaviour
{
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_LastPosition = transform.position;
    }

    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");


        Trace();
        Move(h, v);
        Animating(h, v);
    }

    //

    private void Trace()
    {
        m_DistanceTravelled += Vector3.Distance(transform.position, m_LastPosition);

        if (m_DistanceTravelled >= 7)
        {
            if (m_FootprintPosition == Vector3.zero)
            {
                m_FootprintPosition = transform.position;
            }
        }

        if (m_DistanceTravelled >= 8.5)
        {
            m_DistanceTravelled = 0;

            Transform footprint = null;

            if (m_Records.Count == 0)
            {
                footprint = Instantiate(m_FinalPrefab);
            }
            else
            {
                footprint = Instantiate(m_FootprintPrefab);
            }

            footprint.transform.position = m_FootprintPosition;
            m_Records.Add(Vector3.Distance(m_FootprintPosition, Vector3.zero));
            m_FootprintPosition = Vector3.zero;

        }
        m_LastPosition = transform.position;


    }

    private void Move(float h, float v)
    {
        var is_run = h != 0 || v != 0;
        if (!is_run)
            return;

        m_Movement.Set(h, 0, v);

        Quaternion q = Quaternion.LookRotation(m_Movement);
        m_Movement = m_Movement.normalized * m_Speed * Time.deltaTime;

        m_Rigidbody.MoveRotation(q);
        m_Rigidbody.MovePosition(transform.position + m_Movement);

        m_Camera.Move(m_Movement);

    }

    private void Animating(float h, float v)
    {
        var is_run = h != 0 || v != 0;
        m_Animator.SetBool("IsRun", is_run);

        var is_jump = Input.GetKeyUp("space");
        m_Animator.SetBool("IsJump", is_jump);
    }

    public void StopRunning()
    {
        m_Animator.SetBool("IsRun", false);
    }

    //
    public float m_Speed = 6;
    public CameraFollow m_Camera;

    public Transform m_FootprintPrefab;
    public Transform m_FinalPrefab;

    //
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private Vector3 m_Movement;// direction of movement

    private Vector3 m_LastPosition;
    private float m_DistanceTravelled;
    private Vector3 m_FootprintPosition = Vector3.zero;

    public List<float> m_Records = new List<float>();
}