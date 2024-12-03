using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;

public class GraphicsPipeLine : MonoBehaviour
{
    Renderer ScreenRender;

    Model myModel;
    Texture2D screenTexture;
    StreamWriter sw;
    private float angle;
    Vector2 a2, b2, c2;
    Vector2 A, B;
    Vector2 a_t, A_t, B_t, b_t, c_t;
    public Texture2D texture_file;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ScreenGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ScreenRender = ScreenGO.GetComponent<Renderer>();
        ScreenGO.transform.up = Vector3.back;
        screenTexture = new Texture2D(1024, 1024);
        ScreenRender.material.mainTexture = screenTexture;
        myModel = new Model();
        /* List<Vector2Int> points = Bresh(new Vector2Int(0, 0), new Vector2Int(1020, 1020));
         foreach(Vector2Int point in points)
         screenTexture.SetPixel(point.x, point.y, Color.red);
         screenTexture.Apply(); */


        sw = new StreamWriter("NumberLog.txt");
     
        List<Vector4> verts = convertToHomg(myModel.vertices);



        

        
      


        /*

        sw.WriteLine("Vertices");
        writeVertsToFile(verts);
        
 
        myModel.CreateUnityGameObject(); 
        Vector3 axis = (new Vector3(17, 4, 4)).normalized;
        Matrix4x4 rotationMatrix =
            Matrix4x4.TRS(Vector3.zero,
                        Quaternion.AngleAxis(-14, axis),
                        Vector3.one);

        sw.WriteLine("Rotation Matrix");
        writeMatrixToFile(rotationMatrix);
        
        List<Vector4> imageAfterRotation =
            applyTransformation(verts, rotationMatrix);

        sw.WriteLine("Image After Rotation");
        writeVertsToFile(imageAfterRotation);
        

        //Scale Matrix
        Matrix4x4 scaleMatrix =
            Matrix4x4.TRS(new Vector3(0, 0, 0),
            Quaternion.identity,
           new Vector3(6, 1, 4));

        sw.WriteLine("Scale Matrix");
        writeMatrixToFile(scaleMatrix);
        

        List<Vector4> imageAfterScale =
            applyTransformation(imageAfterRotation, scaleMatrix);
        sw.WriteLine("Image After Scale");
        writeVertsToFile(imageAfterScale);


        //Translation Matrix
        Matrix4x4 translationMatrix =
            Matrix4x4.TRS(new Vector3(1, -2, 5),
            Quaternion.identity,
           new Vector3(1, 1, 1));

        sw.WriteLine("Translation Matrix");
        writeMatrixToFile(translationMatrix);

        List<Vector4>imageAfterTranslation =
            applyTransformation(imageAfterScale, translationMatrix);
        sw.WriteLine("Image After Translation");
        writeVertsToFile(imageAfterTranslation);


        //Single Matrix of Transforms
        Matrix4x4 singleMatrixOfTransforms = translationMatrix * scaleMatrix * rotationMatrix;

        sw.WriteLine("Single Matrix of Transformations");
        writeMatrixToFile(singleMatrixOfTransforms);

        List<Vector4> imageSingleMatrixOfTransforms =
            applyTransformation(verts, singleMatrixOfTransforms);
        sw.WriteLine("Image After Single Matrix of Transformations");
        writeVertsToFile(imageSingleMatrixOfTransforms);


        //Viewing Matrix
        Matrix4x4 viewingMatrix=
           Matrix4x4.LookAt(new Vector3(19, 7, 54),
           new Vector3(4, 6, 4),new Vector3(5, 4, 17).normalized);

        sw.WriteLine("Viewing Matrix");
        writeMatrixToFile(viewingMatrix);

        List<Vector4> imageAfterViewingMatrix =
            applyTransformation(imageAfterTranslation, viewingMatrix);
        sw.WriteLine("Image After Viewing Matrix");
        writeVertsToFile(imageAfterViewingMatrix);


        //Projection Matrix
        Matrix4x4 projectionMatrix=
            Matrix4x4.Perspective(90, 1, 1, 1000);

        sw.WriteLine("Projection Matrix");
        writeMatrixToFile(projectionMatrix);

        List<Vector4> imageAfterProjectionMatrix =
            applyTransformation(imageAfterViewingMatrix, projectionMatrix);
        sw.WriteLine("Image After Projection Matrix");
        writeVertsToFile(imageAfterProjectionMatrix);


        //Single Matrix for everything
        Matrix4x4 singleMatrixForEverything = projectionMatrix*viewingMatrix* translationMatrix * 
            scaleMatrix * rotationMatrix;
        sw.WriteLine("Single Matrix for Everyting");
        writeMatrixToFile(singleMatrixForEverything);

        List<Vector4> imageSingleMatrixForEverything =
            applyTransformation(verts, singleMatrixForEverything);
        sw.WriteLine("Image After Single Matrix For Everything");
        writeVertsToFile(imageSingleMatrixForEverything);



        sw.Close();
        


        OutCode o1 = new OutCode(new Vector2(0.5f, 1.0f));
        OutCode o2 = new OutCode(new Vector2(2.0f, 0f));
        o1.displayOutCode();
        o2.displayOutCode();
        (o1+o2).displayOutCode();

        */
       // print(Bresh(new Vector2Int(12, 31), new Vector2Int(18, 35)));

