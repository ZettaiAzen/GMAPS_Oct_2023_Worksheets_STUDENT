// Uncomment this whole file.

using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);
        //Translate(1, 1);
        Rotate(-45);
    }

    // translation function
    void Translate(float x, float y)
    {
        //getting identity matrix so that the the translation matrix can be converted to a 3x3 matrix to be combined later for transformation matrix
        transformMatrix.SetIdentity();
        transformMatrix.setTranslationMat(x, y);
        Transform();

        pos = transformMatrix * pos;
    }

    // rotation function
    void Rotate(float angle)
    {
        //getting identity matrix so that the the rotation matrix can be converted to a 3x3 matrix to be combined later for transformation matrix
        transformMatrix.SetIdentity();

        // setting the translation matrix in order to bring the object back to origin for rotation
        toOriginMatrix.setTranslationMat(0-pos.x, 0-pos.y);
        // setting the translation matrix in order to bring the object back to its original position
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        // setting the rotation matrix of the object
        rotateMatrix.setRotationMat(angle);

        // multiplying the matrices together starting from right to left
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        Transform();
    }

    // multiplies the transformation matrix with our object's HVector2d's verticles and then puts them back into Unity's own vertice system
    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
