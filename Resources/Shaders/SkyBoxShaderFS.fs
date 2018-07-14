precision mediump float;
uniform samplerCube CubeTexture; 
varying vec4 v_pos; 
const float density=0.05;
const float LOG2=1.442695;
void main(void) 
{    
	float z=gl_FragCoord.z/gl_FragCoord.w;
	float fogFator=exp2(-density*density*z*z*LOG2);
	//gl_FragColor=textureCube(CubeTexture,vec3(v_pos.xyz));
    gl_FragColor = mix(vec4(1.0,1.0,1.0,1.0),textureCube(CubeTexture, vec3(v_pos.xyz)),fogFator+0.05); 
} 
 