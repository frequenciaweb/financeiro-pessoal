﻿using System.Security.Cryptography;
using System.Text;

namespace FinanceiroPessoal.Utilitarios.Util
{
    public static class Seguranca
    {
        public static string HashMd5(string valor)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(valor));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
