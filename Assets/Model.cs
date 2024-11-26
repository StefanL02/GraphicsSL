
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{

    internal List<Vector3Int> faces;
    List<Vector3Int> texture_index_list;
    internal List<Vector3> vertices;
    List<Vector2> texture_coordinates;
    List<Vector3> normals;



    public Model()
    {
        vertices = new List<Vector3>();
        addvertices();
        faces = new List<Vector3Int>();
   
        texture_coordinates = new List<Vector2>();
        addTextureCoordinates();
        texture_coordinates = adjustToRelative(texture_coordinates);
        normals = new List<Vector3>();
        texture_index_list = new List<Vector3Int>();

        addfaces();
    }

    private List<Vector2> adjustToRelative(List<Vector2> texture_coordinates)
    {
      List<Vector2> new_coords = new List<Vector2>();
        foreach (Vector2 v in texture_coordinates) { new_coords.Add(new Vector2(v.x/512,1- v.y/512)); }

        return new_coords;
    }

    private void addTextureCoordinates()
    {
        texture_coordinates.Add(new Vector2(123,288)); // 0
        texture_coordinates.Add(new Vector2(225, 288)); // 1
        texture_coordinates.Add(new Vector2(145, 265)); // 2
        texture_coordinates.Add(new Vector2(225, 265)); // 3
        texture_coordinates.Add(new Vector2(145, 145)); // 4
        texture_coordinates.Add(new Vector2(123, 125)); // 5

        texture_coordinates.Add(new Vector2(340, 291)); // 6
        texture_coordinates.Add(new Vector2(441, 291)); // 7
        texture_coordinates.Add(new Vector2(340, 268)); // 8
        texture_coordinates.Add(new Vector2(421, 268)); // 9
        texture_coordinates.Add(new Vector2(421, 148)); // 10
        texture_coordinates.Add(new Vector2(441, 128)); // 11

        texture_coordinates.Add(new Vector2(195, 343)); // 12
        texture_coordinates.Add(new Vector2(296, 343)); // 13
        texture_coordinates.Add(new Vector2(195, 382)); // 14
        texture_coordinates.Add(new Vector2(296, 382)); // 15



    }

    private void addfaces()
    {
        //Front face
        faces.Add(new Vector3Int(0, 1, 3));  texture_index_list.Add(new Vector3Int(0,1,3)); normals.Add(new Vector3(0, 0, 1));
        faces.Add(new Vector3Int(0, 3, 2));  texture_index_list.Add(new Vector3Int(0,3,2)); normals.Add(new Vector3(0, 0, 1));

      
        faces.Add(new Vector3Int(0, 2, 4));  texture_index_list.Add(new Vector3Int(0,2,4)); normals.Add(new Vector3(0, 0, 1));
        faces.Add(new Vector3Int(0, 4, 5));  texture_index_list.Add(new Vector3Int(0,4,5)); normals.Add(new Vector3(0, 0, 1));

        //Back face
        faces.Add(new Vector3Int(6, 9, 7)); texture_index_list.Add(new Vector3Int(7, 8, 6)); normals.Add(new Vector3(0, 0, -1));
        faces.Add(new Vector3Int(6, 8, 9)); texture_index_list.Add(new Vector3Int(7, 9, 8)); normals.Add(new Vector3(0, 0, -1));
        faces.Add(new Vector3Int(6, 10, 8)); texture_index_list.Add(new Vector3Int(7, 10, 9)); normals.Add(new Vector3(0, 0, -1));
        faces.Add(new Vector3Int(6, 11, 10)); texture_index_list.Add(new Vector3Int(7, 11, 10)); normals.Add(new Vector3(0, 0, -1));
      
         //Side faces
         //Rigt bottom
         faces.Add(new Vector3Int(3, 1, 7)); texture_index_list.Add(new Vector3Int(12, 14, 15)); normals.Add(new Vector3(1, 0, 0));
         faces.Add(new Vector3Int(3, 7, 9)); texture_index_list.Add(new Vector3Int(12, 15, 13)); normals.Add(new Vector3(1, 0, 0));
        
         //Middle
         faces.Add(new Vector3Int(2, 8 , 10)); texture_index_list.Add(new Vector3Int(12, 14, 15)); normals.Add(new Vector3(1, 0, 0));
         faces.Add(new Vector3Int(2, 10, 4)); texture_index_list.Add(new Vector3Int(12, 15, 13)); normals.Add(new Vector3(1, 0, 0));
        
         //Far left
         faces.Add(new Vector3Int(0, 11, 6)); texture_index_list.Add(new Vector3Int(12, 15, 13)); normals.Add(new Vector3(1, 0, 0));
         faces.Add(new Vector3Int(0, 5, 11)); texture_index_list.Add(new Vector3Int(12, 14, 15)); normals.Add(new Vector3(1, 0, 0));
        
         //Top faces
         //Bottom
         faces.Add(new Vector3Int(0, 7, 1)); texture_index_list.Add(new Vector3Int(12, 15, 13)); normals.Add(new Vector3(0, 1, 0));
         faces.Add(new Vector3Int(0, 6, 7)); texture_index_list.Add(new Vector3Int(12, 14, 15)); normals.Add(new Vector3(0, 1, 0));

        //Top middle
        faces.Add(new Vector3Int(2, 9, 8)); texture_index_list.Add(new Vector3Int(12, 15, 13)); normals.Add(new Vector3(0, 1, 0));
        faces.Add(new Vector3Int(2, 3, 9)); texture_index_list.Add(new Vector3Int(12, 14, 15)); normals.Add(new Vector3(0, 1, 0));
         

         //Top top
         faces.Add(new Vector3Int(5, 4, 10)); texture_index_list.Add(new Vector3Int(12, 14, 15)); normals.Add(new Vector3(0, 1, 0));
        faces.Add(new Vector3Int(5, 10, 11)); texture_index_list.Add(new Vector3Int(12, 15, 13)); normals.Add(new Vector3(0, 1, 0));
       

    }

    private void addvertices()
    {
        vertices.Add(new Vector3(-2, -2, -1)); // 0

        vertices.Add(new Vector3(3, -2, -1)); // 1

        vertices.Add(new Vector3(-1, -1, -1)); // 2

        vertices.Add(new Vector3(3, -1, -1)); // 3

        vertices.Add(new Vector3(-1, 5, -1)); // 4

        vertices.Add(new Vector3(-2, 6, -1)); //5

        vertices.Add(new Vector3(-2, -2, 1)); //6

        vertices.Add(new Vector3(3, -2, 1)); //7

        vertices.Add(new Vector3(-1, -1, 1)); //8

        vertices.Add(new Vector3(3, -1, 1)); //9

        vertices.Add(new Vector3(-1, 5, 1)); //10

        vertices.Add(new Vector3(-2, 6, 1)); //11





    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();

        for (int i = 0; i < faces.Count; i++)
        {
            Vector3 normal_for_face = normals[i];

            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); text_coords.Add(texture_coordinates[texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); text_coords.Add(texture_coordinates[texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); text_coords.Add(texture_coordinates[texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray();
        mesh_filter.mesh = mesh;

        return newGO;
    }


}

