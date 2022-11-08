using UnityEngine;

namespace Utils
{
    public static class Fourier
    {
        public static Complex[] DiscreteTransform(Complex[] signals)
        {
            var totalSteps = signals.Length;

            const int start = 0;
            var end = totalSteps - 1;

            var results = new Complex[end - start + 1];

            for (int i = start; i <= end; i++)
            {
                var signal = DiscreteTransform_InternalSequenceSum(signals, i);
                results[i] = signal;
            }

            return results;
        }

        
        private static Complex DiscreteTransform_InternalSequenceSum(Complex[] signals, int externalStep)
        {
            var totalSteps = signals.Length;
            
            const int start = 0;
            var end = totalSteps - 1;

            var result = Complex.Zero;

            for (int i = start; i <= end; i++)
            {
                var signal = DiscreteTransform_InternalSequenceStep(signals, externalStep, i);
                result += signal;
            }

            return result;
        }

        private static Complex DiscreteTransform_InternalSequenceStep(Complex[] signals, int externalStep, int internalStep)
        {
            var totalSteps = signals.Length;
            var signal = signals[internalStep];
            
            var phi = (2 * Mathf.PI * externalStep * internalStep) / totalSteps;
            var realPart = Mathf.Cos(phi);
            var imaginaryPart = Mathf.Sin(phi);
            var complex = new Complex(realPart, imaginaryPart);
            return complex * signal;
        }
    }
}