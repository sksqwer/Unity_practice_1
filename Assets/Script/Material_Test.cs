using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Test : MonoBehaviour
{
    private Renderer renderer;
    public Color oriColor;

    Material mat;
    Material[] mats;

    public Shader shaderVertexColor;
    public Shader shaderStandard;

    public bool bChange = false;

    public void Awake()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        shaderVertexColor = Shader.Find("Mobile/Bumped Diffuse");
        if(!shaderVertexColor)
        {
            Debug.Log("shaderVertexColor not found");
        }

        shaderStandard = Shader.Find("Standard"); // Mobile/Particles/Alpha Blended");
        if(!shaderStandard)
        {
            Debug.Log("shaderStandard not found");
        }


        if (bChange)
        {
            meshRenderer.material.shader = shaderVertexColor;

        }
        else
        {
            meshRenderer.material.shader = shaderStandard;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        mat = renderer.material;
        mats = renderer.materials;
        oriColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Mat_1();
        Mat_2();



       

    }

    void Mat_1()
    {
        if (Input.GetKeyDown(KeyCode.R))
            GetComponent<Renderer>().material.color = Color.red;

        if (Input.GetKeyDown(KeyCode.G))
            GetComponent<Renderer>().material.color = Color.green;

        if (Input.GetKeyDown(KeyCode.B))
            GetComponent<Renderer>().material.color = Color.blue;
    }


    void Mat_2()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            mat.SetColor("_Color", Color.red);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mat.color = new Color(0, 1, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mat.SetColor("_Color", new Color(oriColor.r, oriColor.g, oriColor.b, 1.0f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mat.SetFloat("_Mode", 0);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = -1;


        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mat.SetFloat("_Mode", 1);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1);
            mat.EnableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 2450;


        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            mat.SetFloat("_Mode", 2);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;


        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            mat.SetFloat("_Mode", 3);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;


        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Texture albedoText = Resources.Load("Textures/road_rocks_blocky") as Texture;
            renderer.material.SetTexture("_MainTex", albedoText);

            Texture bumpTex = Resources.Load("Textures/road_rocks_blocky_NRM") as Texture;
            renderer.material.SetTexture("_BumpMap", bumpTex);

        }
    }

}