        //List<Vector2Int> points = Bresh(new Vector2Int(0, 7), new Vector2Int(10, 20));
       // print(points);
    }
       


    private void writeVertsToFile(List<Vector4> verts)
    {
        foreach (Vector4 v in verts)
        { sw.WriteLine(v.x + " , " + v.y + " , " + v.z + " , " +v.w); }
    }
    private List<Vector4> convertToHomg(List<Vector3> vertices)
    {
        List<Vector4> output = new List<Vector4>();
        foreach (Vector3 v in vertices)
        {
            output.Add(new Vector4(v.x, v.y, v.z, 1.0f));
        }
        return output;
    }
    private List<Vector4> applyTransformation
        (List<Vector4> verts, Matrix4x4 tranformMatrix)
    {
        List<Vector4> output = new List<Vector4>();
        foreach (Vector4 v in verts)
        { output.Add(tranformMatrix * v); }

        return output;

    }

    private void writeMatrixToFile(Matrix4x4 matrix)
    {
        for (int i = 0; i < 4; i++)
        { 
                sw.WriteLine(matrix.GetRow(i).x + " , " + matrix.GetRow(i).y + " , " + matrix.GetRow(i).z + " , " + matrix.GetRow(i).w);
            
        } 
    }
    public bool LineClip(ref Vector2 start, ref Vector2 end)
    {
        
        OutCode startOutcode = new OutCode(start);
        OutCode endOutcode = new OutCode(end);
        OutCode inScreenOutCode = new OutCode(false, false, false, false); 

        
        if (startOutcode + endOutcode == inScreenOutCode)
            return true;

        
        if (startOutcode * endOutcode != inScreenOutCode)
            return false;

        
        if (startOutcode != inScreenOutCode)
        {
            if (startOutcode.up)
            {
                start = Intersect(start, end, 0); 
            }
            else if (startOutcode.down)
            {
                start = Intersect(start, end, 1); 
            }
            else if (startOutcode.left)
            {
                start = Intersect(start, end, 2); 
            }
            else if (startOutcode.right)
            {
                start = Intersect(start, end, 3); 
            }

            
            return LineClip(ref start, ref end);
        }

        
        return LineClip(ref end, ref start);
    }

    Vector2 Intersect(Vector2 start, Vector2 end, int edge)
    {

        float m = (end.y - start.y) / (end.x - start.x);
        float c = start.y - m * start.x;

        switch (edge)
        {
            case 0: //up y=1
                return new Vector2((1 - c) / m, 1);
            case 1: // down y=-1
                return new Vector2(-(1 - c) / m, -1);
            case 2: //left x= -1
                return new Vector2(-1, m * (-1) + c);
            default: //right x=1
                return new Vector2(1, m + c);

        }

    }

    List<Vector2Int> Bresh (Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> output = new List<Vector2Int>();
        output.Add(start);
        int dx = end.x - start.x;

        if (dx < 0)

            return Bresh(end, start);
        
        int dy = end.y - start.y;

        if (dy < 0)

            return NegY(Bresh(NegY(start), NegY(end)));

        int pos = 2 * dy;
        int neg = 2 * (dy - dx);

        if (dy > dx)

            return SwapXY(Bresh(SwapXY(start), SwapXY(end)));

        int p = 2 * dy - dx;

        int y = start.y;
        int x = start.x;

      while (x< end.x)
        {
            x++;
            if (p < 0)
            {
                p+= pos;
            }
            else
            {
                p+= neg;
                y++;
            }

            output.Add(new Vector2Int(x, y));
        }

        return output;
    }

    private Vector2Int SwapXY(Vector2Int point)
    {
        return new Vector2Int(point.y , point.x);
    }

    private List<Vector2Int> SwapXY(List<Vector2Int> vector2Ints)
    {
        List<Vector2Int> output = new List<Vector2Int>();
        foreach (Vector2Int v in vector2Ints)
            output.Add(SwapXY(v));
        return output;
    }

    private List<Vector2Int> NegY(List<Vector2Int> vector2Ints)
    {
        List<Vector2Int> output = new List<Vector2Int>();
        foreach (Vector2Int v in vector2Ints)
            output.Add(NegY(v));
        return output;
    }

    private Vector2Int NegY(Vector2Int point)
    {
        return new Vector2Int(point.x,-point.y);
    }


    private void process(Vector4 start4d, Vector4 end4d, EdgeTable edgeTable)
    {
        Vector2 start = project(start4d);
        Vector2 end = project(end4d);

        // Clip the line
        if (LineClip(ref start, ref end))
        {
            // Need to draw
            Vector2Int startPix = pixelize(start);
            Vector2Int endPix = pixelize(end);
            List<Vector2Int> points = Bresh(startPix, endPix);
            //setPixels(points);
            edgeTable.Add(points);
        }
    }


     Vector2Int pixelize(Vector2 point)
    {
        //cast to int
        return new Vector2Int((int)MathF.Round((point.x + 1) * 1023 / 2), (int)MathF.Round((point.y+1) * 1023 / 2));
    }

     Vector2 project(Vector4 point)
    {
        return new Vector2(point.x/point.z,point.y/point.z);
    }

     void setPixels(List<Vector2Int> points)
    {
        foreach(Vector2Int v in points)
        {
            screenTexture.SetPixel(v.x, v.y, Color.red);
        }
    }

    

    

    private void DrawScanLines(EdgeTable edgeTable)
    {
        foreach(var item in edgeTable.edgeTable)
        {
            int y = item.Key;
            int xMin = item.Value.start;
            int xMax = item.Value.end;

            for(int x= xMin; x <= xMax; x++)
            {
                Color col = GetColorFromTexture(x,y);
                screenTexture.SetPixel(x, y, col);
            }
        }
    }

    private Color GetColorFromTexture(int x_p, int y_p) 
    {
        float x = x_p - a2.x;
        float y = y_p - a2.y;
        float r =(x*B.y - y*B.x)/(A.x*B.y-A.y*B.x);
        float s =(A.x*y - x*A.y)/(A.x*B.y-A.y*B.x);

        Vector2 texture_point = a_t + r * A_t + s * B_t;
       // texture_point = new Vector2(texture_point.x *512, texture_point.y*512);
       
        Color color = texture_file.GetPixel((int)texture_point.x,512 - (int)texture_point.y);
        return color;

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(screenTexture);

        screenTexture = new Texture2D(1024, 1024);
        ScreenRender.material.mainTexture = screenTexture;
        angle += 1;
        Matrix4x4 M = Matrix4x4.TRS(new Vector3(0, 0, -10), Quaternion.AngleAxis(angle, (new Vector3(1,1,1)).normalized), Vector3.one);
        Matrix4x4 Mrot = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.AngleAxis(angle, Vector3.right), Vector3.one);
        Matrix4x4 Super = Mrot * M;
        List<Vector4> newVerts = applyTransformation(convertToHomg(myModel.vertices), M);

        for (int i = 0; i <myModel.faces.Count; i++)
        {
            Vector3Int face = myModel.faces[i];
            Vector3Int texture = myModel.texture_index_list[i];

            a_t = myModel.texture_coordinates[texture.x];
            b_t = myModel.texture_coordinates[texture.y];
            c_t = myModel.texture_coordinates[texture.z];
            a_t = convertRelativeTexture(a_t);
            b_t = convertRelativeTexture(b_t);
            c_t = convertRelativeTexture(c_t);


            Vector3 a = newVerts[face.x]; // newVerts[face.y] - newVerts[face.x];
            Vector3 b = newVerts[face.y]; //newVerts[face.z] - newVerts[face.y];
            Vector3 c = newVerts[face.z];
             a2 = pixelize( project(a));
             b2 = pixelize( project(b));
             c2 = pixelize( project(c));
             A = b2 - a2;
             B = c2 - a2;

            A_t = b_t - a_t; 
            B_t = c_t - a_t;

            if  (Vector3.Cross(b2-a2, c2-b2).z<0)
            {
                EdgeTable edgeTable = new EdgeTable();
                process(newVerts[face.x], newVerts[face.y], edgeTable);
                process(newVerts[face.y], newVerts[face.z], edgeTable);
                process(newVerts[face.z], newVerts[face.x], edgeTable);

                DrawScanLines(edgeTable);
            }
        }

        // Apply texture
        screenTexture.Apply();
    }

    private Vector2 convertRelativeTexture(Vector2 v)
    {
     return new Vector2(v.x * 512,512 -  v.y *512);
    }
}