using UnityEngine;
using System.Collections;

public enum MonsterType
{
    GHOST_BLUE,
    GHOST_ORANGE,
    GHOST_RED,
    LENGTH
}

public class Monster : MonoBehaviour
{

    float initialHeight;

    #region Visible Time

    //Can this monster be visible for different lengths of time?
    private bool variableVisibleTime = false;
    public bool VariableVisibleTime
    {
        get { return variableVisibleTime; }
        set { variableVisibleTime = value; }
    }
    //How long the monster is visibsle for (max)
    private float visibleTimeMax = 3;
    public float VisibleTimeMax
    {
        get { return visibleTimeMax; }
        set { visibleTimeMax = value; }
    }

    //How long the monster is visible for (min) Only applies if Variable Visible Time is true
    private float visibleTimeMin;
    public float VisibleTimeMin
    {
        get { return visibleTimeMin; }
        set { visibleTimeMin = value; }
    }

    #endregion

    #region Transition Time

    private bool variableTransitionTime = false;
    public bool VariableTransitionTime
    {
        get { return variableTransitionTime; }
        set { variableTransitionTime = value; }
    }

    private float transitionTimeMax = 2;
    public float TransitionTimeMax
    {
        get { return transitionTimeMax; }
        set { transitionTimeMax = value; }
    }

    private float transitionTimeMin;
    public float TransitionTimeMin
    {
        get { return transitionTimeMin; }
        set { transitionTimeMin = value; }
    }

    #endregion

    private int pointWorth;
    public int PointWorth
    {
        get { return pointWorth; }
        set { pointWorth = value; }
    }
    //The types of monsters this monster can be
    public MonsterType[] possibleTypes;
    //The type of monster this monster currently is
    MonsterType myType;
    public bool disappearing;
    public bool visible;
}