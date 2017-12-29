using UnityEngine;
using Valve.VR.InteractionSystem;
using System.Collections;

public class ShatterMesh : MonoBehaviour
{
    public Material wireframeMaterial;

    public bool shatterOnDestroy = true;

    public int nthTriangle = 10;
    public float explosivePowerModifier = 1f;

    public void Shatter()
    {
        SkinnedMeshRenderer skin = GetComponent<SkinnedMeshRenderer>();

        if (skin)
            ShatterSkinned(skin);
        else
            ShatterStandard(GetComponent<MeshFilter>(), GetComponent<MeshRenderer>());
    }

    private void ShatterSkinned(SkinnedMeshRenderer SMR)
    {
        Mesh M = SMR.sharedMesh;
        Vector3[] verts = M.vertices;
        Vector3[] normals = M.normals;
        Vector2[] uvs = M.uv;
        for (int submesh = 0; submesh < M.subMeshCount; submesh++)
        {
            int[] indices = M.GetTriangles(submesh);
            for (int i = 0; i < indices.Length; i += 3 * (nthTriangle + Random.Range(0, 2)))
            {
                Vector3[] newVerts = new Vector3[3];
                Vector3[] newNormals = new Vector3[3];
                Vector2[] newUvs = new Vector2[3];
                for (int n = 0; n < 3; n++)
                {
                    int index = indices[i + n];
                    newVerts[n] = verts[index];
                    if (uvs.Length > 0)
                        newUvs[n] = uvs[index];
                    newNormals[n] = normals[index];
                }
                Mesh mesh = new Mesh();
                mesh.vertices = newVerts;
                mesh.normals = newNormals;
                mesh.uv = newUvs;

                mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };

                GameObject GO = new GameObject("Triangle " + (i / 3));
                GO.layer = 2;
                GO.transform.localScale = transform.localScale;
                GO.transform.position = transform.position;
                GO.transform.rotation = transform.rotation;
                GO.AddComponent<MeshRenderer>().material = SMR.material;
                GO.AddComponent<MeshFilter>().mesh = mesh;
                GO.AddComponent<BoxCollider>();
                {
                    GO.AddComponent<Rigidbody>().AddExplosionForce(1000f * explosivePowerModifier, GO.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), 20f);
                }

                GameObject wireframe = new GameObject("Wireframe");
                wireframe.transform.parent = GO.transform;
                wireframe.transform.localPosition = Vector3.zero;
                wireframe.transform.localRotation = new Quaternion();
                wireframe.transform.localScale = Vector3.one;
                wireframe.AddComponent<MeshRenderer>().material = wireframeMaterial;
                wireframe.AddComponent<MeshFilter>().mesh = mesh;

                Destroy(GO, 5 + Random.Range(0.0f, 5.0f));
            }
        }
        SMR.enabled = false;
    }

    private void ShatterStandard(MeshFilter MF, MeshRenderer MR)
    {
        Mesh M = MF.mesh;
        Vector3[] verts = M.vertices;
        Vector3[] normals = M.normals;
        Vector2[] uvs = M.uv;
        for (int submesh = 0; submesh < M.subMeshCount; submesh++)
        {
            int[] indices = M.GetTriangles(submesh);
            for (int i = 0; i < indices.Length; i += 3 * (nthTriangle + Random.Range(0, 2)))
            {
                Vector3[] newVerts = new Vector3[3];
                Vector3[] newNormals = new Vector3[3];
                Vector2[] newUvs = new Vector2[3];
                for (int n = 0; n < 3; n++)
                {
                    int index = indices[i + n];
                    newVerts[n] = verts[index];
                    if (uvs.Length > 0)
                        newUvs[n] = uvs[index];
                    newNormals[n] = normals[index];
                }
                Mesh mesh = new Mesh();
                mesh.vertices = newVerts;
                mesh.normals = newNormals;
                mesh.uv = newUvs;

                mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };

                GameObject GO = new GameObject("Triangle " + (i / 3));
                GO.layer = 2;
                GO.transform.localScale = transform.localScale;
                GO.transform.position = transform.position;
                GO.transform.rotation = transform.rotation;
                GO.AddComponent<MeshRenderer>().material = MR.material;
                GO.AddComponent<MeshFilter>().mesh = mesh;
                GO.AddComponent<BoxCollider>();
                {
                    GO.AddComponent<Rigidbody>().AddExplosionForce(1000f * explosivePowerModifier, GO.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), 20f);
                }

                GameObject wireframe = new GameObject("Wireframe");
                wireframe.transform.parent = GO.transform;
                wireframe.transform.localPosition = Vector3.zero;
                wireframe.transform.localRotation = new Quaternion();
                wireframe.transform.localScale = this.transform.lossyScale;//Vector3.one;
                wireframe.AddComponent<MeshRenderer>().material = wireframeMaterial;
                wireframe.AddComponent<MeshFilter>().mesh = mesh;

                Destroy(GO, 5 + Random.Range(0.0f, 5.0f));
            }
        }
        MR.enabled = false;
    }

    private void OnDestroy()
    {
        if(shatterOnDestroy)
            Shatter();
    }
}