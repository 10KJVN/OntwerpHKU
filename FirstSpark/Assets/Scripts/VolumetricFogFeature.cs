using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

public class VolumetricFogFeature : ScriptableRendererFeature
{
    class VolumetricFogPass : ScriptableRenderPass
    {
        private Material fogMaterial;
        private VolumeComponent fogEffect;

        public VolumetricFogPass(Material material)
        {
            fogMaterial = material;
            renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        }

        /*public void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();
            UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();

            TextureHandle colorTexture = resourceData.activeColorTexture;

            renderGraph.AddRenderPass<PassData>("Volumetric Fog", (ref PassData data, RenderGraphContext ctx) =>
            {
                var stack = VolumeManager.instance.stack;
                var volume = stack.GetComponent<VolumetricFogEffect>();
                if (volume == null || !volume.IsActive()) return;

                // Set shader properties
                fogMaterial.SetFloat("_StepSize", volume.stepSize.value);
                fogMaterial.SetFloat("_MaxDistance", volume.maxDistance.value);
                fogMaterial.SetColor("_Color", volume.fogColor.value);
                fogMaterial.SetFloat("_DensityMultiplier", volume.densityMultiplier.value);
                fogMaterial.SetFloat("_NoiseOffset", volume.noiseOffset.value);
                fogMaterial.SetTexture("_FogNoise", volume.fogNoise.value);
                fogMaterial.SetFloat("_NoiseTiling", volume.noiseTiling.value);
                fogMaterial.SetFloat("_DensityThreshold", volume.densityThreshold.value);
                fogMaterial.SetColor("_LightContribution", volume.lightContribution.value);
                fogMaterial.SetFloat("_LightScattering", volume.lightScattering.value);

                CoreUtils.SetRenderTarget(ctx.cmd, colorTexture, ClearFlag.None);
                ctx.cmd.Blit(colorTexture, colorTexture, fogMaterial, 0);
            });
        }*/

        //private class PassData { }
        
        [Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            //Get active volume stack for current camera
            var stack = VolumeManager.instance.stack;
            var volume = stack.GetComponent<VolumetricFogEffect>();
            if (volume == null || !volume.IsActive()) return;
            
            ApplyFogEffect(volume);
            
            // Get the camera color target and perform a Blit
            var cameraColor = renderingData.cameraData.renderer.cameraColorTargetHandle;
            CommandBuffer cmd = CommandBufferPool.Get("VolumetricFogPass");
            cmd.SetRenderTarget(cameraColor);
            cmd.Blit(cameraColor, cameraColor, fogMaterial);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
        
        private void ApplyFogEffect(VolumetricFogEffect volume)
        {
            // Set shader properties
            fogMaterial.SetFloat("_StepSize", volume.stepSize.value);
            fogMaterial.SetFloat("_MaxDistance", volume.maxDistance.value);
            fogMaterial.SetColor("_Color", volume.fogColor.value);
            fogMaterial.SetFloat("_DensityMultiplier", volume.densityMultiplier.value);
            fogMaterial.SetFloat("_NoiseOffset", volume.noiseOffset.value);
            fogMaterial.SetTexture("_FogNoise", volume.fogNoise.value);
            fogMaterial.SetFloat("_NoiseTiling", volume.noiseTiling.value);
            fogMaterial.SetFloat("_DensityThreshold", volume.densityThreshold.value);
            fogMaterial.SetColor("_LightContribution", volume.lightContribution.value);
            fogMaterial.SetFloat("_LightScattering", volume.lightScattering.value);
        }
    }

    [SerializeField] Shader fogShader;
    private Material fogMaterial;
    private VolumetricFogPass fogPass;

    public override void Create()
    {
        if (fogShader == null)
            fogShader = Shader.Find("Custom/Shader01");

        if (fogShader != null)
        {
            fogMaterial = CoreUtils.CreateEngineMaterial(fogShader);
            fogPass = new VolumetricFogPass(fogMaterial);
        }
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        //renderer.EnqueueRenderPass(fogPass);
        renderer.EnqueuePass(fogPass);
    }
}
