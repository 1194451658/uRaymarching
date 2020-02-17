using UnityEngine;
using System.Collections.Generic;

namespace uShaderTemplate
{
    // 变量
    // 就是Tags里面的东西
    // 例如："RenderType" = "<RenderType=Opaque|Transparent|TransparentCutout|Background|Overlay>"
    [System.Serializable]
    public struct ShaderVariables
    {
        public string key;
        public string value;
    }

    // 就是@if这种
    //@if Blend : false
    //    [Enum(UnityEngine.Rendering.BlendMode)] _BlendSrc("Blend Src", Float) = 5 
    //    [Enum(UnityEngine.Rendering.BlendMode)] _BlendDst("Blend Dst", Float) = 10
    //@endif
    [System.Serializable]
    public struct ShaderCondition
    {
        public string key;
        public bool value;
    }
    
    // 就是，可以写一段代码，或一个函数
    // @block Properties
    // _Color2("Color2", Color) = (1.0, 1.0, 1.0, 1.0)
    // @endblock
    [System.Serializable]
    public struct ShaderBlock
    {
        public string key;
        public string value;
        public bool folded;
    }

    // 菜单位置："Shader/uShaderTemplate/Generator"
    [CreateAssetMenu(
        menuName = Common.Setting.menuPlace + "Generator",
        order = Common.Setting.menuOrder)]
    public class Generator : ScriptableObject
    {
        public string shaderName = "";
        public Shader shaderReference = null;
        public string shaderTemplate = "";

        public List<ShaderVariables> variables = new List<ShaderVariables>();
        public List<ShaderCondition> conditions = new List<ShaderCondition>();
        public List<ShaderBlock> blocks = new List<ShaderBlock>();
        public Constants constants;

        // Q: 这个是？菜单
        public bool basicFolded = true;
        public bool conditionsFolded = false;
        public bool variablesFolded = false;
        public bool materialsFolded = false;
        public bool constantsFolded = false;

        public virtual void OnBeforeConvert()
        {
        }

        public virtual void OnAfterConvert()
        {
        }
    }
}