using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

using System.Numerics;

namespace Client
{
    public class DSAProvider
    {
        static char[] characters = new char[] { 
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 
            'u', 'v', 'w', 'x', 'y', 'z'};

        // check: is it a simple number?
        public static bool IsTheNumberSimple(int n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        // the message hash code is calculated
        private static int Hash(string hash, int q)
        {
            int k = 0;
            int f = 0;

            for (int i = 0; i < hash.Length; i++)
            {
                for (int j = 0; j < characters.Length; j++)
                {
                    if (characters[j] == hash[i])
                    {
                        f = j + 1;
                        break;
                    }
                }

                k = Convert.ToInt32(Math.Pow(k + f, 2) % q);
            }
            return k;
        }

        // a fast algorithm for raising a number to a power
        // and then finding the remainder from division by another number
        private static int Fast(int a, int r, int n)
        {
            int a1 = a;
            int z1 = r;
            int x = 1;

            while (z1 != 0)
            {
                while (z1 % 2 == 0)
                {
                    z1 /= 2;
                    a1 = (a1 * a1) % n;
                }

                z1 -= 1;
                x = (x * a1) % n;
            }

            return x;
        }

        // alculate G
        public static int CalculateG(int p, int q)
        {
            Random rand = new Random();
            double g = 0;

            while (g < 1)
            {
                g = Math.Pow(rand.Next(1, p - 1), (p - 1) / q) % p;
            }

            return Convert.ToInt32(g);
        }

        // calculate simple P
        public static int CalculateP(int q)
        {
            int p = q + 1;

            while (true) // in order that q is a divisor of p-1
            {
                bool f = false;

                for (int i = 2; i < p - 1; i++)
                {
                    if (p % i == 0)
                    {
                        f = true;
                        break;
                    }
                }

                if (!f && (p - 1) % q == 0)
                {
                    break;
                }
                else
                {
                    p++;
                }
            }
            return p;
        }

        // calculate 
        public static int CalculateY(int p, double g, int x)
        {
            return Fast(Convert.ToInt32(g), x, p);
        }

        // encode
        public static string Encode(string hash, int p, int q, double g, int x)
        {
            try
            {
                int r = 0;
                int s = 0;
                int s1 = 0;
                int k = 0;
                int h = Hash(hash, q);

                while (k < q)
                {
                    k++;

                    int k1 = 0;

                    r = Fast(Convert.ToInt32(g), k, p) % q;

                    while ((k1 * k) % q != 1 && k1 < 10)
                    {
                        k1++;
                    }

                    if (k1 == 10) continue; // did not find the appropriate K1

                    s = Convert.ToInt32(k1 *( h + x * r)) % q;

                    while ((s1 * s) % q != 1 && s1 < 10)
                    {
                        s1++;
                    }

                    if (s1 == 10) continue; // did not find the appropriate S1

                    if (r != 0 || s != 0) break;
                }
                if (k == q) // did not find the appropriate K1 < Q
                    throw new Exception();

                return r + "-" + s;
            }
            catch (Exception )
            {
                throw new Exception();
            }
        }

        // decode and compares the values of the signature and the result and returns the result
        public static bool DecodeAndEqual(string hash, int p, int q, int y, double g, string ESD)
        {
            try
            {
                string[] data = ESD.Split(new Char[] { '-' });
                int r = Convert.ToInt32(data[0]);
                int s = Convert.ToInt32(data[1]);

                int s1 = 0;
                
                while ((s1 * s) % q != 1)
                {
                    s1++;
                }

                int w = s1 % q;
                int u1 = (Hash(hash, q) * w) % q;
                int u2 = (r * w) % q;

                double mp1 = Fast(Convert.ToInt32(g), u1, p);
                double mp2 = Fast(y, u2, p);
                double res = mp1 * mp2;

                res %= p;
                res %= q;
                int v = Convert.ToInt32(res);

                return v == r;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        // calculating a text hash
        public static string GetSHA256Hash(string text)
        {
            SHA256 SHA256Hash = SHA256.Create();

            byte[] data = SHA256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}