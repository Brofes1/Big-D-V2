using System.ComponentModel;
using System.Security.AccessControl;

namespace Big_D_V2
{
    public class Big_D
    {
        // Here, have a base10. No, you do not get anything else. CONVERT YOUR CRAP FIRST!

        public double mantissa;
        public double exponent;

        public Big_D(double mantissa = 0, double exponent = 0)
        {
            this.mantissa = mantissa;
            this.exponent = exponent;

            this.Cleanup();
        }

        public Big_D Cleanup()
        {
            if (mantissa != 0)
            {
                this.exponent += Math.Floor(Math.Log10(Math.Abs(mantissa)));
                this.mantissa /= Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(mantissa))));
            }
            else
                this.exponent = 0;

            return this;
        }

        public Big_D LogB(int b) => (Math.Log(mantissa) / Math.Log(b)) + (exponent * (Math.Log(10) / Math.Log(b)));

        public Big_D Log2() => Math.Log2(mantissa) + (exponent * Math.Log2(10));

        public Big_D Log10() => Math.Log10(mantissa) + exponent;

        public Big_D Clone() => new Big_D(mantissa, exponent);

        public static bool operator >(Big_D num1, Big_D num2)
        {
            if (num1.exponent < num2.exponent)
                return false;
            else if (num1.exponent > num2.exponent)
                return true;
            else if (num1.mantissa < num2.mantissa)
                return false;
            else if (num1.mantissa > num2.mantissa)
                return true;

            //Equal values
            return false;
        }

        public static bool operator <(Big_D num1, Big_D num2) => num2 > num1;

        public static bool operator ==(Big_D num1, Big_D num2)
        {
            if (num1.mantissa == num2.mantissa && num1.exponent == num2.exponent)
                return true;
            else return false;
        }

        public static bool operator !=(Big_D num1, Big_D num2) => !(num1 == num2);

        public static Big_D operator +(Big_D left, Big_D right)
        {
            if (left.mantissa <= (right.mantissa - (32 * Math.Log10(2)))) // Return right if adding them doesn't change the mantissa
            {
                return right;
            }
            else if (right.mantissa <= (left.mantissa - (32 * Math.Log10(2)))) // Return left if adding them doesn't change the mantissa
            {
                return left;
            }
            else if (left == right)
            {
                return new Big_D(left.mantissa * 2, left.exponent);
            }
            else
            {
                Big_D greater;
                Big_D lesser;
                if (right > left)
                {
                    greater = right.Clone();
                    lesser = left.Clone();
                }   
                else
                {
                    greater = left.Clone();
                    lesser = right.Clone();
                }

                double difference = greater.exponent - lesser.exponent;
                lesser.mantissa /= Math.Pow(10, difference);
                greater.mantissa += lesser.mantissa;
                return greater.Cleanup();
            }   
        }

        public static Big_D operator *(Big_D left, Big_D right) => new Big_D(left.mantissa * right.mantissa, left.exponent + right.exponent);

        public static Big_D operator -(Big_D left, Big_D right) => left + (right * -1);

        public static Big_D Pow(Big_D left, Big_D right) => new Big_D(Math.Pow(left.mantissa, right.mantissa), left.exponent * right.mantissa * Math.Pow(10, right.exponent));

        public static Big_D operator /(Big_D left, Big_D right) => left * Big_D.Pow(right, -1); 

        public override string ToString()
        {
            if (exponent < 3)
                return (mantissa * Math.Pow(10, exponent)).ToString();
            if (Math.Pow(10, 3) > exponent && exponent >= 3)
                return $"{Math.Round(mantissa, 3)}e{exponent}";
            else
                return $"{exponent / Math.Pow(10, Math.Floor(Math.Log10(exponent)))}e{Math.Floor(Math.Log10(exponent))}";
        }

        public static implicit operator Big_D(double num) => new Big_D(num);
        public static implicit operator Big_D(float num) => new Big_D(num);
        public static explicit operator Big_D(decimal num) => new Big_D((double)num);
        public static implicit operator Big_D(sbyte num) => new Big_D(num);
        public static implicit operator Big_D(byte num) => new Big_D(num);
        public static implicit operator Big_D(short num) => new Big_D(num);
        public static implicit operator Big_D(ushort num) => new Big_D(num);
        public static implicit operator Big_D(int num) => new Big_D(num);
        public static implicit operator Big_D(uint num) => new Big_D(num);
        public static explicit operator Big_D(long num) => new Big_D(num);
        public static explicit operator Big_D(ulong num) => new Big_D(num);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}