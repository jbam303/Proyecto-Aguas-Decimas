Shader "Custom/Outline Mask" {
  Properties {
    [Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 0
  }

  SubShader {
    Tags {
      "Queue" = "Transparent+100"
      "RenderType" = "Transparent"
      "RenderPipeline" = "UniversalPipeline"
    }

    Pass {
      Name "Mask"
      Cull Off
      ZTest [_ZTest]
      ZWrite Off
      ColorMask 0

      Stencil {
        Ref 1
        Pass Replace
      }

      HLSLPROGRAM
      #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
      #pragma vertex vert
      #pragma fragment frag

      struct appdata {
        float4 vertex : POSITION;
        UNITY_VERTEX_INPUT_INSTANCE_ID
      };

      struct v2f {
        float4 position : SV_POSITION;
        UNITY_VERTEX_OUTPUT_STEREO
      };

      v2f vert(appdata input) {
        v2f output;
        UNITY_SETUP_INSTANCE_ID(input);
        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);
        output.position = TransformObjectToHClip(input.vertex.xyz);
        return output;
      }

      half4 frag(v2f input) : SV_Target {
        return half4(0,0,0,0);
      }
      ENDHLSL
    }
  }
}