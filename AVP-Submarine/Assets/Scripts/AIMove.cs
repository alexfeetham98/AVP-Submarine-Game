﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    private AISpawner m_AIManager;

    private bool m_hasTarget = false;
    private bool m_isTurning;


    private Vector3 m_wayPoint;
    private Vector3 m_lastWaypoint = new Vector3(0f, 0f, 0f);

    private Animator m_animator;
    private float m_speed;

    // Start is called before the first frame update
    void Start()
    {
        m_AIManager = transform.parent.GetComponentInParent<AISpawner>();
        //m_animator = GetComponent<Animator>();

        SetUpNPC();
    }

    void SetUpNPC()
    {
        float m_scale = Random.Range(0.0002f, 0.0006f);
        transform.localScale += new Vector3(m_scale * 1.5f, m_scale, m_scale);
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_hasTarget)
        {
            m_hasTarget = CanFindTarget();
        }
        else
        {
            RotateNPC(m_wayPoint, m_speed);

            transform.position = Vector3.MoveTowards(transform.position, m_wayPoint, m_speed * Time.deltaTime);
        }

        if (transform.position == m_wayPoint)
        {
            m_hasTarget = false;
        }
    }

    bool CanFindTarget(float start = 2f, float end = 3f)
    {
        m_wayPoint = m_AIManager.RandomWaypoint();

        if (m_lastWaypoint == m_wayPoint)
        {
            m_wayPoint = m_AIManager.RandomWaypoint();
            return false;
        }
        else
        {
            m_lastWaypoint = m_wayPoint;

            m_speed = Random.Range(start, end);
            //m_animator.speed = m_speed;
            return true;
        }
    }

    void RotateNPC (Vector3 waypoint, float currentSpeed)
    {
        float TurnSpeed = currentSpeed * Random.Range(2f, 3f);

        Vector3 LookAt = waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookAt), TurnSpeed * Time.deltaTime);
    }
}
