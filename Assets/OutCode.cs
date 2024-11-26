using System;
using UnityEngine;

public class OutCode
{
    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;

    public OutCode(Vector2 point)
    {
        up = point.y > 1;
        down = point.y < -1;
        left = point.x < -1;
        right = point.x > 1;
    }

    public OutCode(bool upIn, bool downIn, bool leftIn, bool rightIn)
    {
        up = upIn;
        down = downIn;
        left = leftIn;
        right = rightIn;
    }

    public void displayOutCode()
    {
        string outputString = (up ? "1" : "0") + (down ? "1" : "0") + (left ? "1" : "0") + (right ? "1" : "0");
        Debug.Log(outputString);
    }

    
    public static OutCode operator +(OutCode left, OutCode right)
    {
        return new OutCode(
            left.up || right.up,
            left.down || right.down,
            left.left || right.left,
            left.right || right.right
        );
    }

    
    public static OutCode operator *(OutCode left, OutCode right)
    {
        return new OutCode(
            left.up && right.up,
            left.down && right.down,
            left.left && right.left,
            left.right && right.right
        );
    }

    
    public static bool operator ==(OutCode left, OutCode right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;

        return left.up == right.up &&
               left.down == right.down &&
               left.left == right.left &&
               left.right == right.right;
    }

    public static bool operator !=(OutCode left, OutCode right)
    {
        return !(left == right);
    }

    public override bool Equals(object obj)
    {
        if (obj is OutCode other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (up, down, left, right).GetHashCode();
    }
}

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>


    

