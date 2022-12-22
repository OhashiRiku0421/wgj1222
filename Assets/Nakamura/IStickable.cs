using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public interface IStickable
{
    /// <summary> this.transform.position </summary>
    public IObservable<Vector2> OnSticked { get; }
}
