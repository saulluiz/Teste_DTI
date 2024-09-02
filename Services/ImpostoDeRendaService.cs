using Estrutura_Base.Interfaces;
using System;
using System.Diagnostics.Eventing.Reader;

public class ImpostoDeRendaService() : IImpostoDeRendaService
{
    public float CalculateIR(float value)
    {
        float[] limites = { 22847.76f, 33919.80f, 45012.60f, 55976.16f, 55976.16f };
        float[] aliquotas = { 0f, 0.075f, 0.15f, 0.225f, 0.275f };
        float[] deducoes = { 0, 1713.58f, 4257.57f, 7633.51f, 10432.32f };

        for (int i = 0; i < limites.Length - 1; i++)
        {
            if (value < limites[i])
                return value * aliquotas[i] - deducoes[i];
        }

        return value * aliquotas.Last() - deducoes.Last();
    }
}