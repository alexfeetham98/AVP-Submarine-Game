using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        MoveTowards,
        LerpTowards
    }

    public MovementType Type = MovementType.MoveTowards;
    public MovementPath MyPath;
    public float Speed = 1;
    public float MaxDistanceToGoal = .1f;

    private IEnumerator<Transform> pointInPath;

    public void Start()
    {
        //Make sure there is a path assigned
        if (MyPath == null)
        {
            Debug.LogError("No Movement Path", gameObject);
            return;
        }

        //Sets up a reference to an instance of the coroutine GetNextPathPoint
        pointInPath = MyPath.GetNextPathPoint();
        pointInPath.MoveNext();

        //Make sure there is a point to move to
        if (pointInPath.Current == null)
        {
            Debug.LogError("No points in path", gameObject);
            return;
        }

        //Set the position of this object to the position of our starting point
        transform.position = pointInPath.Current.position;
    }
     
    public void Update()
    {
        //Validate there is a path with a point in it
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        if (Type == MovementType.MoveTowards)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                                    pointInPath.Current.position,
                                    Time.deltaTime * Speed);
        }
        else if (Type == MovementType.LerpTowards) 
        {
            transform.position = Vector3.Lerp(transform.position,
                                                pointInPath.Current.position,
                                                Time.deltaTime * Speed);
        }

        //Check to see if you are close enough to the next point to start moving to the following one
        var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal) //If you are close enough
        {
            pointInPath.MoveNext(); //Get next point in MovementPath
        }
    }
}
