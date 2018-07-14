attribute vec3 a_posL;
attribute vec3 a_normL;
attribute vec2 a_texL;

varying vec2 v_texL;
varying vec3 FragPos;
varying vec3 v_normL;

uniform mat4 WVP;
uniform mat4 World;

void main()
{
	gl_Position =  WVP*vec4(a_posL,1.0);
	FragPos=(World*vec4(a_posL,1.0)).xyz;
	v_texL=a_texL;
	v_normL=a_normL;
}
   