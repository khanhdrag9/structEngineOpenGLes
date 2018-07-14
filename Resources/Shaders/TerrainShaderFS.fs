precision mediump float;

//varying
varying vec2 v_texL;
varying vec3 FragPos;
varying vec3 v_normL;
varying float height;


//uniform
uniform sampler2D heightmap;//height 
uniform sampler2D Rock;//Rock
uniform sampler2D Grass;//Grass
uniform sampler2D Dirt;//Dirt
uniform vec3 viewPos; 
uniform vec3 lightPos;
uniform vec3 lightColor;
uniform vec3 lightPos1;
uniform vec3 lightColor1;




const float density=0.05;
const float LOG2=1.442695;


void main()
{ 
	vec4 texel0 = texture2D(heightmap, v_texL*20.0);
    vec4 texel1 = texture2D(Dirt, 20.0 * v_texL);
	vec4 texel2= texture2D(Grass,100.0*v_texL);
	vec4 texel3=texture2D(Rock,20.0*v_texL);
	vec4 MyMix;
	if(height>=1.1)
		MyMix=mix(texel0,texel1,0.9);
	else if(height>=0.7)
		MyMix=mix(texel1,texel2,0.8);
	else
		MyMix=mix(texel0,texel3,0.8);
	vec4 FinalColor=(texel0*texel1+texel0*texel2+texel0*texel3)/(texel0.r+texel0.b+texel0.g);
	float z=gl_FragCoord.z/gl_FragCoord.w;
	float fogFator=exp2(-density*density*z*z*LOG2);

	vec4 Ambient=vec4(1.0,1.0,1.0,1.0);
	float weight=0.1;

	vec3 norm=normalize(v_normL);
	vec3 lightDir=normalize(lightPos-FragPos);
	float diff = max(dot(norm, lightDir), 0.0);
	vec4 LightColor=vec4(lightColor,1.0);
	vec4 diffuse = diff * LightColor;

	float specularStrength = 0.5;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
	float spec = pow((max(dot(viewDir, reflectDir), 0.0)), 20.0);
    vec4 specular = (specularStrength * spec * LightColor);  

	vec4 Ambient1=vec4(1.0,1.0,1.0,1.0);
	vec3 lightDir1=normalize(lightPos1-FragPos);
	float diff1 = max(dot(norm, lightDir1), 0.0);
	vec4 LightColor1=vec4(lightColor1,1.0);
	vec4 diffuse1 = diff1 * LightColor1;

    vec3 reflectDir1 = reflect(-lightDir1, norm);
	float spec1 = pow((max(dot(viewDir, reflectDir1), 0.0)), 20.0);
    vec4 specular1 = (specularStrength * spec1 * LightColor1);


	gl_FragColor=((Ambient+Ambient1)*weight+(diffuse+diffuse1)+(specular+specular1))*MyMix;
    //gl_FragColor = mix(vec4(0.8,0.8,0.8,1.0),MyMix,fogFator+0.1);

	
}
