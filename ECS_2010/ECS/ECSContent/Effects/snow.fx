float4x4 World;
float4x4 View;
float4x4 Projection;

Texture colorTexture;
float gameTime = 1;
float weatherSpeed = 1;

sampler colorTextureSampler = sampler_state 
{
	texture = <colorTexture>;
	magfilter = LINEAR;
	minfilter = LINEAR;
	mipfilter = LINEAR;
};

// TODO: add effect parameters here.

struct VertexShaderInput
{
    float4 Position : POSITION0;

    // TODO: add input channels such as texture
    // coordinates and vertex colors here.

	float2 textureCoord : TEXCOORD0;


};

struct VertexShaderOutput
{
    float4 Position : POSITION0;

    // TODO: add vertex shader outputs such as colors and texture
    // coordinates here. These values will automatically be interpolated
    // over the triangle, and provided as input to your pixel shader.

	float2 textureCoord : TEXCOORD0;

};


//JUST Apply the texture pixels color;
VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;

    float4 worldPosition = mul(input.Position, World);
    float4 viewPosition = mul(worldPosition, View);
    output.Position = mul(viewPosition, Projection);
	output.textureCoord = input.textureCoord;

    return output;
}




float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{

	float4 output = tex2D(colorTextureSampler, input.textureCoord);
    float4 output2  = tex2D(colorTextureSampler, input.textureCoord);
	return lerp(dot(output, float3(1, 1, 1)), output2, sin(gameTime*weatherSpeed)/8 + 1/1.14 );
	
}



technique Technique1
{
    pass Pass1
    {
        // TODO: set renderstates here.
		 
        VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }

}
