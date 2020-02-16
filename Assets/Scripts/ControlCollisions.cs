using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControlCollisions {
    private static int numCollisions = 0; 
    public static void incNumCollisions () {
        numCollisions++;
    }
    public static int getNumCollisions () {
        return numCollisions;
    }
}

