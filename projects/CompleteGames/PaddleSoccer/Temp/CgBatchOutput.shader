Shader "Scanlines"
{
	Properties
		{
			_LinesColor("LinesColor", Color) = (0,0,0,1)
			_LinesSize("LinesSize", Range(1,10)) = 1
		}
   SubShader {
				 Tags {"IgnoreProjector" = "True" "Queue" = "Overlay"}
				 Fog { Mode Off }
      Pass {
		
		
		ZTest Always
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha 

         Program "vp" {
// Vertex combos: 1
//   opengl - ALU: 9 to 9
//   d3d9 - ALU: 9 to 9
//   d3d11 - ALU: 7 to 7, TEX: 0 to 0, FLOW: 1 to 1
//   d3d11_9x - ALU: 7 to 7, TEX: 0 to 0, FLOW: 1 to 1
SubProgram "opengl " {
Keywords { }
Bind "vertex" Vertex
Vector 5 [_ProjectionParams]
"!!ARBvp1.0
# 9 ALU
PARAM c[6] = { { 0.5 },
		state.matrix.mvp,
		program.local[5] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[5].x;
ADD result.texcoord[0].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[0].zw, R0;
END
# 9 instructions, 2 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_ProjectionParams]
Vector 5 [_ScreenParams]
"vs_2_0
; 9 ALU
def c6, 0.50000000, 0, 0, 0
dcl_position0 v0
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c6.x
mul r1.y, r1, c4.x
mad oT0.xy, r1.z, c5.zwzw, r1
mov oPos, r0
mov oT0.zw, r0
"
}

SubProgram "d3d11 " {
Keywords { }
Bind "vertex" Vertex
ConstBuffer "UnityPerCamera" 128 // 96 used size, 8 vars
Vector 80 [_ProjectionParams] 4
ConstBuffer "UnityPerDraw" 336 // 64 used size, 6 vars
Matrix 0 [glstate_matrix_mvp] 4
BindCB "UnityPerCamera" 0
BindCB "UnityPerDraw" 1
// 10 instructions, 2 temp regs, 0 temp arrays:
// ALU 7 float, 0 int, 0 uint
// TEX 0 (0 load, 0 comp, 0 bias, 0 grad)
// FLOW 1 static, 0 dynamic
"vs_4_0
eefiecedglcpjhlgffcbjlpacmngiofmbngloiccabaaaaaaiaacaaaaadaaaaaa
cmaaaaaakaaaaaaapiaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefciaabaaaa
eaaaabaagaaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadgaaaaafmccabaaaabaaaaaakgaobaaaaaaaaaaa
diaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaa
aaaaaaahdccabaaaabaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
"
}

SubProgram "gles " {
Keywords { }
"!!GLES


#ifdef VERTEX

varying lowp vec4 xlv_TEXCOORD;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _ProjectionParams;
attribute vec4 _glesVertex;
void main ()
{
  lowp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_3;
  highp vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 * 0.5);
  highp vec2 tmpvar_5;
  tmpvar_5.x = tmpvar_4.x;
  tmpvar_5.y = (tmpvar_4.y * _ProjectionParams.x);
  o_3.xy = (tmpvar_5 + tmpvar_4.w);
  o_3.zw = tmpvar_2.zw;
  tmpvar_1 = o_3;
  gl_Position = tmpvar_2;
  xlv_TEXCOORD = tmpvar_1;
}



#endif
#ifdef FRAGMENT

varying lowp vec4 xlv_TEXCOORD;
uniform mediump float _LinesSize;
uniform lowp vec4 _LinesColor;
uniform highp vec4 _ScreenParams;
void main ()
{
  lowp float tmpvar_1;
  tmpvar_1 = (xlv_TEXCOORD.y / xlv_TEXCOORD.w);
  mediump float tmpvar_2;
  tmpvar_2 = floor(_LinesSize);
  highp float tmpvar_3;
  tmpvar_3 = (float(mod (float(int(((tmpvar_1 * _ScreenParams.y) / tmpvar_2))), 2.0)));
  if ((tmpvar_3 == 0.0)) {
    discard;
  };
  gl_FragData[0] = _LinesColor;
}



#endif"
}

SubProgram "glesdesktop " {
Keywords { }
"!!GLES


#ifdef VERTEX

varying lowp vec4 xlv_TEXCOORD;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _ProjectionParams;
attribute vec4 _glesVertex;
void main ()
{
  lowp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_2 = (glstate_matrix_mvp * _glesVertex);
  highp vec4 o_3;
  highp vec4 tmpvar_4;
  tmpvar_4 = (tmpvar_2 * 0.5);
  highp vec2 tmpvar_5;
  tmpvar_5.x = tmpvar_4.x;
  tmpvar_5.y = (tmpvar_4.y * _ProjectionParams.x);
  o_3.xy = (tmpvar_5 + tmpvar_4.w);
  o_3.zw = tmpvar_2.zw;
  tmpvar_1 = o_3;
  gl_Position = tmpvar_2;
  xlv_TEXCOORD = tmpvar_1;
}



#endif
#ifdef FRAGMENT

varying lowp vec4 xlv_TEXCOORD;
uniform mediump float _LinesSize;
uniform lowp vec4 _LinesColor;
uniform highp vec4 _ScreenParams;
void main ()
{
  lowp float tmpvar_1;
  tmpvar_1 = (xlv_TEXCOORD.y / xlv_TEXCOORD.w);
  mediump float tmpvar_2;
  tmpvar_2 = floor(_LinesSize);
  highp float tmpvar_3;
  tmpvar_3 = (float(mod (float(int(((tmpvar_1 * _ScreenParams.y) / tmpvar_2))), 2.0)));
  if ((tmpvar_3 == 0.0)) {
    discard;
  };
  gl_FragData[0] = _LinesColor;
}



#endif"
}

SubProgram "flash " {
Keywords { }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_ProjectionParams]
Vector 5 [unity_NPOTScale]
"agal_vs
c6 0.5 0.0 0.0 0.0
[bc]
bdaaaaaaaaaaaiacaaaaaaoeaaaaaaaaadaaaaoeabaaaaaa dp4 r0.w, a0, c3
bdaaaaaaaaaaaeacaaaaaaoeaaaaaaaaacaaaaoeabaaaaaa dp4 r0.z, a0, c2
bdaaaaaaaaaaabacaaaaaaoeaaaaaaaaaaaaaaoeabaaaaaa dp4 r0.x, a0, c0
bdaaaaaaaaaaacacaaaaaaoeaaaaaaaaabaaaaoeabaaaaaa dp4 r0.y, a0, c1
adaaaaaaabaaahacaaaaaapeacaaaaaaagaaaaaaabaaaaaa mul r1.xyz, r0.xyww, c6.x
adaaaaaaabaaacacabaaaaffacaaaaaaaeaaaaaaabaaaaaa mul r1.y, r1.y, c4.x
abaaaaaaabaaadacabaaaafeacaaaaaaabaaaakkacaaaaaa add r1.xy, r1.xyyy, r1.z
adaaaaaaaaaaadaeabaaaafeacaaaaaaafaaaaoeabaaaaaa mul v0.xy, r1.xyyy, c5
aaaaaaaaaaaaapadaaaaaaoeacaaaaaaaaaaaaaaaaaaaaaa mov o0, r0
aaaaaaaaaaaaamaeaaaaaaopacaaaaaaaaaaaaaaaaaaaaaa mov v0.zw, r0.wwzw
"
}

SubProgram "d3d11_9x " {
Keywords { }
Bind "vertex" Vertex
ConstBuffer "UnityPerCamera" 128 // 96 used size, 8 vars
Vector 80 [_ProjectionParams] 4
ConstBuffer "UnityPerDraw" 336 // 64 used size, 6 vars
Matrix 0 [glstate_matrix_mvp] 4
BindCB "UnityPerCamera" 0
BindCB "UnityPerDraw" 1
// 10 instructions, 2 temp regs, 0 temp arrays:
// ALU 7 float, 0 int, 0 uint
// TEX 0 (0 load, 0 comp, 0 bias, 0 grad)
// FLOW 1 static, 0 dynamic
"vs_4_0_level_9_1
eefiecedaehokgegllpaaahojhjohkjkiaknimdiabaaaaaakaadaaaaaeaaaaaa
daaaaaaaemabaaaaneacaaaaeiadaaaaebgpgodjbeabaaaabeabaaaaaaacpopp
neaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaafaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaaf
agaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapja
afaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapiaacaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
afaaoekaaaaappjaaaaaoeiaafaaaaadabaaahiaaaaapeiaagaaaakaafaaaaad
abaaaiiaabaaffiaabaaaakaacaaaaadaaaaadoaabaakkiaabaaomiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaac
aaaaamoaaaaaoeiappppaaaafdeieefciaabaaaaeaaaabaagaaaaaaafjaaaaae
egiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaad
pcbabaaaaaaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaakhcaabaaa
abaaaaaaegadbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
dgaaaaafmccabaaaabaaaaaakgaobaaaaaaaaaaadiaaaaaiicaabaaaabaaaaaa
bkaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaaaaaaaaahdccabaaaabaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaabejfdeheogmaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaahaaaaaagaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffied
epepfceeaaklklklepfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl
"
}

SubProgram "gles3 " {
Keywords { }
"!!GLES3#version 300 es


#ifdef VERTEX

#define gl_Vertex _glesVertex
in vec4 _glesVertex;
#define gl_Normal (normalize(_glesNormal))
in vec3 _glesNormal;
#define gl_MultiTexCoord0 _glesMultiTexCoord0
in vec4 _glesMultiTexCoord0;

#line 151
struct v2f_vertex_lit {
    highp vec2 uv;
    lowp vec4 diff;
    lowp vec4 spec;
};
#line 187
struct v2f_img {
    highp vec4 pos;
    mediump vec2 uv;
};
#line 181
struct appdata_img {
    highp vec4 vertex;
    mediump vec2 texcoord;
};
#line 317
struct v2f {
    highp vec4 pos;
    lowp vec4 sPos;
};
#line 52
struct appdata_base {
    highp vec4 vertex;
    highp vec3 normal;
    highp vec4 texcoord;
};
uniform highp vec4 _Time;
uniform highp vec4 _SinTime;
#line 3
uniform highp vec4 _CosTime;
uniform highp vec4 unity_DeltaTime;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _ProjectionParams;
#line 7
uniform highp vec4 _ScreenParams;
uniform highp vec4 _ZBufferParams;
uniform highp vec4 unity_CameraWorldClipPlanes[6];
uniform highp vec4 _WorldSpaceLightPos0;
#line 11
uniform highp vec4 _LightPositionRange;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
#line 15
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_LightPosition[8];
uniform highp vec4 unity_LightAtten[8];
#line 19
uniform highp vec4 unity_SpotDirection[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
#line 23
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
#line 27
uniform highp vec3 unity_LightColor0;
uniform highp vec3 unity_LightColor1;
uniform highp vec3 unity_LightColor2;
uniform highp vec3 unity_LightColor3;
uniform highp vec4 unity_ShadowSplitSpheres[4];
uniform highp vec4 unity_ShadowSplitSqRadii;
uniform highp vec4 unity_LightShadowBias;
#line 31
uniform highp vec4 _LightSplitsNear;
uniform highp vec4 _LightSplitsFar;
uniform highp mat4 unity_World2Shadow[4];
uniform highp vec4 _LightShadowData;
#line 35
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 glstate_matrix_invtrans_modelview0;
#line 39
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 unity_Scale;
uniform highp mat4 glstate_matrix_transpose_modelview0;
#line 43
uniform highp mat4 glstate_matrix_texture0;
uniform highp mat4 glstate_matrix_texture1;
uniform highp mat4 glstate_matrix_texture2;
uniform highp mat4 glstate_matrix_texture3;
#line 47
uniform highp mat4 glstate_matrix_projection;
uniform highp vec4 glstate_lightmodel_ambient;
uniform highp mat4 unity_MatrixV;
uniform highp mat4 unity_MatrixVP;
#line 51
uniform lowp vec4 unity_ColorSpaceGrey;
#line 77
#line 82
#line 87
#line 91
#line 96
#line 120
#line 137
#line 158
#line 166
#line 193
#line 206
#line 215
#line 220
#line 229
#line 234
#line 243
#line 260
#line 265
#line 291
#line 299
#line 307
#line 311
#line 315
uniform lowp vec4 _LinesColor;
uniform mediump float _LinesSize;
#line 323
#line 284
highp vec4 ComputeScreenPos( in highp vec4 pos ) {
    #line 286
    highp vec4 o = (pos * 0.5);
    o.xy = (vec2( o.x, (o.y * _ProjectionParams.x)) + o.w);
    o.zw = pos.zw;
    return o;
}
#line 323
v2f vert( in appdata_base v ) {
    v2f o;
    o.pos = (glstate_matrix_mvp * v.vertex);
    #line 327
    o.sPos = ComputeScreenPos( o.pos);
    return o;
}
out lowp vec4 xlv_TEXCOORD;
void main() {
    v2f xl_retval;
    appdata_base xlt_v;
    xlt_v.vertex = vec4(gl_Vertex);
    xlt_v.normal = vec3(gl_Normal);
    xlt_v.texcoord = vec4(gl_MultiTexCoord0);
    xl_retval = vert( xlt_v);
    gl_Position = vec4(xl_retval.pos);
    xlv_TEXCOORD = vec4(xl_retval.sPos);
}


#endif
#ifdef FRAGMENT

#define gl_FragData _glesFragData
layout(location = 0) out mediump vec4 _glesFragData[4];

#line 151
struct v2f_vertex_lit {
    highp vec2 uv;
    lowp vec4 diff;
    lowp vec4 spec;
};
#line 187
struct v2f_img {
    highp vec4 pos;
    mediump vec2 uv;
};
#line 181
struct appdata_img {
    highp vec4 vertex;
    mediump vec2 texcoord;
};
#line 317
struct v2f {
    highp vec4 pos;
    lowp vec4 sPos;
};
#line 52
struct appdata_base {
    highp vec4 vertex;
    highp vec3 normal;
    highp vec4 texcoord;
};
uniform highp vec4 _Time;
uniform highp vec4 _SinTime;
#line 3
uniform highp vec4 _CosTime;
uniform highp vec4 unity_DeltaTime;
uniform highp vec3 _WorldSpaceCameraPos;
uniform highp vec4 _ProjectionParams;
#line 7
uniform highp vec4 _ScreenParams;
uniform highp vec4 _ZBufferParams;
uniform highp vec4 unity_CameraWorldClipPlanes[6];
uniform highp vec4 _WorldSpaceLightPos0;
#line 11
uniform highp vec4 _LightPositionRange;
uniform highp vec4 unity_4LightPosX0;
uniform highp vec4 unity_4LightPosY0;
uniform highp vec4 unity_4LightPosZ0;
#line 15
uniform highp vec4 unity_4LightAtten0;
uniform highp vec4 unity_LightColor[8];
uniform highp vec4 unity_LightPosition[8];
uniform highp vec4 unity_LightAtten[8];
#line 19
uniform highp vec4 unity_SpotDirection[8];
uniform highp vec4 unity_SHAr;
uniform highp vec4 unity_SHAg;
uniform highp vec4 unity_SHAb;
#line 23
uniform highp vec4 unity_SHBr;
uniform highp vec4 unity_SHBg;
uniform highp vec4 unity_SHBb;
uniform highp vec4 unity_SHC;
#line 27
uniform highp vec3 unity_LightColor0;
uniform highp vec3 unity_LightColor1;
uniform highp vec3 unity_LightColor2;
uniform highp vec3 unity_LightColor3;
uniform highp vec4 unity_ShadowSplitSpheres[4];
uniform highp vec4 unity_ShadowSplitSqRadii;
uniform highp vec4 unity_LightShadowBias;
#line 31
uniform highp vec4 _LightSplitsNear;
uniform highp vec4 _LightSplitsFar;
uniform highp mat4 unity_World2Shadow[4];
uniform highp vec4 _LightShadowData;
#line 35
uniform highp vec4 unity_ShadowFadeCenterAndType;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 glstate_matrix_modelview0;
uniform highp mat4 glstate_matrix_invtrans_modelview0;
#line 39
uniform highp mat4 _Object2World;
uniform highp mat4 _World2Object;
uniform highp vec4 unity_Scale;
uniform highp mat4 glstate_matrix_transpose_modelview0;
#line 43
uniform highp mat4 glstate_matrix_texture0;
uniform highp mat4 glstate_matrix_texture1;
uniform highp mat4 glstate_matrix_texture2;
uniform highp mat4 glstate_matrix_texture3;
#line 47
uniform highp mat4 glstate_matrix_projection;
uniform highp vec4 glstate_lightmodel_ambient;
uniform highp mat4 unity_MatrixV;
uniform highp mat4 unity_MatrixVP;
#line 51
uniform lowp vec4 unity_ColorSpaceGrey;
#line 77
#line 82
#line 87
#line 91
#line 96
#line 120
#line 137
#line 158
#line 166
#line 193
#line 206
#line 215
#line 220
#line 229
#line 234
#line 243
#line 260
#line 265
#line 291
#line 299
#line 307
#line 311
#line 315
uniform lowp vec4 _LinesColor;
uniform mediump float _LinesSize;
#line 323
#line 330
lowp vec4 frag( in v2f i ) {
    #line 332
    lowp float p = (i.sPos.y / i.sPos.w);
    if ((mod(float(int(((p * _ScreenParams.y) / floor(_LinesSize)))), 2.0) == 0.0)){
        discard;
    }
    return _LinesColor;
}
in lowp vec4 xlv_TEXCOORD;
void main() {
    lowp vec4 xl_retval;
    v2f xlt_i;
    xlt_i.pos = vec4(0.0);
    xlt_i.sPos = vec4(xlv_TEXCOORD);
    xl_retval = frag( xlt_i);
    gl_FragData[0] = vec4(xl_retval);
}


#endif"
}

}
Program "fp" {
// Fragment combos: 1
//   opengl - ALU: 22 to 22, TEX: 0 to 0
//   d3d9 - ALU: 23 to 23, TEX: 1 to 1
//   d3d11 - ALU: 8 to 8, TEX: 0 to 0, FLOW: 1 to 1
//   d3d11_9x - ALU: 8 to 8, TEX: 0 to 0, FLOW: 1 to 1
SubProgram "opengl " {
Keywords { }
Vector 0 [_ScreenParams]
Vector 1 [_LinesColor]
Float 2 [_LinesSize]
"!!ARBfp1.0
# 22 ALU, 0 TEX
PARAM c[4] = { program.local[0..2],
		{ 0.5, 1, 0, 2 } };
TEMP R0;
RCP R0.x, fragment.texcoord[0].w;
FLR R0.y, c[2].x;
MUL R0.x, fragment.texcoord[0].y, R0;
RCP R0.y, R0.y;
MUL R0.x, R0, c[0].y;
MUL R0.x, R0, R0.y;
ABS R0.y, R0.x;
FLR R0.y, R0;
SLT R0.x, R0, c[3].z;
CMP R0.x, -R0, -R0.y, R0.y;
MUL R0.x, R0, c[3];
FRC R0.x, R0;
MUL R0.x, R0, c[3].w;
ABS R0.y, R0.x;
ADD R0.y, R0, c[3].x;
FLR R0.y, R0;
SLT R0.x, R0, c[3].z;
CMP R0.x, -R0, -R0.y, R0.y;
ABS R0.x, R0;
CMP R0.x, -R0, c[3].z, c[3].y;
MOV result.color, c[1];
KIL -R0.x;
END
# 22 instructions, 1 R-regs
"
}

SubProgram "d3d9 " {
Keywords { }
Vector 0 [_ScreenParams]
Vector 1 [_LinesColor]
Float 2 [_LinesSize]
"ps_2_0
; 23 ALU, 1 TEX
def c3, 0.50000000, 2.00000000, 1.00000000, 0.00000000
dcl t0.xyzw
frc_pp r1.x, c2
rcp_pp r0.x, t0.w
add_pp r1.x, -r1, c2
mul_pp r0.x, t0.y, r0
rcp r1.x, r1.x
mul r0.x, r0, c0.y
mul r0.x, r0, r1
abs r1.x, r0
frc r2.x, r1
add r1.x, r1, -r2
cmp r0.x, r0, r1, -r1
mul r0.x, r0, c3
frc r0.x, r0
mul r0.x, r0, c3.y
abs r1.x, r0
add r1.x, r1, c3
frc r2.x, r1
add r1.x, r1, -r2
cmp r0.x, r0, r1, -r1
abs r0.x, r0
cmp r0.x, -r0, c3.z, c3.w
mov_pp r0, -r0.x
mov_pp oC0, c1
texkill r0.xyzw
"
}

SubProgram "d3d11 " {
Keywords { }
ConstBuffer "$Globals" 48 // 36 used size, 3 vars
Vector 16 [_LinesColor] 4
Float 32 [_LinesSize]
ConstBuffer "UnityPerCamera" 128 // 112 used size, 8 vars
Vector 96 [_ScreenParams] 4
BindCB "$Globals" 0
BindCB "UnityPerCamera" 1
// 13 instructions, 1 temp regs, 0 temp arrays:
// ALU 4 float, 2 int, 2 uint
// TEX 0 (0 load, 0 comp, 0 bias, 0 grad)
// FLOW 1 static, 0 dynamic
"ps_4_0
eefiecedlfbpebahgiokehagnemlancfilelejakabaaaaaaeeacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapakaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcieabaaaa
eaaaaaaagbaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaa
abaaaaaaahaaaaaagcbaaaadkcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacabaaaaaaaoaaaaahbcaabaaaaaaaaaaabkbabaaaabaaaaaadkbabaaa
abaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaaabaaaaaa
agaaaaaaebaaaaagccaabaaaaaaaaaaaakiacaaaaaaaaaaaacaaaaaaaoaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaablaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabaaaaahccaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaaaaaaaiaceaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaia
ebaaaaaaaaaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
abaaaaaaciaaaaafecaabaaaaaaaaaaaakaabaaaaaaaaaaadhaaaaajbcaabaaa
aaaaaaaabkaabaaaaaaaaaaackaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaaad
akaabaaaaaaaaaaadgaaaaagpccabaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaa
doaaaaab"
}

SubProgram "gles " {
Keywords { }
"!!GLES"
}

SubProgram "glesdesktop " {
Keywords { }
"!!GLES"
}

SubProgram "flash " {
Keywords { }
Vector 0 [_ScreenParams]
Vector 1 [_LinesColor]
Float 2 [_LinesSize]
"agal_ps
c3 0.5 2.0 1.0 0.0
c4 -1.0 1.0 1.0 0.0
[bc]
aaaaaaaaadaaapacacaaaaoeabaaaaaaaaaaaaaaaaaaaaaa mov r3, c2
aiaaaaaaabaaabacadaaaaaaacaaaaaaaaaaaaaaaaaaaaaa frc r1.x, r3.x
afaaaaaaaaaaabacaaaaaappaeaaaaaaaaaaaaaaaaaaaaaa rcp r0.x, v0.w
bfaaaaaaabaaabacabaaaaaaacaaaaaaaaaaaaaaaaaaaaaa neg r1.x, r1.x
abaaaaaaabaaabacabaaaaaaacaaaaaaacaaaaoeabaaaaaa add r1.x, r1.x, c2
adaaaaaaaaaaabacaaaaaaffaeaaaaaaaaaaaaaaacaaaaaa mul r0.x, v0.y, r0.x
afaaaaaaabaaabacabaaaaaaacaaaaaaaaaaaaaaaaaaaaaa rcp r1.x, r1.x
adaaaaaaaaaaabacaaaaaaaaacaaaaaaaaaaaaffabaaaaaa mul r0.x, r0.x, c0.y
adaaaaaaaaaaabacaaaaaaaaacaaaaaaabaaaaaaacaaaaaa mul r0.x, r0.x, r1.x
beaaaaaaabaaabacaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa abs r1.x, r0.x
aiaaaaaaacaaabacabaaaaaaacaaaaaaaaaaaaaaaaaaaaaa frc r2.x, r1.x
acaaaaaaabaaabacabaaaaaaacaaaaaaacaaaaaaacaaaaaa sub r1.x, r1.x, r2.x
bfaaaaaaaaaaacacabaaaaaaacaaaaaaaaaaaaaaaaaaaaaa neg r0.y, r1.x
ckaaaaaaabaaacacaaaaaaaaacaaaaaaadaaaappabaaaaaa slt r1.y, r0.x, c3.w
acaaaaaaacaaacacaaaaaaffacaaaaaaabaaaaaaacaaaaaa sub r2.y, r0.y, r1.x
adaaaaaaaaaaabacacaaaaffacaaaaaaabaaaaffacaaaaaa mul r0.x, r2.y, r1.y
abaaaaaaaaaaabacaaaaaaaaacaaaaaaabaaaaaaacaaaaaa add r0.x, r0.x, r1.x
adaaaaaaaaaaabacaaaaaaaaacaaaaaaadaaaaoeabaaaaaa mul r0.x, r0.x, c3
aiaaaaaaaaaaabacaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa frc r0.x, r0.x
adaaaaaaaaaaabacaaaaaaaaacaaaaaaadaaaaffabaaaaaa mul r0.x, r0.x, c3.y
beaaaaaaabaaabacaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa abs r1.x, r0.x
abaaaaaaabaaabacabaaaaaaacaaaaaaadaaaaoeabaaaaaa add r1.x, r1.x, c3
aiaaaaaaacaaabacabaaaaaaacaaaaaaaaaaaaaaaaaaaaaa frc r2.x, r1.x
acaaaaaaabaaabacabaaaaaaacaaaaaaacaaaaaaacaaaaaa sub r1.x, r1.x, r2.x
bfaaaaaaacaaabacabaaaaaaacaaaaaaaaaaaaaaaaaaaaaa neg r2.x, r1.x
ckaaaaaaadaaacacaaaaaaaaacaaaaaaadaaaappabaaaaaa slt r3.y, r0.x, c3.w
acaaaaaaadaaabacacaaaaaaacaaaaaaabaaaaaaacaaaaaa sub r3.x, r2.x, r1.x
adaaaaaaaaaaabacadaaaaaaacaaaaaaadaaaaffacaaaaaa mul r0.x, r3.x, r3.y
abaaaaaaaaaaabacaaaaaaaaacaaaaaaabaaaaaaacaaaaaa add r0.x, r0.x, r1.x
beaaaaaaaaaaabacaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa abs r0.x, r0.x
bfaaaaaaadaaabacaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa neg r3.x, r0.x
cjaaaaaaadaaabacadaaaaaaacaaaaaaadaaaappabaaaaaa sge r3.x, r3.x, c3.w
adaaaaaaaaaaabacaeaaaaaaabaaaaaaadaaaaaaacaaaaaa mul r0.x, c4.x, r3.x
abaaaaaaaaaaabacaaaaaaaaacaaaaaaadaaaakkabaaaaaa add r0.x, r0.x, c3.z
bfaaaaaaaaaaapacaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa neg r0, r0.x
aaaaaaaaaaaaapadabaaaaoeabaaaaaaaaaaaaaaaaaaaaaa mov o0, c1
chaaaaaaaaaaaaaaaaaaaaaaacaaaaaaaaaaaaaaaaaaaaaa kil a0.none, r0.x
"
}

SubProgram "d3d11_9x " {
Keywords { }
ConstBuffer "$Globals" 48 // 36 used size, 3 vars
Vector 16 [_LinesColor] 4
Float 32 [_LinesSize]
ConstBuffer "UnityPerCamera" 128 // 112 used size, 8 vars
Vector 96 [_ScreenParams] 4
BindCB "$Globals" 0
BindCB "UnityPerCamera" 1
// 13 instructions, 1 temp regs, 0 temp arrays:
// ALU 4 float, 2 int, 2 uint
// TEX 0 (0 load, 0 comp, 0 bias, 0 grad)
// FLOW 1 static, 0 dynamic
"ps_4_0_level_9_1
eefiecedppmkdlfpcfmeilmoakdnpfelnificnblabaaaaaaheaeaaaaaeaaaaaa
daaaaaaafmacaaaaoiadaaaaeaaeaaaaebgpgodjceacaaaaceacaaaaaaacpppp
oiabaaaadmaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaaaaadmaaaaaaabaa
acaaaaaaaaaaaaaaabaaagaaabaaacaaaaaaaaaaaaacppppfbaaaaafadaaapka
aaaaaaaaaaaaiadpaaaaaaeaaaaaaamafbaaaaafaeaaapkaaaaaaadpaaaaaalp
aaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacplaagaaaaacaaaaaiiaaaaappla
afaaaaadaaaacbiaaaaappiaaaaafflaafaaaaadaaaaabiaaaaaaaiaacaaffka
bdaaaaacaaaacciaabaaaakaacaaaaadaaaaaciaaaaaffibabaaaakaagaaaaac
aaaaaciaaaaaffiaafaaaaadaaaaabiaaaaaffiaaaaaaaiabdaaaaacaaaaacia
aaaaaaiafiaaaaaeaaaaaeiaaaaaffibadaaaakaadaaffkafiaaaaaeaaaaaeia
aaaaaaiaadaaaakaaaaakkiaacaaaaadaaaaabiaaaaaaaiaaaaaffibacaaaaad
aaaaabiaaaaakkiaaaaaaaiafiaaaaaeaaaaaciaaaaaaaiaaeaaaakaaeaaffka
afaaaaadaaaaaciaaaaaffiaaaaaaaiabdaaaaacaaaaaciaaaaaffiafiaaaaae
aaaaabiaaaaaaaiaadaakkkaadaappkaafaaaaadaaaaabiaaaaaffiaaaaaaaia
bdaaaaacaaaaaciaaaaaaaiafiaaaaaeaaaaaeiaaaaaffibadaaaakaadaaffka
fiaaaaaeaaaaaeiaaaaaaaiaadaaaakaaaaakkiaacaaaaadaaaaabiaaaaaaaia
aaaaffibacaaaaadaaaaabiaaaaakkiaaaaaaaiaafaaaaadaaaaabiaaaaaaaia
aaaaaaiafiaaaaaeaaaaapiaaaaaaaibadaaffkbadaaaakbebaaaaabaaaaapia
abaaaaacaaaacpiaaaaaoekaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefc
ieabaaaaeaaaaaaagbaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaae
egiocaaaabaaaaaaahaaaaaagcbaaaadkcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacabaaaaaaaoaaaaahbcaabaaaaaaaaaaabkbabaaaabaaaaaa
dkbabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
abaaaaaaagaaaaaaebaaaaagccaabaaaaaaaaaaaakiacaaaaaaaaaaaacaaaaaa
aoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaablaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabaaaaahccaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaiaceaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaiaebaaaaaaaaaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaabaaaaaaciaaaaafecaabaaaaaaaaaaaakaabaaaaaaaaaaadhaaaaaj
bcaabaaaaaaaaaaabkaabaaaaaaaaaaackaabaaaaaaaaaaaakaabaaaaaaaaaaa
anaaaaadakaabaaaaaaaaaaadgaaaaagpccabaaaaaaaaaaaegiocaaaaaaaaaaa
abaaaaaadoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapakaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}

SubProgram "gles3 " {
Keywords { }
"!!GLES3"
}

}

#LINE 51

      }
   }
}