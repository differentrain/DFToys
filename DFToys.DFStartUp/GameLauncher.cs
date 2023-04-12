using DFToys.DFStartup.Properties;
using DFToys.OpenSslRas;
using System;
using System.Diagnostics;
using System.IO;

namespace DFToys.GameStartup
{
    public class GameLauncher
    {
        private const int UID_POS = 210;

        private static readonly byte[] s_defaultPrivateKey = Convert.FromBase64String(@"MIIEpAIBAAKCAQEA54CcB7WFUdDgdbyNdGp9fuTrhBmN8smDe+GGsFc8snskvS6KJB7NLVXWbyXfz6flN8A7ZtSlRfWxjMtVX9iUAzWBjo3Yq20es/PJVXMQfVmuYrYseZ/Idk0XPTBx1vXeAte1DOFPPGjoakRZKz5m1QfO/vqa6REl/l01BQKjFvf1UhNoBFIK1Dk5Jld6QYlgla2kciLGEca2rvUO+OpcjZj3qIpJp+AiQlSGlgpOuCD1B4qJQcQ6AYiTLSsu06d5AoGKc+i7qEdzeocV1vi/2OhcqqbO0E6r71eYtSTK77UWSBnT4SXmsEqB9VSjjY9E9Bn++IlOmAfcoKEuHN1tUwIDAQABAoIBAQCMLtfM30Fk4qwY/11U4mst3Oc0rdjD7PyellleDOVnWqRLnpPt/WzXCAR6d5/Iee2WTeRqh1exPm8OR85h5J70NoFGVmSeocwWwgfno26XySeNBK131Kap5FKvLdexiF6wr/glXYYCmbArMUohon7Yfwr8YbpOaaDtH3nMl+U0MTk29xZ+PDiqFTFvuO5lidLIMeXDLm7DH18SlkL/ABBQpbTqBc0PZPJDzYJr5EUiVUuFuZ8mqtxwYSGGy2YOSc86uasP00aqz1YwTtIx9tXQOwUveio1aNUJskGS+kjPQnrKrLPQkl1fp2ON5gpHSagSs88TB3tIvdawezDSiqBhAoGBAPsDOZdntsXwQN4KQHeUaVHLBEi5wgeGnToS6//oGLcn+mah+ZyqAdkkdvvcPP+AXtdnLkUyUguyKugWPzjtCh6Ik8U34KeNBM9mYyKziDepXadQ/UY5KO41dY200FC1Df+ysIj0JWoDf6MomGU2M8n5b4Ydp9DIEl09FebxZ2oDAoGBAOwaJVaAoZkVmn/2tIMt/Cgx3Q/M3UioeT/oYoi9LxV5mpUuhEvPIdjXlDUvgwCkpsWPWUYDWCAcOgqJOvo0nlzkUo8iiSs0zIvQJHm5DYN9NeWk6JeXXdJM/dgcAuOcwSzHo/dLvLjB8jgGffDH+dAdUFy/+jchJeA2miOBSTZxAoGBALUAnFTbSubs2jnCtr4D3PZIKOywVoPKxDGOV3OPT9MzFtNPVYls5ixIqSvwomOzk7BMDQeEw7j/XwVAlZJdC4D9B2Gda3gmriNIN5BcWYuZq5jtQ9WRfjxXfE8U5WptRIzvs3DubNRHdZCXw1yoeyvXnF3foJVi0Cs/0z1XMjU1AoGAdT0ac1TWaazXlllME6OfBdqU2gaxjyXRZ5GedCX1HmXPA+sgWICXXxTVjH92PriD87AV9XUtqmw5ygeQ2LOOO7RI5riQgnrqYzbNFgB1HGjtfYYg1T2dohMHLevi52Fsby8HVYIvSVNNUtKucQTsIJKd2CCgQAXex/J1IdJOJ5ECgYAziuWeHMnFb6wTxkyIZK/5ADR6k7albhC6ow9IGAh2QnAT6+vC2shyXDIudUgBiaR84m8z4rb7Cvt+ojuMTzSMjJsCvGKmf7OB6vsvm9F41mCNKkKZEzb9dfbyMdZ+wk63NgGCv/4oqNnHmIUn0/cqUsF49QVWqxxZG7guBdzyQg==");

        [ThreadStatic]
        private static readonly byte[] s_fill = new byte[] {
            0x00, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00,
            // 210
            0x00, 0x00, 0x00, 0x00,
            0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x55, 0x91, 0x45, 0x10, 0x01, 0x04, 0x03, 0x03, 0x01, 0x01 };


        public void Run(string gamePath, int userId) => Run(gamePath, userId, s_defaultPrivateKey);

        public void Run(string gamePath, int userId, byte[] rsakey)
        {

            Process proc = null;
            try
            {
                var psi = new ProcessStartInfo()
                {
                    FileName = gamePath,
                    Arguments = CreateArgs(userId, rsakey),
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetDirectoryName(gamePath),
                };

                proc = Process.Start(psi);
                if (proc == null || proc.HasExited)
                {
                    throw new InvalidOperationException("运行失败。");
                }
            }
            finally
            {
                proc?.Dispose();
            }
        }


        public string CreateArgs(int userId, byte[] rsakey)
        {
            byte[] data = CreateBytes(userId);
            return Convert.ToBase64String(RsaEncrypt(data, rsakey));
        }

        protected virtual byte[] CreateBytes(int userId)
        {
            unsafe
            {
                fixed (byte* b = s_fill)
                    *(int*)(b + UID_POS) = userId;
            }
            Array.Reverse(s_fill, UID_POS, 4);
            return s_fill;
        }

        protected byte[] RsaEncrypt(byte[] data, byte[] rsaKey)
        {
            using (var rsa = SimpleRsa.CreateFromPrivateKey(rsaKey.AsSpan()))
            {
                var output = new byte[256];
                if (rsa.Encrypt(data, output, RsaPadding.None) != 256)
                    throw new ArgumentNullException(nameof(rsa), "Rsa密钥不正确。");
                return output;
            }
        }


        public static void ExportDefaultPrivateKey(string fileName) => WriteFile(fileName, Resources.privatekey);

        public static void ExportDefaultPublicKey(string fileName) => WriteFile(fileName, Resources.publickey);

        private static void WriteFile(string fileName, byte[] data)
        {
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(data, 0, data.Length);
                fs.Flush();
            }
        }

    }
}
