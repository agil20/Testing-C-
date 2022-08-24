namespace TestingUnit.Services
{
    public class IdentityValidator :    IIdentityValidator
    {
        public ICountyProvider Country => throw new System.NotImplementedException();

        public Yasheddi yasheddi { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool IsReturnCv()
        {
            throw new System.NotImplementedException();
        }

        public bool IsValid(string identiyNumber)
        {
            return true;
        }
    }
}
