using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Shader shader;
    public Shader highLumiShader;
    public Shader blurShader;
    public Shader compoMatShader;
    private Material highLumiMat;
    private Material blurMat;
    private Material compoMat;
    //private Material material;
    

    private void Awake()
    {
        highLumiMat = new Material(highLumiShader);
        blurMat = new Material(blurShader);
        compoMat = new Material(compoMatShader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Graphics.Blit(source, destination, material);

        RenderTexture highLumiTex =
            RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
        RenderTexture blurTex =
            RenderTexture.GetTemporary(source.width, source.height, 0, source.format);

        Graphics.Blit(source, highLumiTex, highLumiMat);
        Graphics.Blit(highLumiTex, blurTex, blurMat);

        compoMat.SetTexture("_HighLumiTex", blurTex);
        Graphics.Blit(source, destination, compoMat);

        RenderTexture.ReleaseTemporary(blurTex);
        RenderTexture.ReleaseTemporary(highLumiTex);

        //RenderTexture buffer =
        //    RenderTexture.GetTemporary(source.width / 2, source.height / 2, 0, source.format);
        //Graphics.Blit(source, buffer);
        //Graphics.Blit(buffer, destination);
        //RenderTexture.ReleaseTemporary(buffer);

        //RenderTexture buf1 = RenderTexture.GetTemporary(source.width / 2, source.height / 2, 0, source.format);
        //RenderTexture buf2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0, source.format);
        //RenderTexture buf3 = RenderTexture.GetTemporary(source.width / 8, source.height / 8, 0, source.format);
        // シェーダー適応用バッファ。一番小さいサイズのバッファと同じサイズで確保
        //RenderTexture blurTex = RenderTexture.GetTemporary(buf3.width, buf3.height, 0, buf3.format);

        //Graphics.Blit(source, buf1);
        //Graphics.Blit(buf1, buf2);
        //Graphics.Blit(buf2, buf3);

        //Graphics.Blit(buf3, buf2);
        //Graphics.Blit(buf2, buf1);
        //Graphics.Blit(buf1, destination);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
