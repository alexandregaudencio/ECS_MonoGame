float4x4 World;
float4x4 View;
float4x4 Projection;
Texture colorTexture;
float time;

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
	input.Position.y += sin((time*10 - input.Position.x + input.Position.y)*0.3)*3;
	//input.Position.x += sin(time - input.Position.x + input.Position.y));
    //input.Position.z += sin(time - input.Position.x + input.Position.y);

    float4 worldPosition = mul(input.Position, World);
    float4 viewPosition = mul(worldPosition, View);
    output.Position = mul(viewPosition, Projection);

	output.TexCoord = input.TexCoord;

    return output;
}


float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	float4 output = tex2D(flagTextureSampler, input.TexCoord);

    return output;
}


technique Technique1
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
