using System;
using System.Collections.Generic;
using Dreamteck.Splines;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class PathSetup : MonoBehaviour
{
    public List<SplineComputer> splines;
    public List<Node> nodes;
    public List<Node> startNodes;
    
    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        for (var index = 0; index < nodes.Count; index++)
        {
            var node = nodes[index];
            GUI.color = Color.magenta;
            Handles.Label(node.transform.position + Vector3.up + Vector3.left,$"{index}");
        }
    }
    #endif
}