using System;
using UnityEngine;
using System.Collections.Generic;

public interface IFoodInfo
{
    public IReadOnlyList<GameObject> Instances { get; }
}
