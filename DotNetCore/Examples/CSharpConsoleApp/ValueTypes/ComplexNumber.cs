using System;

namespace ValueTypes {

    public struct ComplexNumber {
        public int RealComponent;
        public int ImaginaryComponent;

        public ComplexNumber(int real, int imaginary)
        {
            RealComponent = real;
            ImaginaryComponent = imaginary;
        }
    }

}