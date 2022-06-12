using System;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEditor;
using UnityEngine;

public class PathSetup : MonoBehaviour
{
    public List<SplineComputer> splines;
    public List<Node> nodes;
    public List<Node> startNodes;

    private void OnDrawGizmosSelected()
    {
        for (var index = 0; index < nodes.Count; index++)
        {
            var node = nodes[index];
            GUI.color = Color.magenta;
            Handles.Label(node.transform.position + Vector3.up + Vector3.left,$"{index}");
        }
    }
}