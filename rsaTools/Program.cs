using System;
using System.Security.Cryptography;
using System.Text;

namespace RSATools
{
    class Program
    {
        static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nRSA加解密工具");
                Console.WriteLine("1. 生成新密钥对");
                Console.WriteLine("2. 加密文本");
                Console.WriteLine("3. 解密文本");
                Console.WriteLine("4. 退出");
                Console.Write("请选择操作：");

                switch (Console.ReadLine())
                {
                    case "1":
                        GenerateKeys();
                        break;
                    case "2":
                        HandleCryptoOperation("2");
                        break;
                    case "3":
                        HandleCryptoOperation("3");
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("无效输入，请重新选择");
                        break;
                }
            }
        }

        static void GenerateKeys()
        {
            rsa = new RSACryptoServiceProvider(2048);
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);
            
            Console.WriteLine("\n新密钥对已生成");
            Console.WriteLine($"公钥：\n{publicKey}");
            Console.WriteLine($"私钥：\n{privateKey}");
            Console.WriteLine("警告：请妥善保管私钥！");
        }

        static void HandleCryptoOperation(string operationType)
        {
            try 
            {
                Console.Write("请输入要处理的文本：");
                string input = Console.ReadLine();
                
                if(string.IsNullOrEmpty(input)) 
                {
                    Console.WriteLine("输入不能为空");
                    return;
                }

                byte[] data = Encoding.UTF8.GetBytes(input);
                
                if (operationType == "2")
                {
                    byte[] encrypted = rsa.Encrypt(data, true);
                    Console.WriteLine($"加密结果（Base64）：\n{Convert.ToBase64String(encrypted)}");
                }
                else
                {
                    byte[] decrypted = rsa.Decrypt(Convert.FromBase64String(input), true);
                    Console.WriteLine($"解密结果：\n{Encoding.UTF8.GetString(decrypted)}");
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"加解密失败：{ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("输入格式不正确（需要Base64编码）");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误：{ex.Message}");
            }
        }
    }
}
