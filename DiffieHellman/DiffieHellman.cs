using System.Numerics;

namespace DiffieHellman;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP)
        => new Random((int)DateTime.UtcNow.Ticks).NextInt64(2, (long)primeP);

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey)
        => BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey)
        => BigInteger.ModPow(publicKey, privateKey, primeP);
}
