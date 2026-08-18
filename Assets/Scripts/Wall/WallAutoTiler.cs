using UnityEngine;

/// <summary>
/// Attach this script to a Cube (GameObject > 3D Object > Cube).
/// It automatically splits the cube into 3 submeshes (X-face, Y-face, Z-face),
/// each with its own Material instance whose Tiling is computed from the
/// object's actual size — so the texture always keeps its correct aspect
/// ratio, without stretching, even when the box's three edges have different
/// lengths. textureScaleMultiplier lets you zoom the pattern in or out
/// uniformly across all faces, independent of the box size.
/// </summary>
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
[ExecuteAlways] // Lets you preview the result directly in the Editor, no Play mode needed
public class WallAutoTiler : MonoBehaviour
{
    [Header("Source material (shared texture reused across all 6 faces)")]
    [Tooltip("The material you want tiled across the wall")]
    public Material sourceMaterial;

    [Header("Texture size adjustment")]
    [Tooltip("Multiplies the computed tiling on every face. Values > 1 make the texture repeat more (pattern looks smaller). Values < 1 make it repeat less (pattern looks larger). Does not affect aspect ratio — all faces stay in sync.")]
    [Min(0.01f)]
    public float textureScaleMultiplier = 1f;

    [Header("Options")]
    [Tooltip("Automatically refresh tiling whenever Scale changes in the Editor")]
    public bool autoUpdateInEditor = true;

    private Vector3 lastScale;
    private float lastTextureScaleMultiplier;
    private Material matX, matY, matZ;

    void OnEnable()
    {
        ApplyTiling();
    }

    void Update()
    {
        // In the Editor, auto-detect when you drag Scale or Texture Scale Multiplier in the Inspector
        if (autoUpdateInEditor && !Application.isPlaying)
        {
            if (transform.localScale != lastScale || !Mathf.Approximately(textureScaleMultiplier, lastTextureScaleMultiplier))
            {
                ApplyTiling();
            }
        }
    }

    [ContextMenu("Apply Tiling Now")]
    public void ApplyTiling()
    {
        if (sourceMaterial == null)
        {
            Debug.LogWarning($"[WallAutoTiler] sourceMaterial is not assigned on {gameObject.name}", this);
            return;
        }

        MeshFilter mf = GetComponent<MeshFilter>();
        MeshRenderer mr = GetComponent<MeshRenderer>();

        // Ensure the mesh has 3 submeshes (Unity's default Cube only has 1 submesh)
        Mesh workingMesh = SplitCubeIntoThreeSubmeshes(mf.sharedMesh);
        mf.sharedMesh = workingMesh;

        // Actual world-space size = localScale (since the base Cube is a 1x1x1 unit mesh)
        Vector3 size = transform.localScale;

        // Create 3 separate material instances (never modify the shared source material directly)
        if (matX == null) matX = new Material(sourceMaterial);
        if (matY == null) matY = new Material(sourceMaterial);
        if (matZ == null) matZ = new Material(sourceMaterial);

        matX.name = sourceMaterial.name + "_XFace";
        matY.name = sourceMaterial.name + "_YFace";
        matZ.name = sourceMaterial.name + "_ZFace";

        // Left/right faces (normal along X): visible edges are Z (width) and Y (height)
        matX.mainTextureScale = new Vector2(size.z, size.y) * textureScaleMultiplier;

        // Top/bottom faces (normal along Y): visible edges are X (length) and Z (width)
        matY.mainTextureScale = new Vector2(size.x, size.z) * textureScaleMultiplier;

        // Front/back faces (normal along Z): visible edges are X (length) and Y (height)
        matZ.mainTextureScale = new Vector2(size.x, size.y) * textureScaleMultiplier;

        mr.sharedMaterials = new Material[] { matX, matY, matZ };

        lastScale = size;
        lastTextureScaleMultiplier = textureScaleMultiplier;
    }

    /// <summary>
    /// Unity's default Cube mesh only has 1 submesh (24 vertices, 36 indices for 6 faces).
    /// This method splits it into 3 submeshes grouped by face normal axis (X/Y/Z)
    /// so each group can use its own Material.
    /// </summary>
    private Mesh SplitCubeIntoThreeSubmeshes(Mesh source)
    {
        if (source == null)
        {
            Debug.LogError("[WallAutoTiler] MeshFilter has no mesh assigned.", this);
            return null;
        }

        // If the mesh has already been processed (already has 3 submeshes), reuse it instead of rebuilding every frame
        if (source.subMeshCount == 3 && source.name.EndsWith("_Tiled"))
            return source;

        Mesh mesh = Instantiate(source);
        mesh.name = source.name + "_Tiled";

        Vector3[] normals = mesh.normals;
        int[] originalTriangles = mesh.triangles;

        var trisX = new System.Collections.Generic.List<int>();
        var trisY = new System.Collections.Generic.List<int>();
        var trisZ = new System.Collections.Generic.List<int>();

        // Walk each triangle and classify it by the normal of its first vertex
        for (int i = 0; i < originalTriangles.Length; i += 3)
        {
            int i0 = originalTriangles[i];
            Vector3 n = normals[i0];

            float ax = Mathf.Abs(n.x);
            float ay = Mathf.Abs(n.y);
            float az = Mathf.Abs(n.z);

            if (ax >= ay && ax >= az)
            {
                trisX.Add(originalTriangles[i]);
                trisX.Add(originalTriangles[i + 1]);
                trisX.Add(originalTriangles[i + 2]);
            }
            else if (ay >= ax && ay >= az)
            {
                trisY.Add(originalTriangles[i]);
                trisY.Add(originalTriangles[i + 1]);
                trisY.Add(originalTriangles[i + 2]);
            }
            else
            {
                trisZ.Add(originalTriangles[i]);
                trisZ.Add(originalTriangles[i + 1]);
                trisZ.Add(originalTriangles[i + 2]);
            }
        }

        mesh.subMeshCount = 3;
        mesh.SetTriangles(trisX, 0);
        mesh.SetTriangles(trisY, 1);
        mesh.SetTriangles(trisZ, 2);

        return mesh;
    }

    void OnDestroy()
    {
        // Clean up runtime-created material instances to avoid leaks when the object is destroyed
        if (Application.isPlaying)
        {
            if (matX != null) Destroy(matX);
            if (matY != null) Destroy(matY);
            if (matZ != null) Destroy(matZ);
        }
    }
}