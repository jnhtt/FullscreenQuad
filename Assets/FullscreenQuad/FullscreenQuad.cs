using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FullScreenQuad
{
    public class FullscreenQuad : MonoBehaviour
    {
        [SerializeField]
        protected Material material;
        protected MeshRenderer meshRenderer;
        protected MeshFilter meshFilter;

        private void Awake()
        {
            Create();
        }

        private void Create()
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            meshRenderer.receiveShadows = false;
            meshRenderer.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            meshRenderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
            meshRenderer.sharedMaterial = material;
            meshFilter = gameObject.AddComponent<MeshFilter>();

            Mesh mesh = new Mesh();
            mesh.name = "FullscreenQuad";
            Vector3[] verts = new Vector3[] {
                new Vector3( 1f,  1f, 0f),
                new Vector3(-1f, -1f, 0f),
                new Vector3(-1f,  1f, 0f),
                new Vector3( 1f, -1f, 0f),
            };
            int[] tri = new int[] {
                0, 1, 2,
                3, 1, 0,
            };
            Vector2[] uv = new Vector2[] {
                new Vector2(1f, 1f),
                new Vector2(0f, 0f),
                new Vector2(0f, 1f),
                new Vector2(1f, 0f),
            };
            mesh.vertices = verts;
            mesh.triangles = tri;
            mesh.uv = uv;
            mesh.RecalculateNormals();
            meshFilter.sharedMesh = mesh;
            mesh.RecalculateBounds();
        }
    }
}
