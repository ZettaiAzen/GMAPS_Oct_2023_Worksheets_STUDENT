using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        entries = new float[3, 3];
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int x = 0; x < 3; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                entries[x, y] = multiArray[x, y];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        // Second row
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        // Third row
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                result.entries[x, y] = left.entries[x, y] + right.entries[x, y];
            }
        }
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                result.entries[x, y] = left.entries[x, y] - right.entries[x, y];
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                result.entries[x, y] = left.entries[x, y] * scalar;
            }
        }
        return result;
    }

    // Note that the second argument is a HVector2D object
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D(
            left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h,
            left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h
        );
    }

    //// Note that the second argument is a HMatrix2D object
    ////
    //public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    //{
    //    return new HMatrix2D
    //    (
    //        /* 
    //            00 01 02    00 xx xx
    //            xx xx xx    10 xx xx
    //            xx xx xx    20 xx xx
    //            */
    //        left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

    //        /* 
    //            00 01 02    xx 01 xx
    //            xx xx xx    xx 11 xx
    //            xx xx xx    xx 21 xx
    //            */
    //        left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

    //    // and so on for another 7 entries
    //);
    //}

    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        // creating a new HMatrix2D object to store the result
        HMatrix2D result = new HMatrix2D();

        // stores the size of the left matrix
        int leftRow = 3;
        int leftColumn = 3;

        // stores the size of the right matrix
        int rightRow = 3;
        int rightColumn = 3;

        // basically cycles through the matrices to multiply them

        // you can think of the for loops like gears, the less nested the loop is,
        // the less it is run.

        // since the result matrix is only storing the value after all the multiplication
        // and addition of the different elements of the two matrices being multiplied
        // has happened, the index that we are looking at for the results matrix is
        // not changed as much/as often. 

        // everytime we move to a new cell of the result matrix, we move to a new column
        // to the right (+1) until the last column.
        // then we will move down a row (+1)

        // so from there we can see that the column has to change more times before the
        // row gets changed. So the for loop with j is inside of the i for loop, meaning that
        // j gets changed more, so we will put it in the column segment of the result matrix
        // i is then put to the row segment of the result matrix. result.entries[i, j]

        // same concept goes with the left matrix.
        // after every multiplication, we move to the next column of that row until the
        // last column.
        // then after all the columns have been looked through, that total addition result gets
        // added to the result matrix and the row of the left matrix increases/moves down
        // so since the row of left matrix and the addition of 

        for (int i = 0; i < leftRow; i++)
        {
            for (int j = 0; j< rightColumn; j++)
            {
                for (int k = 0; k < rightRow; k++)
                {
                    result.entries[i, j] += left.entries[i, k] * right.entries[k, j];
                }
            }
        }

        return result;

    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (left.entries[x, y] != right.entries[x, y])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (left.entries[x, y] == right.entries[x, y])
                {
                    return false;
                }
            }
        }
        return true;
    }

    //public override bool Equals(object obj)
    //{
    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float getDeterminant()
    //{
    //    return // your code here
    //}

    public void SetIdentity()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                //if (x == y)
                //{
                //    entries[x, y] = 1;
                //}
                //else
                //{
                //    entries[x, y] = 0;
                //}

                entries[x, y] = x == y ? 1 : 0;

            }
        }



    }

    //public void setTranslationMat(float transX, float transY)
    //{
    //    // your code here
    //}

    //public void setRotationMat(float rotDeg)
    //{
    //    // your code here
    //}

    //public void setScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
