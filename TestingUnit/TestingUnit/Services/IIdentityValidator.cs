namespace TestingUnit.Services
{
    public interface IIdentityValidator
    {
        bool IsValid(string identiyNumber);
        bool IsReturnCv();
        ICountyProvider Country { get; }
        Yasheddi yasheddi { get; set; }

    }
    public interface ICountyProvider 
    {
        string Countr { get; }

    }
    public enum Yasheddi
    {
        islemekolar,
        kecersizdir
    }

}
