attribute vec3 a_posL;
attribute vec2 a_texL;

varying vec2 v_texL;


uniform mat4 WVP;

void main()
{ 
	gl_Position = WVP*vec4(a_posL, 1.0);
	v_texL=a_texL;
}
   