precision mediump float;

//varying
varying vec2 v_texL;

//uniform
uniform sampler2D DisplacementMap;//  Displacement 
uniform sampler2D Fire;//  fire
uniform sampler2D Fire_Mask;// fire_mask

uniform float u_Time;

const float density=0.05;
const float LOG2=1.442695;

void main()
{
	vec2 disp = texture2D(DisplacementMap, vec2(v_texL.x, v_texL.y + u_Time)).rg;
	vec2 offset = (2.0 * disp - 1.0) *0.15;

	vec2 Tex_coords_displaced = v_texL+offset;

	vec4 fire_color = texture2D(Fire, Tex_coords_displaced);

	vec4 AlphaValue = texture2D(Fire_Mask, v_texL);
	vec4 Frag=fire_color*(1.0, 1.0, 1.0, AlphaValue.r);
	if(Frag.a<0.1)
		discard;
	//gl_FragColor=Frag;
	float z=gl_FragCoord.z/gl_FragCoord.w;
	float fogFator=exp2(-density*density*z*z*LOG2);
	
	gl_FragColor=mix(vec4(0.6,0.6,0.0,1.0),Frag,fogFator);
}
