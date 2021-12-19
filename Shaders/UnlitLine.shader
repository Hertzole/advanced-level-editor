// Upgrade NOTE: upgraded instancing buffer 'HertzoleALEUnlitLine' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Hertzole/ALE/Unlit Line"
{
	Properties
	{
		
	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Geometry" "DisableBatching"="True" "Queue"="Geometry+4" "ForceNoShadowCasting"="True" "IgnoreProjector"="True" }
	LOD 200

		CGINCLUDE
		#pragma target 4.0
		ENDCG
		Blend SrcAlpha OneMinusSrcAlpha
		BlendOp Add, Add
		AlphaToMask Off
		Cull Off
		ColorMask RGBA
		ZWrite On
		ZTest [_ZTest]
		
		
		
		Pass
		{
			Name "Unlit"
			Tags { "LightMode"="ForwardBase" }
			CGPROGRAM

			

			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			//only defining to not throw compilation error over Unity 5.5
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"
			#include "UnityShaderVariables.cginc"
			#define ASE_NEEDS_VERT_POSITION


			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 worldPos : TEXCOORD0;
				#endif
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			float4x4 unity_Projector;
			UNITY_INSTANCING_BUFFER_START(HertzoleALEUnlitLine)
			UNITY_INSTANCING_BUFFER_END(HertzoleALEUnlitLine)

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				float3 unityObjectToViewPos28 = UnityObjectToViewPos( v.vertex.xyz );
				
				o.ase_color = v.color;
				float3 vertexValue = float3(0, 0, 0);
				#if ASE_ABSOLUTE_VERTEX_POS
				vertexValue = v.vertex.xyz;
				#endif
				vertexValue = mul( unity_Projector, float4( ( unityObjectToViewPos28 * 0.99 ) , 0.0 ) ).xyz;
				#if ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif
				o.vertex = UnityObjectToClipPos(v.vertex);

				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				#endif
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
				fixed4 finalColor;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 WorldPosition = i.worldPos;
				#endif
				
				
				finalColor = i.ase_color;
				return finalColor;
			}
			ENDCG
		}
	}
	
	
	
}
/*ASEBEGIN
Version=18800
194;192;1920;1019;446.8909;615.7991;1.144864;True;True
Node;AmplifyShaderEditor.PosVertexDataNode;29;-409.6176,89.52882;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.UnityObjToViewPosHlpNode;28;-173.6181,81.52882;Inherit;False;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;31;22.38176,138.5288;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;0;False;0;False;0.99;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;182.3817,36.52877;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.UnityProjectorMatrixNode;37;134.1512,-113.6888;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.RangedFloatNode;3;179.0142,268.8065;Inherit;False;Property;_Size;Size;1;0;Create;True;0;0;0;False;0;False;10;8;0;40;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;86.17599,-483.1918;Inherit;False;InstancedProperty;_Color;Color;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.IntNode;4;-412.509,-27.95518;Inherit;False;Property;_ZTest;ZTest;2;0;Create;True;0;0;0;False;0;False;8;8;False;0;1;INT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;331.3819,-31.47124;Inherit;False;2;2;0;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ProjectionMatrixNode;36;-66.61843,-87.47122;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.VertexColorNode;34;405.2157,-439.9132;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1;531.9106,-128.0902;Float;False;True;-1;2;;200;1;Hertzole/ALE/Unlit Line;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;True;2;5;False;-1;10;False;-1;0;1;False;-1;10;False;-1;True;0;False;-1;1;False;-1;False;False;False;False;False;False;True;0;False;-1;True;2;False;-1;True;True;True;True;True;0;False;-1;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;1;False;-1;True;5;True;4;True;False;0;False;-1;0;False;-1;True;5;RenderType=Geometry=RenderType;DisableBatching=True=DisableBatching;Queue=Geometry=Queue=4;ForceNoShadowCasting=True;IgnoreProjector=True;True;4;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=ForwardBase;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;1;True;False;;False;0
WireConnection;28;0;29;0
WireConnection;30;0;28;0
WireConnection;30;1;31;0
WireConnection;33;0;37;0
WireConnection;33;1;30;0
WireConnection;1;0;34;0
WireConnection;1;1;33;0
ASEEND*/
//CHKSM=12A0B501AFF4F43C2B1EC59CC25AB1BBC1DF60F3