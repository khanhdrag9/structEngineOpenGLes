attribute vec3 a_posL;
varying vec4 v_pos; 
uniform mat4 WVP;
void main(void) {
     
	gl_Position = WVP*vec4(a_posL, 1.0);
    v_pos = vec4(a_posL,1.0); 
} 
 
 