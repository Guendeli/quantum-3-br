#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class ShaderPool
    {
        [SerializeField]
        private Shader _gridShader;

        public static ShaderPool Get()
        {
            return FreeSimWorldBuilder.ActiveInstance.ShaderPool;
        }

        public Shader GridShader
        {
            get
            {
                if (_gridShader == null) _gridShader = Shader.Find("FreeSim/XZGrid");
                return _gridShader;
            }
        }
    }
}
#endif