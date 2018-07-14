attribute vec3 a_posL;
attribute vec2 a_texL;
attribute vec3 a_normL;

varying vec2 v_texL;
varying vec3 FragPos;
varying vec3 v_normL;

uniform mat4 WVP;
uniform mat4 World;

uniform sampler2D heightmap;//heightmap
varying float height;


void main()
{ 
	vec3 vertex=a_posL;
	vertex.y = texture2D (heightmap,a_texL).y*20.0;
	gl_Position = WVP*vec4(vertex, 1.0);
	FragPos=(World*vec4(a_posL,1.0)).xyz;
	v_texL=a_texL;
	v_normL=a_normL;
	height=vertex.y;
}
   