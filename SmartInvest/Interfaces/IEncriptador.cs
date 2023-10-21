namespace SmartInvest.Interfaces
{
    public interface IEncriptador
    {
        string Encriptar(string textoPlano);
        string Desencriptar(string textoCifrado);
    }
}
