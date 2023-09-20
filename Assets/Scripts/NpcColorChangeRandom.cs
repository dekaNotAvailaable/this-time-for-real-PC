using UnityEngine;

public class NpcColorChangeRandom : MonoBehaviour
{
    public Material[] newMaterial;
    private int materialIndex;
    public Renderer capsuleRenderer;
    public int maxNumberOfMaterial;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        materialIndex = Random.Range(0, maxNumberOfMaterial + 1);
        // capsuleRenderer.material = newMaterial[materialIndex];
        if (newMaterial != null)
        {
            if (meshRenderer != null)
            {
                meshRenderer.material = newMaterial[materialIndex];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
