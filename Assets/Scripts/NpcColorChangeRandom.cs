using UnityEngine;

public class NpcColorChangeRandom : MonoBehaviour
{
    public Material[] newMaterial;
    private int materialIndex;
    public Renderer capsuleRenderer;
    public int maxNumberOfMaterial;

    // Start is called before the first frame update
    void Start()
    {
        materialIndex = Random.Range(0, maxNumberOfMaterial);
        capsuleRenderer.material = newMaterial[materialIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
