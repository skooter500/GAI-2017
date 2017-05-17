using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Utilities
{
    public const float TWO_PI = Mathf.PI * 2.0f;

    public static float DegreesToRads(float degrees)
    {
        return degrees * Mathf.Deg2Rad;
    }

    public static float Map(float value, float r1, float r2, float m1, float m2)
    {
        float dist = value - r1;
        float range1 = r2 - r1;
        float range2 = m2 - m1;
        return m1 + ((dist / range1) * range2);
    }
}
