using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.IO;
using System.Numerics;
using System.Security.Cryptography;

namespace Client
{
    public class RSAProvider
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

        // calculate N
        public static int CalculateN(int p, int q)
        {
            return p * q;
        }

        // calculation of the parameter D. D must be relatively prime to M
        public static int CalculateD(int m)
        {
            int d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) // if they share common factors
                {
                    d--;
                    i = 1;
                }

            return d;
        }

        // calculate E
        public static int CalculateE(int d, int m)
        {
            int e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }

        // encode
        public static string Encode(string hash, int e, int n)
        {
            string result = "";

            BigInteger bi;

            for (int i = 0; i < hash.Length; i++)
            {
                int index = Array.IndexOf(characters, hash[i]);

                bi = BigInteger.Pow(index, e);

                BigInteger n_ = new BigInteger(n);

                bi = bi % n_;

                result += bi.ToString();

                if (i != hash.Length - 1)
                    result += "-";
            }

            return result;
        }

        // decode
        public static string Dedoce(string ESD, int d, int n)
        {
            string result = "";

            BigInteger bi;

            string[] items = ESD.Split(new Char[] { '-' });

            for (int i = 0; i < items.Length; i++)
            {
                bi = new BigInteger(Convert.ToInt32(items[i]));

                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);
                bi = bi % n_;
                int index = Convert.ToInt32(bi.ToString());
                result += characters[index].ToString();
            }

            return result;
        }

        // calculating a text hash
        public static string GetMd5Hash(string text)
        {
            MD5 md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}