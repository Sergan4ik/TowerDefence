using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

[RequireComponent(typeof(EntityLink))]
[RequireComponent(typeof(UnityGameView))]
public class ViewAnimator : MonoBehaviour
{
    public Animator animator;
}