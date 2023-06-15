float4x4 World;
float4x4 View;
float4x4 Projection;
Texture colorTexture;
float time;

float speed = 2;
float frequency = 0.3;
float amplitude = 3;

//float randomNumber = rand(seed);


sampler flagTextureSampler = sampler_state
{
	texture = <colorTexture>;
	magfilter = LINEAR;
	minfilter = LINEAR;
	mipfilter = LINEAR;

};


struct VertexShaderInput
{
    float4 Position : POSITION0;
	float2 TexCoord : TEXCOORD0;
};


struct VertexShaderOutput
{
    float4 Position : POSITION0;
	float2 TexCoord : TEXCOORD0;
};


VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;
								//speed                           //frequency   //amplitude
	input.Position.x += sin((time*speed - input.Position.x + input.Position.y)*frequency)*amplitude;
	input.Position.y += sin((time*speed - input.Position.x + input.Position.y)*frequency)*1;
	input.Position.z += sin((time*speed*2 - input.Position.x + input.Position.y)*frequency)*amplitude;
	
	input.TexCoord.y -= time*0.01*speed;
	input.TexCoord.x -= time*0.02*speed;
    float4 worldPosition = mul(input.Position, World);
    float4 viewPosition = mul(worldPosition, View);
    output.Position = mul(viewPosition, Projection);

	output.TexCoord = input.TexCoord;

    return output;
}


float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	float4 output = tex2D(flagTextureSampler, input.TexCoord);;
    return lerp(output, dot(output, float4(0, 0, 0,0.2)), 0.2);
}


technique Technique1
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
