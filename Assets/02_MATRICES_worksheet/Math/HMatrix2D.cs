using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    // creates an empty 3x3 matrix
    public HMatrix2D()
    {
        entries = new float[3, 3];
    }

    // creates a HMatrix2D matrix with the array passed into the constructor
    public HMatrix2D(float[,] multiArray)
    {
        // for every row and column, assign the element of multiarray to the corresponding element in the new HMatrix2D object
        for (int x = 0; x < 3; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                entries[x, y] = multiArray[x, y];
            }
        }
    }

    // creates a new HMatrix 2D matrix with the arguments passed into the constructor
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

    // adding of matrices
    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        // stores the resultant matrix
        HMatrix2D result = new HMatrix2D();

        // for every row and column, add up the corresponding elements of each matrix accordingly
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                result.entries[x, y] = left.entries[x, y] + right.entries[x, y];
            }
        }
        return result;
    }

    // subtracting of matrices
    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        // stores the resultant matrix
        HMatrix2D result = new HMatrix2D();

        // for every row and column, subtract the corresponding elemtns of each matrix accordingly
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                result.entries[x, y] = left.entries[x, y] - right.entries[x, y];
            }
        }
        return result;
    }

    // matrix multiplication with a scalar
    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        // stores the resultant matrix
        HMatrix2D result = new HMatrix2D();

        // for every row and column, multiply the element by the scalar
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
    // multiplication of matrix with vector
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        // hardcoded, takes the elements of every row and multiplies with x and y and z according to their column index
        // elements in column 0 get multiplied with x, elements in column 1 get mutiplied with y, elements in column 2 get multiplied with z
        // later the result of all these multiplications get added together which forms the new element of the resulting HVector2D
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

    // matrix multiplication
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

        // cycles through the elements of the row of the left matrix with the elements in the column of the right matrix, adding them up later in the resulting matrix

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

    // checking for equality of matrices
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        // for every row and column, check if all the corresponding elements are equal
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

    // if not equal
    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        // for every row and column if any element is not equal to its corresponding element, return true which means that it is not equal, else return that it is equal
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (left.entries[x, y] != right.entries[x, y])
                {
                    return true;
                }
            }
        }
        return false;
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

    // setting identity matrix
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

                // if x == y, then set that element of entris[x, y] to 1, if not set to 0
                entries[x, y] = x == y ? 1 : 0;

            }
        }



    }

    // setting the x and y coordinates of the translation matrix
    public void setTranslationMat(float transX, float transY)
    {
        SetIdentity();
        entries[0 ,2] = transX;
        entries[1, 2] = transY;
    }

    // setting the rotation matrix according to the formula, taking in the degree in radian
    public void setRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        entries[0, 0] = Mathf.Cos(rad);
        entries[0, 1] = -Mathf.Sin(rad);
        entries[1, 0] = Mathf.Sin(rad);
        entries[1, 1] = Mathf.Cos(rad);
    }

    //public void setScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}

    // returns the matrix
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
