attribute vec3 a_posL;
uniform mat4 WVP;
void main()
{
	gl_Position =  WVP*vec4(a_posL,1.0);
}
   