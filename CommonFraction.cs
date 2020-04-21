using System;

namespace CsPractice3
{
    class CommonFraction
    {
         Int32 numerator;
         Int32 denominator;

        public CommonFraction(Int32 numerator = 1, Int32 denominator = 1)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public void ReverseFraction()
        {
            numerator += denominator;
            denominator = numerator - denominator;
            numerator -= denominator;
        }

        public void ReduceFraction()
        {
            while (denominator % 2 == 0 && numerator % 2 == 0)
            {
                numerator /= 2;
                denominator /= 2;
            }

            if (Math.Abs(numerator) < Math.Abs(denominator))
                for (int i = 3; i <= Math.Abs(numerator); i += 2)
                {
                    while (denominator % i == 0 && numerator % i == 0)
                    {
                        denominator /= i;
                        numerator /= i;
                    }
                }
            else if (Math.Abs(numerator) > Math.Abs(denominator))
                for (int i = 3; i <= Math.Abs(denominator); i += 2)
                {
                    while (denominator % i == 0 && numerator % i == 0)
                    {
                        denominator /= i;
                        numerator /= i;
                    }
                }
            else if (numerator == denominator)
            {
                numerator = 1;
                denominator = 1;
            }
            else if (numerator == Math.Abs(denominator) || Math.Abs(numerator) == denominator)
            {
                numerator = -1;
                denominator = 1;
            } 
        }

        public bool SetValues(Int32 numerator, Int32 denominator)
        {
            if (denominator != 0)
            {
                this.numerator = numerator;
                this.denominator = denominator;

                return true;
            }
            else return false;
        }

        public static CommonFraction operator +(CommonFraction frac1, CommonFraction frac2)
        {
            CommonFraction res = new CommonFraction(frac1.numerator * frac2.denominator +
                frac2.numerator * frac1.denominator,
                frac1.denominator * frac2.denominator);

            res.ReduceFraction();

            return res;
        }

        public static CommonFraction operator -(CommonFraction frac1, CommonFraction frac2)
        {
            CommonFraction res = new CommonFraction(frac1.numerator * frac2.denominator -
                frac2.numerator * frac1.denominator,
                frac1.denominator * frac2.denominator);

            res.ReduceFraction();

            return res;
        }

        public static CommonFraction operator *(CommonFraction frac1, CommonFraction frac2)
        {
            CommonFraction res = new CommonFraction(frac1.numerator * frac2.numerator,
                frac1.denominator * frac2.denominator);

            res.ReduceFraction();

            return res;
        }

        public override string ToString()
        {
            if (numerator > 0 && denominator < 0)
            {
                numerator = -numerator;
                denominator = Math.Abs(denominator);
            }
            else if (numerator < 0 && denominator < 0)
            {
                numerator = Math.Abs(numerator);
                denominator = Math.Abs(denominator);
            }

            if (numerator == 0)
                return "0";
            else if (denominator == 0)
                return "NaN";
            else if (denominator == 1)
                return numerator.ToString();
            else return $"{numerator}/{denominator}";
        }
    }
}