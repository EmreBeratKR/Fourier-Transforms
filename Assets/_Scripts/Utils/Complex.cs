using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public struct Complex : IEquatable<Complex>
    {
        private const float EqualityTolerance = 0.0001f;


        public static Complex Zero => ComplexZero;
        public static Complex One => ComplexOne;
        public static Complex ImaginaryOne => ComplexImaginaryOne;
        public static Complex ImaginaryMinusOne => ComplexImaginaryMinusOne;
        public static Complex RealOne => ComplexRealOne;
        public static Complex RealMinusOne => ComplexRealMinusOne;


        public float SqrMagnitude => re * re + im * im;
        public float Magnitude => Mathf.Sqrt(SqrMagnitude);
        public float Angle => Mathf.Atan2(im, re);
        
        
        public float re;
        public float im;

        
        private static readonly Complex ComplexZero = new Complex(0f, 0f);
        private static readonly Complex ComplexOne = new Complex(1f, 1f);
        private static readonly Complex ComplexImaginaryOne = new Complex(0f, 1f);
        private static readonly Complex ComplexImaginaryMinusOne = new Complex(0f, -1f);
        private static readonly Complex ComplexRealOne = new Complex(1f, 0f);
        private static readonly Complex ComplexRealMinusOne = new Complex(-1f, 0f);
        

        public Complex(float re, float im)
        {
            this.re = re;
            this.im = im;
        }
        
        
        public bool Equals(Complex other)
        {
            return Mathf.Abs(re - other.re) < EqualityTolerance && Mathf.Abs(im - other.im) < EqualityTolerance;
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex && Equals(complex);
        }

        public override string ToString()
        {
            return $"({re}, {im}i)";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(re, im);
        }


        public static Complex operator +(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.re + rhs.re, lhs.im + rhs.im);
        }
        
        public static Complex operator -(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.re - rhs.re, lhs.im - rhs.im);
        }

        public static Complex operator *(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.re * rhs.re - lhs.im * rhs.im, lhs.re * rhs.im + lhs.im * rhs.re);
        }

        public static Complex operator *(Complex lhs, float rhs)
        {
            return new Complex(lhs.re * rhs, lhs.im * rhs);
        }
        
        public static implicit operator Complex(Vector2 vector2)
        {
            return new Complex(vector2.x, vector2.y);
        }

        public static implicit operator Vector2(Complex complex)
        {
            return new Vector2(complex.re, complex.im);
        }
    }
}
