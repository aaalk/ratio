using System;
 
namespace Ratio 
{ 
    public class Ratio 
    { 
        public int chisl; 
        public int znam; 
 
        public Ratio(int ch, int zn) 
        { 
            int NOD = MyMath.Evklid(ch, zn);
            if ((ch < 0 && zn < 0) || (ch > 0 && zn > 0))
            {
                chisl = Math.Abs(ch) / NOD;
                znam = Math.Abs(zn) / NOD;
            }
            else
            {
                chisl = -Math.Abs(ch) / NOD;
                znam = Math.Abs(zn) / NOD;
            } 
        } 
 
        public Ratio(int ch) : this(ch, 1) { }
        public Ratio() : this(1, 1) { }
        public override string ToString() 
        { 
            if (znam == 1) { return $"{chisl}"; }
            if (chisl == 0) { return $"{0}"; }
            else { return $"{chisl}/{znam}"; } 
        } 
 
        public double ToDouble() 
        { 
            return (double)chisl / znam; 
        } 
 
 
 
        public static Ratio operator *(Ratio X, Ratio Y) 
        { 
            int N, D;
            N = X.chisl * Y.chisl;
            D = X.znam * Y.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR; 
        } 
        
        public static Ratio operator *(int X, Ratio Y) 
        { 
            int N, D;
            N = X * Y.chisl;
            D = Y.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR;
        } 
 
        public static Ratio operator *(Ratio X, int Y) 
        { 
            int N, D;
            N = X.chisl * Y;
            D = X.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR;
        }
 
 
 
 
 
        public static Ratio operator /(Ratio X, Ratio Y) 
        { 
            int N, D;
            N = X.chisl * Y.znam;
            D = X.znam * Y.chisl;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR; 
        } 
        
        public static Ratio operator /(Ratio X, int Y)
        {
            int N, D;
            N = X.chisl;
            D = X.znam * Y;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR;
        }

        public static Ratio operator /(int X, Ratio Y)
        {
            int N, D;
            N = X * Y.znam;
            D = Y.chisl;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR;
        }        
        
        
        
        
        
        
        public static Ratio operator +(Ratio X, Ratio Y) 
        { 
            int N, D; 
            Ratio NewR; 
            N = X.chisl * Y.znam + Y.chisl * X.znam; 
            D = X.znam * Y.znam; 
            NewR = new Ratio(N, D); 
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR; 
        } 
        
        public static Ratio operator +(Ratio X, int Y)
        {
            int N, D;
            N = X.chisl + X.znam * Y;
            D = X.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR;
        }

        public static Ratio operator +(int X, Ratio Y)
        {
            int N, D;
            N = X * Y.znam + Y.chisl;
            D = Y.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR;
        }
        
    
        public static Ratio operator ++(Ratio X)
        { 
            int N, D;
            N = X.chisl + X.znam;
            D = X.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            return NewR; 
        }


 
        public static Ratio operator -(Ratio X, Ratio Y)
        { 
            int N, D; 
            Ratio NewR; 
            N = X.chisl * Y.znam - Y.chisl * X.znam; 
            D = X.znam * Y.znam; 
            NewR = new Ratio(N, D); 
            NewR= Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR; 
        } 
        
        
        public static Ratio operator -(Ratio X, int Y)
        {
            int N, D;
            N = X.chisl - X.znam * Y;
            D = X.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR; 
        }


        public static Ratio operator -(int X, Ratio Y)
        {
            int N, D;
            N = X * Y.znam - Y.chisl;
            D = Y.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            NewR = Odinznak(NewR);
            return NewR;
        }
 
        public static Ratio operator --(Ratio X)
        {
            int N, D;
            N = X.chisl - X.znam;
            D = X.znam;
            Ratio NewR;
            NewR = new Ratio(N, D);
            NewR = Simple_fraction(NewR);
            return NewR;
            
        }
        
        
        
        
        
        
        public static bool operator <(Ratio X, Ratio Y)
        {
            return X.chisl * Y.znam < Y.chisl * X.znam;
        }
        public static bool operator <(int X, Ratio Y)
        {
            return X * Y.znam < Y.chisl;
        }
        public static bool operator <(Ratio X, int Y)
        {
            return X.chisl < Y * X.znam;
        }






        public static bool operator >(Ratio X, Ratio Y)
        {
            return X.chisl * Y.znam > Y.chisl * X.znam;
        }
        public static bool operator >(int X, Ratio Y)
        {
            return X * Y.znam > Y.chisl;
        }
        public static bool operator >(Ratio X, int Y)
        {
            return X.chisl > Y * X.znam;
        }





        public static bool operator <=(Ratio X, Ratio Y)
        {
            return X.chisl * Y.znam <= Y.chisl * X.znam;
        }
        public static bool operator <=(int X, Ratio Y)
        {
            return X * Y.znam <= Y.chisl;
        }
        public static bool operator <=(Ratio X, int Y)
        {
            return X.chisl <= Y * X.znam;
        }





        public static bool operator >=(Ratio X, Ratio Y)
        {
            return X.chisl * Y.znam >= Y.chisl * X.znam;
        }
        public static bool operator >=(int X, Ratio Y)
        {
            return X * Y.znam >= Y.chisl;
        }
        public static bool operator >=(Ratio X, int Y)
        {
            return X.chisl >= Y * X.znam;
        }





        public static bool operator ==(Ratio X, Ratio Y)
        {
            return X.chisl == Y.chisl && X.znam == Y.znam;
        }
        public static bool operator ==(int X, Ratio Y)
        {
            return X * Y.znam == Y.chisl;
        }
        public static bool operator ==(Ratio X, int Y)
        {
            return X.chisl == Y * X.znam;
        }





        public static bool operator !=(Ratio X, Ratio Y)
        {
            return !(X == Y);
        }
        public static bool operator !=(int X, Ratio Y)
        {
            return !(X == Y);
        }
        public static bool operator !=(Ratio X, int Y)
        {
            return !(X == Y);
        }
        
        
        
        
        
        
        public static Ratio Odinznak(Ratio X) 
        {
            int chisl;
            int znam;

            if ((X.chisl < 0 && X.znam < 0) || (X.chisl > 0 && X.znam > 0))
            {
                chisl = Math.Abs(X.chisl);
                znam = Math.Abs(X.znam);
            }

            else
            {
                chisl = -Math.Abs(X.chisl);
                znam = Math.Abs(X.znam);
            }

            Ratio NewR;
            NewR = new Ratio(chisl, znam);
            NewR = Simple_fraction(NewR);

            return NewR;
        }

        public static Ratio Simple_fraction(Ratio X)
        {
            int NOD;
            NOD = MyMath.Evklid(X.chisl, X.znam);
            X.chisl /= NOD;
            X.znam /= NOD;
            return new Ratio(X.chisl, X.znam);
        }


        
        
        
        
    } 
    
    
    public class MyMath
    {
        public static int Evklid(int X, int Y)
        {
            X = Math.Abs(X);
            Y = Math.Abs(Y);
            while (X * Y != 0)
            {
                if (X > Y) { X = X % Y; }
                else { Y = Y % X; }
            }
            return X + Y;
        }
    }
    
 
    internal class Program 
    { 
        static void Main(string[] args) 
        { 
 
            var r1 = new Ratio(13, 8); 
            var r2 = new Ratio(13, 9); 
            Console.WriteLine(r1); 
        } 
    } 
}
