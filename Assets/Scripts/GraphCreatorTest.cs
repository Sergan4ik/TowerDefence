using System;
using System.Collections.Generic;
using Dreamteck.Splines.Primitives;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

public class GraphCreatorTest : MonoBehaviour
{
    public PathSetup _pathSetup;
    private List<List<(int , string)>> Paths = new List<List<(int, string)>>();

    private void Start()
    {
        var creator = new GraphCreatorServiceService(_pathSetup);
        Paths = creator.AllPaths;
    }
}