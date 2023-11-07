using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{

    //private HMatrix2D mat = new HMatrix2D();
    HMatrix2D mat1 = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
    HMatrix2D mat2 = new HMatrix2D(2, 3, 4, 5, 6, 2, 3, 5, 4);
    HMatrix2D resultMat;
    HVector2D vec1 = new HVector2D(2, 3);
    HVector2D resultVec = new HVector2D();

    // Start is called before the first frame update
    void Start()
    {
        //mat.SetIdentity();
        //mat.Print();
        resultMat = mat1 * mat2;
        resultMat.Print();

        resultVec = mat1 * vec1;
        resultVec.Print();
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
