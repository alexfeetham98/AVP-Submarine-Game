using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes //Types of movement paths
    {
        linear,
        loop
    }

    public PathTypes PathType;
    public int movementDirection = 1;
    public int movingTo = 0; 
    public Transform[] PathSequence;

    void Update()
    {

    }

    public void OnDrawGizmos()
    {
        //Make sure there are two points in sequence
        if (PathSequence == null || PathSequence.Length < 2)
        {
            return;
        }

        //Loop through all of the points in the sequence of points
        for(var i=1; i < PathSequence.Length; i++)
        {
            //Draw a line between the points
            Gizmos.DrawLine(PathSequence[i - 1].position, PathSequence[i].position);
        }

        if(PathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length-1].position);
        }
    }

    //GetNextPathPoint() returns the transform component of the next point in our path
    public IEnumerator<Transform> GetNextPathPoint()
    {
        //Make sure there are two points in sequence
        if (PathSequence == null || PathSequence.Length <1)
        {
            yield break;
        }

        while(true)
        {
            //Return the current point in PathSequence and wait for next call of enumerator
            yield return PathSequence[movingTo]; 

            //If there is only one point exit the coroutine
            if(PathSequence.Length == 1)
            {
                continue;
            }

            //If Linear path move from start to end then end to start then repeat
            if (PathType == PathTypes.linear)
            {
                if (movingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (movingTo >= PathSequence.Length - 1)
                {
                    movementDirection = -1;
                }
            }

            movingTo = movingTo + movementDirection;  

            if(PathType == PathTypes.loop)
            {
                if (movingTo >= PathSequence.Length)
                {
                    movingTo = 0;
                }

                if (movingTo < 0)
                {
                    movingTo = PathSequence.Length - 1;
                }
            }
        }
    }
}
