using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color lineColor;

    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = lineColor;

        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != transform)
                nodes.Add(pathTransforms[i]);
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 cirrentNode = nodes[i].position;
            Vector3 previosNode = Vector3.zero;

            if (i > 0)
                previosNode = nodes[i - 1].position;
            else if (i == 0 && nodes.Count > 1)
                previosNode = nodes[nodes.Count - 1].position;

            Gizmos.DrawLine(previosNode, cirrentNode);
            Gizmos.DrawSphere(cirrentNode, 0.1f);
        }
    }
}
